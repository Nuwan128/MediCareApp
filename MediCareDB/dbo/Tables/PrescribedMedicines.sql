CREATE TABLE [dbo].[PrescribedMedicines]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY , 
    [PrescriptionId] INT NOT NULL, 
    [MedicineId] INT NOT NULL, 
    [PrescribedMedicineDate] DATE NOT NULL, 
    CONSTRAINT [FK_PrescribedMedicines_Prescriptions] FOREIGN KEY (PrescriptionId) REFERENCES Prescriptions(Id), 
    CONSTRAINT [FK_PrescribedMedicines_Medicines] FOREIGN KEY (MedicineId) REFERENCES Medicines(Id)
)
