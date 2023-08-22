CREATE TABLE [dbo].[MedicalRecords]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MedicalRecordDescription] NVARCHAR(100) NOT NULL, 
    [MedicalRecordDate] DATE NOT NULL, 
    [DoctorId] INT NOT NULL, 
    [PatientId] INT NOT NULL, 
    CONSTRAINT [FK_MedicalRecords_Doctors] FOREIGN KEY (DoctorId) REFERENCES Doctors(Id), 
    CONSTRAINT [FK_MedicalRecords_Patients] FOREIGN KEY (PatientId) REFERENCES Patients(Id)
)
