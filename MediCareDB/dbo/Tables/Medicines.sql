CREATE TABLE [dbo].[Medicines]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DrugName] NVARCHAR(50) NOT NULL, 
    [Dosage] FLOAT NOT NULL, 
    [DrugAmount] INT NOT NULL, 
    [TimePeriod] NVARCHAR(20) NOT NULL, 
    [DrugDescription] NVARCHAR(100) NOT NULL
)
