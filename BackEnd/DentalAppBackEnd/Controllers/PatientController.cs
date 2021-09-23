using DentalApp.Api.Models.Patient;
using DentalApp.Data.Model;
using DentalApp.Filters;
using DentalApp.Maps;
using DentalApp.Queries.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientQuery _query;
        private readonly IAutoMapper _mapper;

        public PatientController(IPatientQuery query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpGet("getAllPatients")]
        public ActionResult <List<PatientModel>> GetAllPatients()
        {
            return Ok(_query.Get());
        }
       
        [HttpGet("{id}/displayPatientInfo")]
        public ActionResult<DisplayPatientInfo>DisplayPatientInfo(int id)
        {
            return Ok(_query.DisplayPatientInfo(id));
        }
        [HttpGet("{id}/getPatient")]
        public ActionResult<Patient> GetPatient(int id)
        {
            return Ok(_query.GetPatient(id));
        }
        [HttpPut("updatePatient")]
        public ActionResult UpdatePatient(PatientModel patient)
        {
            return Ok(_query.Update(patient));
        }
        
        [HttpDelete("{id}/deletePatient")]
        public ActionResult DeletePatient(int id)
        {
            return Ok(_query.Delete(id));
        }
    }
}
