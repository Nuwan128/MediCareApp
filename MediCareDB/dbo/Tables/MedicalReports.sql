CREATE TABLE [dbo].[MedicalReports]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Recommendation] NVARCHAR(100) NOT NULL, 
    [Symptoms] NVARCHAR(100) NOT NULL, 
    [MedicalReportDescription] NVARCHAR(200) NOT NULL, 
    [ReportDate] DATE NOT NULL, 
    [MedicalRecordId] INT NOT NULL, 
    CONSTRAINT [FK_MedicalReports_MedicalRecords] FOREIGN KEY (MedicalRecordId) REFERENCES MedicalRecords(Id)
)
