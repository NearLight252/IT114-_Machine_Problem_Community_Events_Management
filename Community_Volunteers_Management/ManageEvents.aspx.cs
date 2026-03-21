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
    public partial class ManageEvents : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
                {
                    Response.Redirect("Login.aspx");
                }

                LoadEvents();

            }

        }

        private void LoadEvents()
        {
            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT e.*, 
                           ISNULL(v.TotalVolunteers, 0) AS TotalVolunteers
                    FROM Events e
                    LEFT JOIN (
                        SELECT EventID, COUNT(*) AS TotalVolunteers
                        FROM VolunteerSignups
                        GROUP BY EventID
                    ) v ON e.EventID = v.EventID
                    ORDER BY e.EventDate DESC";


                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                gvEvents.DataSource = reader;
                gvEvents.DataBind();
                reader.Close();


            }

        }


        // Setting dropdown value based on current status
        protected void gvEvents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlStatus");

                string status = DataBinder.Eval(e.Row.DataItem, "Status")?.ToString() ?? "Upcoming";

                if (ddl.Items.FindByValue(status) != null)
                {
                    ddl.SelectedValue = status;
                }

            }

        }


        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            int eventId = Convert.ToInt32(gvEvents.DataKeys[row.RowIndex].Value);
            string newStatus = ddl.SelectedValue;

            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Events SET Status=@Status WHERE EventID=@EventID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@EventID", eventId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadEvents();

        }



        protected void btnAddEvent_Click(object sender, EventArgs e)
        {

            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                string query = @"INSERT INTO Events 
                (EventName, EventDate, City, Barangay, Description, ImagePath, MaxVolunteers, Status)
                VALUES (@EventName, @EventDate, @City, @Barangay, @Description, @ImagePath, @MaxVolunteers, 'Upcoming')";



                string imagePath = string.IsNullOrWhiteSpace(txtImagePath.Text)
                ? "Images/default.jpg"
                : txtImagePath.Text.Trim();



                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventName", txtEventName.Text.Trim());
                cmd.Parameters.AddWithValue("@EventDate", DateTime.Parse(txtEventDate.Text.Trim()));
                cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                cmd.Parameters.AddWithValue("@Barangay", txtBarangay.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);
                cmd.Parameters.AddWithValue("@MaxVolunteers", int.Parse(txtMaxVolunteers.Text.Trim()));



                conn.Open();
                cmd.ExecuteNonQuery();
                lblAddEventMessage.Text = "Event added successfully!";

                LoadEvents(); 


            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int eventId = Convert.ToInt32(btn.CommandArgument);

            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // For deleting related signups first due to foreign key restrains
                SqlCommand deleteSignups = new SqlCommand(
                    "DELETE FROM VolunteerSignups WHERE EventID=@EventID", conn);
                deleteSignups.Parameters.AddWithValue("@EventID", eventId);
                deleteSignups.ExecuteNonQuery();


                // Then finally deletes the event
                SqlCommand deleteEvent = new SqlCommand(
                    "DELETE FROM Events WHERE EventID=@EventID", conn);
                deleteEvent.Parameters.AddWithValue("@EventID", eventId);
                deleteEvent.ExecuteNonQuery();


            }

            
            LoadEvents();
        }




    }
}