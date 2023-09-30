using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCareLibrary.Models
{
    public class FullUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string NIC { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public string? Speciality { get; set; }

        public List<PhoneNumberModel> phoneNumbers { get; set; } = new List<PhoneNumberModel>();
        public List<MedicalRecord>? MedicalRecords { get; set; } = new List<MedicalRecord>();

    }
}
