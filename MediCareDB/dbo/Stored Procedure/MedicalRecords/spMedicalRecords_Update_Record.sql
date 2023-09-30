CREATE PROCEDURE [dbo].[spMedicalRecords_Update_Record]
   @Id INT,
    @MedicalRecordDescription NVARCHAR(100),
    @MedicalRecordDate DATE,
    @DoctorId INT,
    @PatientId INT,
    @FilePath NVARCHAR(MAX)
AS
BEGIN
    UPDATE MedicalRecords
    SET MedicalRecordDescription = @MedicalRecordDescription,
        MedicalRecordDate = @MedicalRecordDate,
        DoctorId = @DoctorId,
        PatientId = @PatientId,
        FilePath = @FilePath
    WHERE Id = @Id;
END