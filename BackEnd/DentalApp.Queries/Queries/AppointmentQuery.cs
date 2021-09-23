using System.Linq;
using System.Threading.Tasks;
using DentalApp.Api.Models.Doctor;
using DentalApp.Data.Access.DAL;
using DentalApp.Data.Model;

namespace DentalApp.Queries.Queries
{
    public class AppointmentQuery : IAppointmentQuery
    {
        private readonly IUnitOfWork _uow;

        public AppointmentQuery(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Appointment> Create(AppointmentModel model)
        {
            var appointment = new Appointment
            {
                DateTime = model.DateTime,
                DoctorID = model.DoctorID,
                PatientID = model.PatientID,
                AppointmentTakenDate = model.AppointmentTakenDate,
                AppointmentStatus = model.AppointmentStatus,
                ProcedureDescription = model.ProcedureDescription,
                ProcedureCost = model.ProcedureCost,
                ProcedureName = model.ProcedureName
            };

            _uow.Add(appointment);
            await _uow.CommitAsync();

            return appointment;
        }

        public async Task Delete(int id)
        {
            var appointment = GetQuery().FirstOrDefault(u => u.ID == id);

            _uow.Remove(appointment);
            await _uow.CommitAsync();
        }

        public IQueryable<Appointment> Get()
        {
            return GetQuery();
        }

        public Appointment GetAppointment(int id)
        {
            return GetQuery().FirstOrDefault(u => u.ID == id);
        }

        public async Task<Appointment> Update(AppointmentModel model)
        {
            var appointment = GetQuery().FirstOrDefault(x => x.ID == model.ID);

            appointment.DateTime = model.DateTime;
            appointment.DoctorID = model.DoctorID;
            appointment.PatientID = model.PatientID;
            appointment.AppointmentTakenDate = model.AppointmentTakenDate;
            appointment.AppointmentStatus = model.AppointmentStatus;
            appointment.ProcedureDescription = model.ProcedureDescription;
            appointment.ProcedureCost = model.ProcedureCost;
            appointment.ProcedureName = model.ProcedureName;

            await _uow.CommitAsync();
            return appointment;
        }

        private IQueryable<Appointment> GetQuery()
        {
            return _uow.Query<Appointment>();
        }
    }
}