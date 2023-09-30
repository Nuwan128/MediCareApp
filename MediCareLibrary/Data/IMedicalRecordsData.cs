using MediCareLibrary.Models;
using Microsoft.AspNetCore.Http;

namespace MediCareLibrary.Data
{
    public interface IMedicalRecordsData
    {
        void CreateMedicalRecord(MedicalRecord medicalRecord);
        void DeleteMedicalRecord(int id);
        MedicalRecord GetMedicalRecordById(int id);
        List<MedicalRecord> GetMedicalRecords();
        void UpdateMedicalRecord(MedicalRecord medicalRecord);
        Task<string> UploadFileAsync(IFormFile file);
    }
}