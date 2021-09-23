using DentalApp.Data.Access.Maps.Common;
using DentalApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DentalApp.Data.Access.Maps.Main
{
    public class PatientMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Patient>(patient =>
            {
                string tableName = "Patients";
                patient.ToTable(tableName);
                patient.HasKey(p => p.ID).HasName($"PK_{tableName}_ID");

                patient.Property(p => p.ID).UseSqlServerIdentityColumn();//autoincrement
                //Configure NotNull Columns and specify max number of characters for the column that the property should map to
                patient.Property(p => p.FirstName).HasMaxLength(20).IsRequired();
                patient.Property(p => p.LastName).HasMaxLength(50).IsRequired();
                patient.Property(p => p.Email).HasMaxLength(70);
                patient.Property(p => p.BirthDate).IsRequired();
                patient.Property(p => p.Gender).HasMaxLength(1).IsRequired();

                //One to many relationship configuration
                //Един пациент има много аппойнтмънти и много апойнтмънти могат да бъдат свързани с един пациент
                patient.HasMany(p => p.Appointments).WithOne(ap => ap.Patient).HasForeignKey(ap => ap.DoctorID).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

