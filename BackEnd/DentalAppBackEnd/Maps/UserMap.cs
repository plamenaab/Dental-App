using System.Linq;
using AutoMapper;
using DentalApp.Api.Models.Users;
using DentalApp.Data.Model;

namespace DentalApp.Maps
{
    public class UserMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            //var map = configuration.CreateMap<User, UserModel>();
          //  map.ForMember(x => x.Roles, x => x.MapFrom(u => u.Roles.Select(r => r.Role.Name).ToArray()));
        }
    }
}
