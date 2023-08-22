CREATE PROCEDURE [dbo].[spUser_Verify_User]
	@password nvarchar(50),
	@email nvarchar(50)
	
AS
begin
	 set nocount on
	 select *
	 from dbo.Users u 
	 where u.Email= @email and u.Password = @password;
end
