using DentalApp.Data.Access.Maps.Common;
using DentalApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DentalApp.Data.Access.Maps.Main
{
    public class DoctorMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Doctor>(doctor =>
            {
                string tableName = "Doctors";
                doctor.ToTable(tableName);
                doctor.HasKey(d => d.ID).HasName($"PK_{tableName}_ID");

                doctor.Property(d => d.ID).UseSqlServerIdentityColumn(); //autoincrement
                //Configure NotNull Columns and specify max number of characters for the column that the property should map to
                doctor.Property(d => d.LastName).HasMaxLength(40).IsRequired();
                doctor.Property(d => d.FirstName).HasMaxLength(20).IsRequired();
                doctor.Property(d => d.Address).HasMaxLength(40);
                doctor.Property(d => d.SpecialtyName).HasMaxLength(40);

                //Един доктор има много аппойнтмънти и един доктор може да бъде свързан с много аппойнтмънти
                doctor.HasMany(d => d.Appointments).WithOne(ap => ap.Doctor).HasForeignKey(ap=>ap.DoctorID).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
