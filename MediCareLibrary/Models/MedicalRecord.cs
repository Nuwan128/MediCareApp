using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCareLibrary.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string MedicalRecordDescription { get; set; }
        public DateTime MedicalRecordDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string FilePath { get; set;}
    }
}
