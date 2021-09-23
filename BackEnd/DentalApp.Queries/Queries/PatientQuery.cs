using System.Linq;
using System.Threading.Tasks;
using DentalApp.Api.Models.Patient;
using DentalApp.Data.Access.DAL;
using DentalApp.Data.Model;

namespace DentalApp.Queries.Queries
{
    public class PatientQuery : IPatientQuery
    {
        private readonly IUnitOfWork _uow;

        public PatientQuery(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Delete(int id)
        {
            var patient = GetQuery().FirstOrDefault(u => u.ID == id);

            _uow.Remove(patient);
            await _uow.CommitAsync();
        }

        public DisplayPatientInfo DisplayPatientInfo(int id)
        {
            return GetQuery().Select(d => new DisplayPatientInfo()
            {
                ID = id,
                BirthDate = d.BirthDate,
                Email = d.Email,
                Gender = d.Gender,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Phone = d.Phone
            }).FirstOrDefault(u => u.ID == id);
        }

        public IQueryable<Patient> Get()
        {
            return GetQuery();
        }

        public Patient GetPatient(int id)
        {
            return GetQuery().FirstOrDefault(u => u.ID == id);
        }

        public async Task<Patient> Update(PatientModel model)
        {
            var patient = GetQuery().FirstOrDefault(x => x.ID == model.ID);

            patient.ID = model.ID;
            patient.Email = model.Email;
            patient.BirthDate = model.BirthDate;
            patient.Phone = model.Phone;
            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.Phone = model.Phone;
            patient.Address = model.Address;

            await _uow.CommitAsync();
            return patient;
        }

        private IQueryable<Patient> GetQuery()
        {
            return _uow.Query<Patient>();
        }
    }
}
