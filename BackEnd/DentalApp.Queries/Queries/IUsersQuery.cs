using System.Linq;
using System.Threading.Tasks;
using DentalApp.Api.Models.Users;
using DentalApp.Data.Model;

namespace DentalApp.Queries.Queries
{
    public interface IUsersQuery
    {
        IQueryable<User> Get();

        User Get(int id);

        Task<User> Create(CreateUserModel model);

        Task<User> Update(int id, UpdateUserModel model);

        Task Delete(int id);

        Task ChangePassword(int id, ChangeUserPasswordModel model);
    }
}
