using System;
using System.Collections.Generic;
using System.Text;

namespace DentalApp.Api.Models.Doctor
{
    public class DoctorModel
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string SpecialtyName { get; set; }

        //It is like a description of the doctor's professional background
        public string ProfessionalStatement { get; set; }

        public double FirstConsultationFee { get; set; }

        public double FollowupConsultationFee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
