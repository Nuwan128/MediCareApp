CREATE PROCEDURE [dbo].[spPatient_Insert_Patient]
	@Id int,
	@height float,
	@weight float
AS
begin
	set nocount on
	insert into dbo.Patients(Height,Weight,UserId)
	values(@height,@weight,@Id)
end