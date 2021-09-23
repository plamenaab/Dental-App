using DentalApp.Data.Access.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalApp.Api.Models.Doctor
{
    public class AppointmentModel
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
    }
}
