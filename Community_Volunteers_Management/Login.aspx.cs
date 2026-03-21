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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();


            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {


                string query = "SELECT UserID, Role, FirstName, LastName FROM Users WHERE Email=@Email AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password.Trim());



                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    Session["UserID"] = reader["UserID"];



                    string fullName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                    Session["FullName"] = fullName;

                    Session["Role"] = reader["Role"];



                    // This is for Redirecting based on role if admin or user

                    if (reader["Role"].ToString().Equals("Admin", StringComparison.OrdinalIgnoreCase))
                        Response.Redirect("ManageEvents.aspx");

                    else
                        Response.Redirect("Default.aspx");


                }
                else
                {
                    lblMessage.Text = "Invalid email or password.";
                }


                reader.Close();

            }
        }
    }
}