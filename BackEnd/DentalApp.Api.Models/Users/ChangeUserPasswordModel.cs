using System.ComponentModel.DataAnnotations;

namespace DentalApp.Api.Models.Users
{
    public class ChangeUserPasswordModel
    {
        [Required]
        public string Password { get; set; }
    }
}
