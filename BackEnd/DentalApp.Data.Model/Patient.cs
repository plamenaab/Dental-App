using DentalApp.Data.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalApp.Data.Model
{
   public class Patient : User
    {
        public Patient()
        {
            Appointments = new List<Appointment>();
        }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        //един пациент има много апойнтмънти и чрез виртуалния списък се стартира приложението и могат да бъдат компилирани данните
        public virtual IList<Appointment> Appointments { get; set; }

    }
}
