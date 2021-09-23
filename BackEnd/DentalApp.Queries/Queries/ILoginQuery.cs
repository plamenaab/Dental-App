using System.Threading.Tasks;
using DentalApp.Api.Models.Login;
using DentalApp.Api.Models.Users;
using DentalApp.Data.Model;
using DentalApp.Queries.Models;

namespace DentalApp.Queries.Queries
{
    public interface ILoginQuery
    {
        UserWithToken Authenticate(string username, string password);

        Task<User> Register(RegisterModel model);

        Task ChangePassword(ChangeUserPasswordModel requestModel);
    }
}
