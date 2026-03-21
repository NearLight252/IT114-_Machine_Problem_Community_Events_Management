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
    public partial class EventDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int eventId;


                if (!int.TryParse(Request.QueryString["EventID"], out eventId))
                {

                    Response.Redirect("Events.aspx");

                }

                hfEventID.Value = eventId.ToString(); 
                LoadEventDetails(eventId);


            }


        }




        private void LoadEventDetails(int eventId)
        {

            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                SELECT e.*, ISNULL(v.CountParticipants, 0) AS CurrentParticipants
                FROM Events e
                LEFT JOIN (
                    SELECT EventID, COUNT(*) AS CountParticipants
                    FROM VolunteerSignups
                    GROUP BY EventID
                ) v ON e.EventID = v.EventID
                WHERE e.EventID=@EventID";



                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventID", eventId);



                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.Read())
                {
                    lblEventName.Text = reader["EventName"].ToString();
                    lblEventDate.Text = Convert.ToDateTime(reader["EventDate"]).ToString("MMMM dd, yyyy");
                    lblDescription.Text = reader["Description"].ToString();
                    lblLocation.Text = reader["Barangay"] + ", " + reader["City"];
                    lblMaxVolunteers.Text = reader["MaxVolunteers"].ToString();
                    lblCurrentVolunteers.Text = reader["CurrentParticipants"].ToString();



                    int maxVol = Convert.ToInt32(reader["MaxVolunteers"]);
                    int current = Convert.ToInt32(reader["CurrentParticipants"]);


                    if (current >= maxVol)
                        btnJoin.Enabled = false;


                    string imagePath = reader["ImagePath"].ToString();
                    if (string.IsNullOrEmpty(imagePath))
                        imgEvent.ImageUrl = "Images/default.jpg"; 

                    else
                        imgEvent.ImageUrl = imagePath; 




                    imgEvent.AlternateText = lblEventName.Text;
                    imgEvent.Visible = true;


                }


                reader.Close();

            }


        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            int userId = Convert.ToInt32(Session["UserID"]);
            int eventId = int.Parse(hfEventID.Value);



            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {



                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM VolunteerSignups WHERE UserID=@UserID AND EventID=@EventID", conn);
                checkCmd.Parameters.AddWithValue("@UserID", userId);
                checkCmd.Parameters.AddWithValue("@EventID", eventId);


                conn.Open();
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    btnJoin.Text = "Already Joined";
                    btnJoin.Enabled = false;
                    return;
                }


                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO VolunteerSignups (UserID, EventID) VALUES (@UserID, @EventID)", conn);
                insertCmd.Parameters.AddWithValue("@UserID", userId);
                insertCmd.Parameters.AddWithValue("@EventID", eventId);
                insertCmd.ExecuteNonQuery();


                btnJoin.Text = "Joined!";
                btnJoin.Enabled = false;
                lblCurrentVolunteers.Text = (Convert.ToInt32(lblCurrentVolunteers.Text) + 1).ToString();


            }

        }
    }
}