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
        string pckName = "";
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

                    Constant.email = agency;

                    pckName = name;
                    string query = "SELECT agency_name FROM agency_info where email='" + agency + "'";
                    OracleCommand command = new OracleCommand(query, con);
                    string agency_name = Convert.ToString(command.ExecuteScalar());

                    spt_name.InnerText = name;
                    pack_rate.InnerText = rating;
                    Small1.InnerText = agency_name;
                    pack_price.InnerText = price + "tk";
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
            selected_date.InnerText = Calendar1.SelectedDate.ToString("dd MMM, yyyy");
            Calendar1.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void ApplyBtn_Click(object sender, EventArgs e)
        {
            touristNum.InnerText = TextBox1.Text;
            Panel1.Visible = false;
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

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }

        protected void BookBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["login_opt"] != null && (Session["login_opt"].Equals("agency") || Session["login_opt"].Equals("admin")))
                {
                    error.Text = "Please log in as user to buy something";
                }
                else if (Session["login_opt"] != null && Session["login_opt"].Equals("user"))
                {
                    if (Session["u_email"] != null)
                    {
                        if (selected_date.InnerText.Equals("Select Date"))
                        {
                            error.Text = "Please Select Journey Date";
                        }
                        else if (touristNum.InnerText.Equals("Total Persons"))
                        {
                            error.Text = "Please Select Number of Tourist";
                        }
                        else
                        {
                            bookTour();
                        }
                    }
                    else
                    {
                        error.Text = "Please Log in First";
                    }
                }
                else
                {
                    error.Text = "Please Log in First";
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                error.Text = msg;
            }


        }

        void bookTour()
        {
            try
            {
                string id = Request.QueryString["data"];
                con.Open();
                string qr = "insert into booking values(:t_id,:umail,:jrdate,:bkdate,:tourist_no,:pr,:st,:name,:ag_email)";
                OracleCommand cmd=new OracleCommand(qr,con);
                cmd.Parameters.Add(":t_id", OracleDbType.Int32).Value =Convert.ToInt32(id);
                cmd.Parameters.Add(":umail", OracleDbType.Varchar2).Value = Session["u_email"].ToString();
                cmd.Parameters.Add(":jrdate", OracleDbType.Varchar2).Value = selected_date.InnerText;
                cmd.Parameters.Add(":bkdate", OracleDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add(":tourist_no", OracleDbType.Int32).Value =Convert.ToInt32(touristNum.InnerText);
                cmd.Parameters.Add(":pr", OracleDbType.Int64).Value =Convert.ToInt64(pack_price.InnerText.Replace("tk",""));
                cmd.Parameters.Add(":st", OracleDbType.Varchar2).Value = "Pending";
                cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = pckName;
                cmd.Parameters.Add(":ag_email", OracleDbType.Varchar2).Value = Constant.email;
                int x=cmd.ExecuteNonQuery();

                if(x > 0)
                {
                    done.Text = "Successful! You can check booking status in Booking History page";
                }
                con.Close();
            }
            catch(Exception ex)
            {
                string msg=ex.Message;
                error.Text = msg;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int qnt = Convert.ToInt32(TextBox1.Text);

            if (qnt <= 0)
            {
                TextBox1.Text = "1";
            }
        }
    }
}