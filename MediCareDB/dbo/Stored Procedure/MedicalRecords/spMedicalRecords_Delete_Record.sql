CREATE PROCEDURE [dbo].[spMedicalRecords_Delete_Record]
    @Id INT
AS
BEGIN
    DELETE FROM MedicalRecords
    WHERE
        Id = @Id
END