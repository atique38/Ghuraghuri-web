using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class SignupOption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UserSignup_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Session["signup_opt"] = "user";
            Response.Redirect("SignUpUser.aspx");
        }

        protected void AgencySignup_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Session["signup_opt"] = "user";
            Response.Redirect("SignUpAgency.aspx");
        }
    }
}