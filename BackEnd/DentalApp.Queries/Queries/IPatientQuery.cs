using System.Linq;
using System.Threading.Tasks;
using DentalApp.Api.Models.Doctor;
using DentalApp.Api.Models.Patient;
using DentalApp.Data.Model;

namespace DentalApp.Queries.Queries
{
    public interface IPatientQuery
    {
        IQueryable<Patient> Get();

        Patient GetPatient(int id);

        DisplayPatientInfo DisplayPatientInfo(int id);

        Task<Patient> Update(PatientModel model);

        Task Delete(int id);
    }
}
