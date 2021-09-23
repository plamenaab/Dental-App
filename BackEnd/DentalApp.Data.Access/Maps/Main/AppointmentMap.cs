using DentalApp.Data.Access.Maps.Common;
using DentalApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DentalApp.Data.Access.Maps.Main
{
    public class AppointmentMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Appointment>(appointment =>
            {
                string tableName = "Appointments";
                appointment.ToTable(tableName);
                appointment.HasKey(ap => ap.ID).HasName($"PK_{tableName}_ID");

                appointment.Property(ap => ap.ID).UseSqlServerIdentityColumn(); //autoincrement

            });
        }
    }
}
