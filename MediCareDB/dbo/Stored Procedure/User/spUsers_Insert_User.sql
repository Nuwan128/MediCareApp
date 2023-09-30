CREATE PROCEDURE [dbo].[spUsers_Insert_User]
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@password nvarchar(50),
	@NIC nvarchar(50),
	@birthday date,
	@email nvarchar(50),
	@address nvarchar(100),
	@userType nvarchar(10)
AS
begin
	set nocount on
	if not exists (select 1 from dbo.Users where NIC = @NIC)
	begin
		insert into dbo.Users (FirstName,LastName,Password,NIC,Birthday,Email,Address,UserType)
		values (@firstName,@lastName,@password,@NIC,@birthday,@email,@address,@userType)
	end
end
