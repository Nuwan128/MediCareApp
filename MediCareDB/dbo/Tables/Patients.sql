CREATE TABLE [dbo].[Patients]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Height] FLOAT NOT NULL, 
    [Weight] FLOAT NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Patients_Users] FOREIGN KEY (UserId) REFERENCES Users(Id)
)
