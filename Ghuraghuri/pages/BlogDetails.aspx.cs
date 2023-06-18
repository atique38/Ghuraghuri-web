using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string data = Request.QueryString["data"];
                string sql = "SELECT * FROM blog where id='" + data + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string blog_title, description,email;
                    
                    blog_title = reader["title"].ToString();
                    description = reader["blog_content"].ToString();
                    email = reader["email"].ToString();

                    byte[] imageData = (byte[])reader["image"];
                    string base64Image = Convert.ToBase64String(imageData);
                    string imageUrl = "data:image/jpeg;base64," + base64Image;

                    DateTime dateTime = reader.GetDateTime(4);
                    string date = dateTime.ToString("dd MMM, yyyy");

                    string qr2 = "select name from user_info where email='" + email + "'";
                    OracleCommand cmd2= new OracleCommand(qr2, con);
                    OracleDataReader reader2= cmd2.ExecuteReader();

                    string authorName = "";
                    if(reader2.Read())
                    {
                        authorName = reader2["name"].ToString();
                    }
                    blg_title.InnerText = blog_title;
                    author.InnerText = "By "+authorName+ "- " + date;
                    blogImg.Src= imageUrl;
                    blog_info.InnerHtml = description;

                    
                }
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