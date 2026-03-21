using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community_Volunteers_Management.Models
{
    public class VolunteerSignup
    {

        public int SignupID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public DateTime SignupDate { get; set; }

    }
}