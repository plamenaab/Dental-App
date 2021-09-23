using System.Linq;
using System.Threading.Tasks;
using DentalApp.Api.Models.Doctor;
using DentalApp.Data.Model;

namespace DentalApp.Queries.Queries
{
    public interface IAppointmentQuery
    {
        IQueryable<Appointment> Get();

        Appointment GetAppointment(int id);

        Task<Appointment> Create(AppointmentModel model);

        Task<Appointment> Update(AppointmentModel model);

        Task Delete(int id);
    }
}