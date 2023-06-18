using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string qr = "select * from blog";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string bloger_email, blog_title, description, id;
                    id = reader["id"].ToString();
                    bloger_email = reader["email"].ToString();
                    blog_title = reader["title"].ToString();
                    description = reader["blog_content"].ToString();
                    string plaintext = Regex.Replace(description, "<.*?>", String.Empty);
                    string cutText = plaintext.Length <= 105 ? plaintext : plaintext.Substring(0, 105) + "...";

                    DateTime dateTime = reader.GetDateTime(4);
                    string date = dateTime.ToString("dd MMM, yyyy");

                    byte[] imageData = (byte[])reader["image"];
                    string base64Image = Convert.ToBase64String(imageData);
                    string imageUrl = "data:image/jpeg;base64," + base64Image;

                    string qr2 = "select displayname from user_info where email='" + bloger_email + "'";
                    OracleCommand cmd2 = new OracleCommand(qr2, con);
                    OracleDataReader reader2 = cmd2.ExecuteReader();

                    string userName = "";
                    if (reader2.Read())
                    {
                        userName = reader2["displayname"].ToString();
                    }

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "slide";

                    HtmlGenericControl img1 = new HtmlGenericControl("img");
                    img1.Attributes["src"] = imageUrl;
                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    div2.Attributes["class"] = "icon";
                    HtmlGenericControl a1 = new HtmlGenericControl("a");
                    HtmlGenericControl a2 = new HtmlGenericControl("a");
                    HtmlGenericControl i1 = new HtmlGenericControl("i");
                    HtmlGenericControl i2 = new HtmlGenericControl("i");
                    HtmlGenericControl span = new HtmlGenericControl("span");
                    HtmlGenericControl span2 = new HtmlGenericControl("span");
                    i1.Attributes["class"] = "fa-solid fa-calendar-days";
                    i2.Attributes["class"] = "fa-solid fa-user";

                    span.InnerText = date;
                    span2.InnerText = userName;
                    a1.Controls.Add(i1);
                    a1.Controls.Add(span);
                    a2.Controls.Add(i2);
                    a2.Controls.Add(span2);
                    div2.Controls.Add(a1);
                    div2.Controls.Add(a2);

                    HtmlGenericControl h3 = new HtmlGenericControl("h3");
                    HtmlGenericControl p = new HtmlGenericControl("p");
                    HtmlGenericControl a3 = new HtmlGenericControl("a");

                    h3.InnerText = blog_title;
                    p.Attributes["style"] = "color:black;";
                    p.InnerText = cutText;
                    a3.Attributes["class"] = "read_btn";
                    a3.Attributes["onclick"] = "blogClicked('" + id + "')";
                    a3.InnerText = "Read More";

                    div.Controls.Add(img1);
                    div.Controls.Add(div2);
                    div.Controls.Add(h3);
                    div.Controls.Add(p);
                    div.Controls.Add(a3);

                    blog_container.Controls.Add(div);

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