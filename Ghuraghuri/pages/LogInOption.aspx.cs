using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class LogInOption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UserLink_Click(object sender, EventArgs e)
        {
            
            Session["login_opt"] = "user";
            //Response.Write("<script>alert('" + Session["user_login"] + "');</script>");
            Response.Redirect("LogIn.aspx");
        }

        protected void AgencyLink_Click(object sender, EventArgs e)
        {
            
            Session["login_opt"] = "agency";
            Response.Redirect("LogIn.aspx");
        }

        protected void AdminLink_Click(object sender, EventArgs e)
        {
            
            Session["login_opt"] = "admin";
            Response.Redirect("LogIn.aspx");
        }
    }
}