CREATE TABLE [dbo].[Doctors]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Speciality] NVARCHAR(50) NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Doctors_Users] FOREIGN KEY ([UserId]) REFERENCES Users(Id)
)
