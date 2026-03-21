using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Community_Volunteers_Management
{
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }
        private void LoadEvents()
        {

            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();


                SqlDataAdapter daUpcoming = new SqlDataAdapter(
                    "SELECT * FROM Events WHERE Status = 'Upcoming' ORDER BY EventDate ASC", conn);
                DataTable dtUpcoming = new DataTable();
                daUpcoming.Fill(dtUpcoming);
                rptUpcoming.DataSource = dtUpcoming;
                rptUpcoming.DataBind();


                SqlDataAdapter daOngoing = new SqlDataAdapter(
                    "SELECT * FROM Events WHERE Status = 'On-going' ORDER BY EventDate ASC", conn);
                DataTable dtOngoing = new DataTable();
                daOngoing.Fill(dtOngoing);
                rptOngoing.DataSource = dtOngoing;
                rptOngoing.DataBind();


                SqlDataAdapter daPast = new SqlDataAdapter(
                    "SELECT * FROM Events WHERE Status = 'Concluded' ORDER BY EventDate DESC", conn);
                DataTable dtPast = new DataTable();
                daPast.Fill(dtPast);
                rptPast.DataSource = dtPast;
                rptPast.DataBind();
            }





        }

    }
}