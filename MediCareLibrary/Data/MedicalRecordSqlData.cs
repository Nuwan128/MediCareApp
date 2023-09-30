using MediCareLibrary.Databases;
using MediCareLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediCareLibrary.Data
{
    public class MedicalRecordSqlData : IMedicalRecordsData
    {
        private readonly ISqlDataAccess _db;
        private readonly string _uploadDirectory;
        private const string connectionStringName = "SqlDb";

        public MedicalRecordSqlData(ISqlDataAccess db, IOptions<AppSettings> appSettings)
        {
            _db = db;
            _uploadDirectory = appSettings.Value.UploadDirectory;

        }

        public void CreateMedicalRecord(MedicalRecord medicalRecord)
        {
            _db.SaveData("dbo.spMedicalRecords_Insert_Record", new
            {
                MedicalRecordDescription = medicalRecord.MedicalRecordDescription,
                MedicalRecordDate = medicalRecord.MedicalRecordDate,
                DoctorId = medicalRecord.DoctorId,
                PatientId = medicalRecord.PatientId,
                FilePath = medicalRecord.FilePath
            }, connectionStringName, true);

           
      
        }

        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            _db.SaveData("dbo.spMedicalRecords_Update_Record", new
            {
                Id = medicalRecord.Id,
                MedicalRecordDescription = medicalRecord.MedicalRecordDescription,
                MedicalRecordDate = medicalRecord.MedicalRecordDate,
                DoctorId = medicalRecord.DoctorId,
                PatientId = medicalRecord.PatientId,
                FilePath = medicalRecord.FilePath

            }, connectionStringName, true);


        }

        public void DeleteMedicalRecord(int id)
        {
            _db.SaveData("dbo.spMedicalRecords_Delete_Record", new { Id = id }, connectionStringName, true);


        }

        public List<MedicalRecord> GetMedicalRecords()
        {
            List<MedicalRecord> medicalRecords = _db.LoadData<MedicalRecord, dynamic>(
                "SELECT * FROM dbo.MedicalRecords",
                new { },
                connectionStringName,
                false
            );



            return medicalRecords;
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            MedicalRecord medicalRecord = _db.LoadData<MedicalRecord, dynamic>(
                "SELECT * FROM dbo.MedicalRecords WHERE Id = @Id",
                new { Id = id },
                connectionStringName,
                false
            ).FirstOrDefault();



            return medicalRecord;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Invalid file.");
            }

            try
            {
                
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

              
                var filePath = Path.Combine(_uploadDirectory, uniqueFileName);

               
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return filePath;


            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while uploading the file: {ex.Message}", ex);
            }
        }

    }
}
