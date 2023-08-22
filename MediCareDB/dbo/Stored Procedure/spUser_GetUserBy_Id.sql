CREATE PROCEDURE [dbo].[spUser_GetUserBy_Id]
	@Id int
AS
begin
	 set nocount on
	 select *
	 from dbo.Users u 
	 where u.Id = @Id;
end

