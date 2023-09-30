CREATE PROCEDURE [dbo].[spMedicalRecords_Insert_Record]
  @MedicalRecordDescription NVARCHAR(100),
    @MedicalRecordDate DATE,
    @DoctorId INT,
    @PatientId INT,
    @FilePath NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO MedicalRecords (MedicalRecordDescription, MedicalRecordDate, DoctorId, PatientId, FilePath)
    VALUES (@MedicalRecordDescription, @MedicalRecordDate, @DoctorId, @PatientId, @FilePath);
END