CREATE TABLE [dbo].[Prescriptions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MedicalReportId] INT NOT NULL, 
    [PrescriptionDescription] NVARCHAR(200) NOT NULL, 
    CONSTRAINT [FK_Prescriptions_MedicalReports] FOREIGN KEY ([MedicalReportId]) REFERENCES MedicalReports(Id)
)
