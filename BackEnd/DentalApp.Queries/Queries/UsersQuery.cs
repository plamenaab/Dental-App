using System.Linq;
using System.Threading.Tasks;
using DentalApp.Api.Common.Exceptions;
using DentalApp.Api.Models.Common;
using DentalApp.Api.Models.Users;
using DentalApp.Data.Access.DAL;
using DentalApp.Data.Access.Helpers;
using DentalApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DentalApp.Queries.Queries
{
    public class UsersQuery : IUsersQuery
    {
        private readonly IUnitOfWork _uow;

        public UsersQuery(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<User> Get()
        {
            var query = GetQuery();

            return query;
        }

        private IQueryable<User> GetQuery()
        {
            return _uow.Query<User>();
        }

        public User Get(int id)
        {
            var user = GetQuery().FirstOrDefault(x => x.ID == id);

            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }

            return user;
        }

        public async Task<User> Create(CreateUserModel model)
        {
            var username = model.Username.Trim();

            if (GetQuery().Any(u => u.UserName == username))
            {
                throw new BadRequestException("The username is already in use");
            }

            var user = new User
            {
                UserName = model.Username.Trim(),
                Password = model.Password.Trim().WithBCrypt(),
                FirstName = model.FirstName.Trim(),
                LastName = model.LastName.Trim(),
            };

            _uow.Add(user);
            await _uow.CommitAsync();

            return user;
        }


        public async Task<User> Update(int id, UpdateUserModel model)
        {
            var user = GetQuery().FirstOrDefault(x => x.ID == id);

            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Address = model.Address;
            
            await _uow.CommitAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var user = GetQuery().FirstOrDefault(u => u.ID == id);

            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }
            //abstration of data layer.method that removes
            _uow.Remove(user);
            await _uow.CommitAsync();
        }

        public async Task ChangePassword(int id, ChangeUserPasswordModel model)
        {
            var user = Get(id);
            user.Password = model.Password.WithBCrypt();
            await _uow.CommitAsync();
        }
    }
}
