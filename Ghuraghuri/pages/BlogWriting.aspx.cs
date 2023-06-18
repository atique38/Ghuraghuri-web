using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBlog_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string content = tiny.Text;
                string qr1 = "INSERT INTO blog (email,title,blog_content,posted_time,image) VALUES (:email, :title, :content, :time,:img)";

                OracleCommand cmd1 = new OracleCommand(qr1, con);

                byte[] imageData = featuredUpload.FileBytes;
                string email = Session["u_email"].ToString();
                cmd1.Parameters.Add(":email", OracleDbType.Varchar2).Value = email;
                cmd1.Parameters.Add(":title", OracleDbType.Varchar2).Value = BlogTitle.Text.ToString().Trim();
                cmd1.Parameters.Add(":content", OracleDbType.Clob).Value = content;
                cmd1.Parameters.Add(":time", OracleDbType.Date).Value = DateTime.Now;
                cmd1.Parameters.Add(":img", OracleDbType.Blob).Value = imageData;

                cmd1.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Response.Write("<script>alert('" + msg + "');</script>");
            }
        }
    }
}