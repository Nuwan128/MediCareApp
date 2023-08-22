CREATE PROCEDURE [dbo].[spUsers_Get_All_Users]
	
AS
begin
	 set nocount on
	 select *
	from dbo.Users u 
end
