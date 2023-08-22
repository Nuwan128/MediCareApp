CREATE TABLE [dbo].[UserPhoneNumbers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [PhoneNumber] NVARCHAR(20) NOT NULL, 
    CONSTRAINT [FK_UserPhoneNumbers_Users] FOREIGN KEY (UserId) REFERENCES Users(Id)
)
