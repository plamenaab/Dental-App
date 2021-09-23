using System.Linq;
using System.Threading.Tasks;
using DentalApp.Api.Models.Doctor;
using DentalApp.Data.Model;

namespace DentalApp.Queries.Queries
{
    public interface IDoctorQuery
    {
        IQueryable<Doctor> Get();

        Doctor GetDoctor(int id);

        DisplayDoctorInfo DisplayDoctorInfo(int id);

        Task<Doctor> Update(DoctorModel model);

        Task Delete(int id);
    }
}