using Microsoft.EntityFrameworkCore;

namespace DentalApp.Data.Access.Maps.Common
{
    public interface IMap
    {
        void Visit(ModelBuilder builder);
    }
}
