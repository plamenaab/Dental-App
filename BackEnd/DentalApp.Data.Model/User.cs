using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace DentalApp.Data.Model
{
    public class User
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public virtual Role Role { get; set; }
    }
}
