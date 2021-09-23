using DentalApp.Api.Models.Doctor;
using DentalApp.Data.Model;
using DentalApp.Maps;
using DentalApp.Queries.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorQuery _query;
        private readonly IAutoMapper _mapper;

        public DoctorController(IDoctorQuery query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpGet("getAllDoctors")]
        public ActionResult<List<AppointmentModel>> GetAllDoctors()
        {
            return Ok(_query.Get());
        }

        [HttpGet("{id}/displayDoctorInfo")]
        public ActionResult<DisplayDoctorInfo> DisplayDoctorInfo(int id)
        {
            return Ok(_query.DisplayDoctorInfo(id));
        }

        [HttpGet("{id}/getDoctor")]
        public ActionResult<Doctor> GetDoctor(int id)
        {
            return Ok(_query.GetDoctor(id));
        }

        [HttpPut("updateDoctor")]
        public ActionResult UpdateDoctor(DoctorModel doctor)
        {
            return Ok(_query.Update(doctor));
        }

        [HttpDelete("{id}/deleteDoctor")]
        public ActionResult DeleteDoctor(int id)
        {
            return Ok(_query.Delete(id));
        }
    }
}
