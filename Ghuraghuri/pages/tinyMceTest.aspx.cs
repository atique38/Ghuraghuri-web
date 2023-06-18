using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class tinyMceTest : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            con.Open();
            string content = Request.Form["hiddenField"];
            OracleCommand cmd = new OracleCommand("INSERT INTO TINY (text) VALUES (:content)", con);
            cmd.Parameters.Add(":content", OracleDbType.Clob).Value = content;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}