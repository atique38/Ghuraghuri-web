using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string spanId1 = "counter1";
            string spanId2 = "counter2";
            string spanId3 = "counter3";
            ClientScript.RegisterStartupScript(this.GetType(), "count1", "counter('" + spanId1 + "'," + 0 + "," + 400 + "," + 3000 + ");", true);
            ClientScript.RegisterStartupScript(this.GetType(), "count2", "counter('" + spanId2 + "'," + 0 + "," + 50 + "," + 3000 + ");", true);
            ClientScript.RegisterStartupScript(this.GetType(), "count3", "counter('" + spanId3 + "'," + 0 + "," + 200 + "," + 3000 + ");", true);
        }

    }
    
}