using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community_Volunteers_Management.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


    }
}