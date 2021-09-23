using System;
using System.Collections.Generic;
using System.Text;

namespace DentalApp.Data.Model
{
   public class Doctor : User
    {
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }
        public string SpecialtyName { get; set; }

        //It is like a description of the doctor's professional background
        public string ProfessionalStatement { get; set; }

        public double FirstConsultationFee { get; set; }

        public double FollowupConsultationFee { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        //един доктор има много апойнтмънти и чрез виртуалния списък се стартира приложението и могат да бъдат компилирани данните
        public virtual IList<Appointment> Appointments { get; set; }
       
    }
}
