using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["u_name"]!=null)
            {
                login_link.Visible = false;
                logout.Visible = true;
                profile_link.Visible = true;
            }
            else
            {
                login_link.Visible = true;
                logout.Visible = false;
                profile_link.Visible = false;
            }

            if (Session["isLogout"]!=null && (bool)Session["isLogout"])
            {
                login_link.Visible = true;
                logout.Visible = false;
                profile_link.Visible = false;
                Session["isLogout"] = false;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            login_link.Visible = true;
            logout.Visible = false;
            profile_link.Visible = false;
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Home.aspx");
        }

        protected void profile_link_ServerClick(object sender, EventArgs e)
        {
            Session["click"] = "dash";
            Response.Redirect("Dashboard.aspx");
        }
    }
}