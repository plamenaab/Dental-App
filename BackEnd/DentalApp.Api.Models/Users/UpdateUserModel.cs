using System.ComponentModel.DataAnnotations;

namespace DentalApp.Api.Models.Users
{
    public class UpdateUserModel
    {
        public UpdateUserModel()
        {

        }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Info { get; set; }

        public string Address { get; set; }

    }
}
