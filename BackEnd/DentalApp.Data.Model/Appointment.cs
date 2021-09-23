using System;
using DentalApp.Data.Access.Enums;


namespace DentalApp.Data.Model
{
    public class Appointment
    {
        public int ID { get; set; }

        public int PatientID { get; set; }

        public int DoctorID { get; set; }

        public DateTime DateTime { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public DateTime AppointmentTakenDate { get; set; }

        public string ProcedureName { get; set; }

        public string ProcedureDescription { get; set; }

        public double ProcedureCost { get; set; }

        //много appointments имат един patient 
        public virtual Patient Patient { get; set; }

        //много appointments имат един doctor 
        public virtual Doctor Doctor { get; set; }
        
    }
}
