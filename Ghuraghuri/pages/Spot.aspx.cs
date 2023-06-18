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
    public partial class WebForm17 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string qr = "select id,spot_name,spot_type,featured_photo from spot";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["spot_name"].ToString();
                    string type = reader["spot_type"].ToString();
                    string spot_id = reader["id"].ToString();

                    byte[] imageData = (byte[])reader["featured_photo"];
                    string base64Image = Convert.ToBase64String(imageData);
                    string imageUrl = "data:image/jpeg;base64," + base64Image;

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "t_slide";
                    div.Attributes["onclick"] = "spotClicked('" + spot_id + "')";

                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    div2.Attributes["class"] = "image";

                    HtmlGenericControl img = new HtmlGenericControl("img");
                    img.Attributes["src"] = imageUrl;
                    div2.Controls.Add(img);

                    HtmlGenericControl div3 = new HtmlGenericControl("div");
                    div3.Attributes["class"] = "content";

                    HtmlGenericControl h3 = new HtmlGenericControl("h3");
                    HtmlGenericControl p = new HtmlGenericControl("p");
                    h3.InnerText = name;
                    p.InnerText = type;

                    div3.Controls.Add(h3);
                    div3.Controls.Add(p);

                    div.Controls.Add(div2);
                    div.Controls.Add(div3);

                    div_container.Controls.Add(div);

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