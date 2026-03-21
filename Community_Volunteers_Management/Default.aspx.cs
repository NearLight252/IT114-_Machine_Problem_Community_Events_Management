using Community_Volunteers_Management.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Community_Volunteers_Management
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEvents();
            }
        }

        private void LoadEvents()
        {
            List<Event> events = new List<Event>();
            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT TOP 3 * FROM Events ORDER BY EventDate DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    events.Add(new Event
                    {
                        EventID = (int)reader["EventID"],
                        EventName = reader["EventName"].ToString(),
                        EventDate = (DateTime)reader["EventDate"],
                        City = reader["City"].ToString(),
                        Barangay = reader["Barangay"].ToString(),
                        Description = reader["Description"].ToString(),
                        ImagePath = reader["ImagePath"].ToString(),
                        MaxVolunteers = (int)reader["MaxVolunteers"]
                    });
                }

                reader.Close();
            }

            rptEvents.DataSource = events;
            rptEvents.DataBind();
        }
    }
}