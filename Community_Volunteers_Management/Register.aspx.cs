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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtDOB.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtCity.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblMessage.Text = "Please fill out all fields.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["CommunityDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"INSERT INTO Users 
                (FirstName, LastName, DateOfBirth, Email, PhoneNumber, City, Password)
                VALUES 
                (@FirstName, @LastName, @DOB, @Email, @Phone, @City, @Password)";



                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@DOB", DateTime.Parse(txtDOB.Text));
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);


                // This sets the newly added account as the user in the session
                try
                {
                    conn.Open();

                    int newUserId = Convert.ToInt32(cmd.ExecuteScalar());


                    Session["UserID"] = newUserId;
                    Session["FullName"] = txtFirstName.Text + " " + txtLastName.Text; //Was supposed to do something with this, forgot what

                    // default role for new registrations
                    Session["UserRole"] = "User";


                    Response.Redirect("Default.aspx");
                }


                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        lblMessage.Text = "Email already exists. Please use another.";
                    }
                    else
                    {
                        lblMessage.Text = "Database error occurred.";
                    }



                }


            }


        }
    }
}