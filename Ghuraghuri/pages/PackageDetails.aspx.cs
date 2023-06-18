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
    public partial class WebForm12 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Panel1.Visible = false;
                Calendar1.VisibleDate = DateTime.Today;
                Calendar1.DayRender += Calendar1_DayRender;
            }
            try
            {
                con.Open();
                string data = Request.QueryString["data"];
                string sql = "SELECT * FROM tour where id='" + data + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                //cmd.Parameters.Add(":spot_id", OracleDbType.Int32).Value = data;
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["tour_name"].ToString();
                    //Response.Write("<script>alert('" + name + "');</script>");
                    string agency = reader["agency_email"].ToString();
                    string price = reader["price"].ToString();
                    string duration = reader["tour_duration"].ToString();
                    string details = reader["description"].ToString();
                    string rating = reader["ratings"].ToString();

                    string query = "SELECT agency_name FROM agency_info where email='"+agency+"'";
                    OracleCommand command = new OracleCommand(query, con);
                    string agency_name = Convert.ToString(command.ExecuteScalar());

                    spt_name.InnerText=name;
                    pack_rate.InnerText=rating;
                    Small1.InnerText = agency_name;
                    pack_price.InnerText = price+"tk";
                    tour_duration.InnerText = duration;

                    package_info.InnerHtml = details;
                    string qr = "select * from tour_gallery where id='" + data + "'";
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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            selected_date.InnerText=Calendar1.SelectedDate.ToString("dd MMM, yyyy");
            Calendar1.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if(Calendar1.Visible)
            {
                Calendar1.Visible=false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void ApplyBtn_Click(object sender, EventArgs e)
        {
            touristNum.InnerText=TextBox1.Text+ " persons";
            Panel1.Visible = false;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if(Panel1.Visible)
            {
                Panel1.Visible=false;
            }
            else
            {
                Panel1.Visible = true;
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}