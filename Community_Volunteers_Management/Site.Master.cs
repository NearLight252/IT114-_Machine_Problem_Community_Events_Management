using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Community_Volunteers_Management
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NavbarLinks();
            }
        }

        private void NavbarLinks()
        {
            // Checks if user is logged in
            bool isLoggedIn = Session["UserID"] != null;
            string role = isLoggedIn ? Session["Role"]?.ToString() : "";


            lnkJoinUs.Visible = !isLoggedIn;       
            lnkLogin.Visible = !isLoggedIn;        
            lnkLogout.Visible = isLoggedIn;        


            // Showa Manage Events only for Admin
            lnkManageEvents.Visible = isLoggedIn && role == "Admin";
        }
    }
}
