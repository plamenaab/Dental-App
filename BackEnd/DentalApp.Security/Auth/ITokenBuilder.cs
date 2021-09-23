using System;

namespace DentalApp.Security.Auth
{
    public interface ITokenBuilder
    {
        string Build(string name, string role, DateTime expireDate);
    }
}
