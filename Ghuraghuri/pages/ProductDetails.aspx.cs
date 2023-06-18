using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel1.Visible = false;
            }
            try
            {
                con.Open();
                string data = Request.QueryString["data"];
                string sql = "SELECT * FROM product where id='" + data + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                //cmd.Parameters.Add(":spot_id", OracleDbType.Int32).Value = data;
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["PRODUCT_NAME"].ToString();
                    //Response.Write("<script>alert('" + name + "');</script>");
                    
                    string price = reader["PRICE"].ToString();
                    
                    string details = reader["PRODUCT_DETAILS"].ToString();
                    string rating = reader["RATINGS"].ToString();

                    pdct_name.InnerText = name;
                    pdct_rate.InnerText = rating;
                    
                    pdct_price.InnerText = price + "tk";
                    

                    product_info.InnerHtml = details;
                    string qr = "select * from product_gallery where id='" + data + "'";
                    OracleCommand cmd2 = new OracleCommand(qr, con);
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
            catch (Exception ex)
            {
                string msg = ex.Message;
                Response.Write("<script>alert('" + msg + "');</script>");
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (Panel1.Visible)
            {
                Panel1.Visible = false;
            }
            else
            {
                Panel1.Visible = true;
            }
        }

        protected void ApplyBtn_Click(object sender, EventArgs e)
        {
            pdctCount.InnerText = TextBox1.Text + " items";
            Panel1.Visible = false;
        }

        protected void BuyBtn_Click(object sender, EventArgs e)
        {

        }

        protected void BookBtn_Click(object sender, EventArgs e)
        {

        }
    }
}