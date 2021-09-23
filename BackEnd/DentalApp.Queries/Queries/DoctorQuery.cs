using System.Linq;
using System.Threading.Tasks;
using DentalApp.Api.Models.Doctor;
using DentalApp.Data.Access.DAL;
using DentalApp.Data.Model;

namespace DentalApp.Queries.Queries
{
    public class DoctorQuery : IDoctorQuery
    {
        private readonly IUnitOfWork _uow;

        public DoctorQuery(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Delete(int id)
        {
            var doctor = GetQuery().FirstOrDefault(u => u.ID == id);

            _uow.Remove(doctor);
            await _uow.CommitAsync();
        }

        public DisplayDoctorInfo DisplayDoctorInfo(int id)
        {
            return GetQuery().Select(d => new DisplayDoctorInfo()
            {
                ID = id,
                Address = d.Address,
                Email = d.Email,
                EndTime = d.EndTime,
                FirstConsultationFee = d.FirstConsultationFee,
                FirstName = d.FirstName,
                FollowupConsultationFee = d.FollowupConsultationFee,
                LastName = d.LastName,
                Phone = d.Phone,
                ProfessionalStatement = d.ProfessionalStatement,
                SpecialtyName = d.SpecialtyName,
                StartTime = d.StartTime
            }).FirstOrDefault(u => u.ID == id);
        }

        public IQueryable<Doctor> Get()
        {
            return GetQuery();
        }

        public Doctor GetDoctor(int id)
        {
            return GetQuery().FirstOrDefault(u => u.ID == id);
        }

        public async Task<Doctor> Update(DoctorModel model)
        {
            var doctor = GetQuery().FirstOrDefault(x => x.ID == model.ID);

            doctor.ID = model.ID;
            doctor.Address = model.Address;
            doctor.Email = model.Email;
            doctor.EndTime = model.EndTime;
            doctor.FirstConsultationFee = model.FirstConsultationFee;
            doctor.FirstName = model.FirstName;
            doctor.FollowupConsultationFee = model.FollowupConsultationFee;
            doctor.LastName = model.LastName;
            doctor.Phone = model.Phone;
            doctor.ProfessionalStatement = model.ProfessionalStatement;
            doctor.SpecialtyName = model.SpecialtyName;
            doctor.StartTime = model.StartTime;

            await _uow.CommitAsync();
            return doctor;
        }

        private IQueryable<Doctor> GetQuery()
        {
            return _uow.Query<Doctor>();
        }
    }
}