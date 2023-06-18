using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class ProfileUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void Dashboard_Click(object sender, EventArgs e)
        {
            Dashboard.Attributes.Add("class", "active");
            Account.Attributes.Add("class", "sidebar_link");
            
        }

        protected void Account_Click(object sender, EventArgs e)
        {
            Account.Attributes.Add("class", "active");
        }

        protected void History_Click(object sender, EventArgs e)
        {
            History.Attributes.Add("class", "active");
        }

        protected void Orders_Click(object sender, EventArgs e)
        {
            Orders.Attributes.Add("class", "active");
        }

        protected void Reviews_Click(object sender, EventArgs e)
        {
            Reviews.Attributes.Add("class", "active");
        }

        protected void AddTour_Click(object sender, EventArgs e)
        {
            AddTour.Attributes.Add("class", "active");
        }

        protected void Approvals_Click(object sender, EventArgs e)
        {
            Approvals.Attributes.Add("class", "active");
        }

        protected void Bookings_Click(object sender, EventArgs e)
        {
            Bookings.Attributes.Add("class", "active");
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            LogOut.Attributes.Add("class", "active");
        }

        protected void Blog_Click(object sender, EventArgs e)
        {
            Blog.Attributes.Add("class", "active");
        }
    }
}