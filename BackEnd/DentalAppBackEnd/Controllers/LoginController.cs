using System.Threading.Tasks;
using DentalApp.Api.Models.Login;
using DentalApp.Api.Models.Patient;
using DentalApp.Api.Models.Users;
using DentalApp.Filters;
using DentalApp.Maps;
using DentalApp.Queries.Models;
using DentalApp.Queries.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalApp.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginQuery _query;
        private readonly IAutoMapper _mapper;

        public LoginController(ILoginQuery query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpPost("Authenticate")]
        [ValidateModel]
        public UserWithToken Authenticate([FromBody] LoginModel model)
        {
            var result = _query.Authenticate(model.Username, model.Password);

            return result;
        }

        [HttpPost("Register")]
        [ValidateModel]
        public async Task<PatientModel> Register([FromBody] RegisterModel model)
        {
            var result = await _query.Register(model);
            var resultModel = _mapper.Map<PatientModel>(result);
            return resultModel;
        }

        [HttpPost("Password")]
        [ValidateModel]
        [Authorize]
        public async Task ChangePassword([FromBody] ChangeUserPasswordModel requestModel)
        {
            await _query.ChangePassword(requestModel);
        }
    }
}