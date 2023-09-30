CREATE PROCEDURE [dbo].[spDoctor_Insert_Doctor]
	@Id int,
	@speciality nvarchar(20)
AS
begin
	set nocount on
	insert into dbo.Doctors(Speciality,UserId)
	values(@speciality,@Id)
end
