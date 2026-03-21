using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community_Volunteers_Management.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int MaxVolunteers { get; set; }


    }
}