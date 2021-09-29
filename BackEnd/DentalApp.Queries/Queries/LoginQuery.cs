
using System;
using System.Linq;
using System.Threading.Tasks;
using DentalApp.Api.Common.Exceptions;
using DentalApp.Api.Models.Login;
using DentalApp.Api.Models.Users;
using DentalApp.Data.Access.DAL;
using DentalApp.Data.Access.Helpers;
using DentalApp.Data.Model;
using DentalApp.Queries.Models;
using DentalApp.Security;
using DentalApp.Security.Auth;
using Microsoft.EntityFrameworkCore;

namespace DentalApp.Queries.Queries
{
    public class LoginQuery : ILoginQuery
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IUsersQuery _usersQuery;
        private readonly ISecurityContext _context;
        private Random _random;

        public LoginQuery(IUnitOfWork uow, ITokenBuilder tokenBuilder, IUsersQuery usersQuery, ISecurityContext context)
        {
            _random = new Random();
            _uow = uow;
            _tokenBuilder = tokenBuilder;
            _usersQuery = usersQuery;
            _context = context;
        }

        public UserWithToken Authenticate(string username, string password)
        {
            var user = (from u in _uow.Query<Patient>()
                        where u.UserName == username
                        select u)
                .Include(x => x.Role)
                .FirstOrDefault();

            if (user == null)
            {
                throw new BadRequestException("username/password aren't right");
            }

            if (string.IsNullOrWhiteSpace(password) || !user.Password.VerifyWithBCrypt(password))
            {
                throw new BadRequestException("username/password aren't right");
            }

            var expiresIn = DateTime.Now + TokenAuthOption.ExpiresSpan;
            var token = _tokenBuilder.Build(user.UserName, user.Role.Name, expiresIn);

            return new UserWithToken
            {
                ExpiresAt = expiresIn,
                Token = token,
                User = user
            };
        }

        public async Task<User> Register(RegisterModel model)
        {
            var requestModel = new CreateUserModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Username = model.Username
            };

            var user = await _usersQuery.Create(requestModel);
            return user;
        }

        public async Task ChangePassword(ChangeUserPasswordModel requestModel)
        {
            await _usersQuery.ChangePassword(_context.User.ID, requestModel);
        }
    }
}