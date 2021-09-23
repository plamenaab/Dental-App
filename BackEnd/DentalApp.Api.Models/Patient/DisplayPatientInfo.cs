using DentalApp.Data.Access.Helpers;
using DentalApp.Data.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalApp.Api.Models.Patient
{
    public class DisplayPatientInfo
    {
        public int ID { get; set; }
       
        [Required]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
    }
}
