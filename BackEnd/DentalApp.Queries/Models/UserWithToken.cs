using System;
using DentalApp.Data.Model;

namespace DentalApp.Queries.Models
{
    public class UserWithToken
    {
        public string Token { get; set; }

        public User User { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
