using AutoMapper;
using DentalApp.Api.Models.Users;
using DentalApp.Queries.Models;

namespace DentalApp.Maps
{
    public class UserWithTokenMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<UserWithToken, UserWithTokenModel>();
        }
    }
}
