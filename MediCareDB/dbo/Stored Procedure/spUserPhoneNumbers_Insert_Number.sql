CREATE PROCEDURE [dbo].[spUserPhoneNumbers_Insert_Number]
	@Id int,
	@phoneNumber nvarchar(20)
AS
begin
	set nocount on
	insert into dbo.UserPhoneNumbers (UserId,PhoneNumber)
	values(@Id,@phoneNumber)
end
