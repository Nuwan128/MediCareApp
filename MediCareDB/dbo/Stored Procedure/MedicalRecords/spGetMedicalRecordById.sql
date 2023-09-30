CREATE PROCEDURE [dbo].[spGetMedicalRecordById]
   @Id INT
AS
BEGIN
    SELECT * FROM MedicalRecords WHERE Id = @Id;
END