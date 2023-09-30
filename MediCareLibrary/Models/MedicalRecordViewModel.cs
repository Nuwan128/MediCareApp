using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCareLibrary.Models
{
    public class MedicalRecordViewModel
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }

}


   
