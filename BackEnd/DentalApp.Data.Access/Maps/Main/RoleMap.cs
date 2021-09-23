using DentalApp.Data.Access.Maps.Common;
using DentalApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DentalApp.Data.Access.Maps.Main
{
    public class RoleMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .ToTable("Roles")
                .HasKey(x => x.ID);
        }
    }
}
