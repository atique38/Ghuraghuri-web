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
    public partial class WebForm10 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string data = Request.QueryString["data"];
                string sql = "SELECT * FROM spot where id='" + data + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                //cmd.Parameters.Add(":spot_id", OracleDbType.Int32).Value = data;
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["spot_name"].ToString();
                    //Response.Write("<script>alert('" + name + "');</script>");
                    string type = reader["spot_type"].ToString();
                    string content= reader["description"].ToString();
                    string location = reader["location"].ToString();

                   

                    spt_name.InnerText = name;
                    spt_type.InnerText = type;
                    spt_location.InnerText =" "+ location;

                    spt_info.InnerHtml= content;

                    string qr = "select * from gallery where id='" + data + "'";
                    OracleCommand cmd2=new OracleCommand(qr, con);
                    OracleDataReader reader1 = cmd2.ExecuteReader();
                    while (reader1.Read())
                    {
                        byte[] imageData = (byte[])reader1["image_data"];
                        string base64Image = Convert.ToBase64String(imageData);
                        string imageUrl = "data:image/jpeg;base64," + base64Image;
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes["class"] = "swiper-slide";

                        HtmlGenericControl img = new HtmlGenericControl("img");
                        img.Attributes["src"] = imageUrl;

                        div.Controls.Add(img);

                        div_container.Controls.Add(div);
                    }
                   


                }
                con.Close();
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                Response.Write("<script>alert('" + msg + "');</script>");
            }
           
        }
    }
}