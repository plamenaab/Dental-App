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
    public class AppointmentController : Controller
    {
        private readonly IAppointmentQuery _query;
        private readonly IAutoMapper _mapper;
        public AppointmentController(IAppointmentQuery query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpGet("getAllAppointments")]
        public ActionResult<List<AppointmentModel>> GetAllAppointments()
        {
            return Ok(_query.Get().ToList());
        }

        [HttpGet("{id}/getAppointment")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            return Ok(_query.GetAppointment(id));
        }

        [HttpPut("updateAppointment")]
        public ActionResult UpdateAppointment(AppointmentModel appointment)
        {
            return Ok(_query.Update(appointment));
        }

        [HttpPost("createAppointment")]
        public ActionResult CreateAppointment(AppointmentModel appointment)
        {
            return Ok(_query.Create(appointment));
        }

        [HttpDelete("{id}/deleteAppointment")]
        public ActionResult DeleteAppointment(int id)
        {
            return Ok(_query.Delete(id));
        }
    }
}
