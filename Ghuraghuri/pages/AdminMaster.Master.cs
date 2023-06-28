using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Ghuraghuri.pages
{
    public partial class test : System.Web.UI.MasterPage
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["click"]!=null && Session["click"].Equals("dash"))
            {
                List1.Attributes.Add("class", "active");
                //List1.Attributes.Remove("class");
            }
            else if(Session["click"] != null && Session["click"].Equals("acc"))
            {
                List2.Attributes.Add("class", "active");
                List1.Attributes.Remove("class");
                Menu_item.InnerText = "Account";
            }
            else if (Session["click"] != null && Session["click"].Equals("hist"))
            {
                List3.Attributes.Add("class", "active");
                List1.Attributes.Remove("class");
                Menu_item.InnerText = "Booking History";
            }
            else if (Session["click"] != null && Session["click"].Equals("blog"))
            {
                List7.Attributes.Add("class", "active");
                List1.Attributes.Remove("class");
                Menu_item.InnerText = "Bolg";
            }
            else if (Session["click"] != null && Session["click"].Equals("place"))
            {
                List8.Attributes.Add("class", "active");
                List1.Attributes.Remove("class");
                Menu_item.InnerText = "Add Place";
            }
            else if (Session["click"] != null && Session["click"].Equals("tour"))
            {
                List6.Attributes.Add("class", "active");
                List1.Attributes.Remove("class");
                Menu_item.InnerText = "Add Tour";
            }
            else if (Session["click"] != null && Session["click"].Equals("product"))
            {
                List10.Attributes.Add("class", "active");
                List1.Attributes.Remove("class");
                Menu_item.InnerText = "Add Product";
            }
            else if (Session["click"] != null && Session["click"].Equals("order_hist"))
            {
                List11.Attributes.Add("class", "active");
                List1.Attributes.Remove("class");
                Menu_item.InnerText = "Order History";
            }
            else if (Session["click"] != null && Session["click"].Equals("bookings"))
            {
                List12.Attributes.Add("class", "active");
                List1.Attributes.Remove("class");
                Menu_item.InnerText = "Bookings";
            }
            else if (Session["click"] != null && Session["click"].Equals("orders"))
            {
                List4.Attributes.Add("class", "active");
                List1.Attributes.Remove("class");
                Menu_item.InnerText = "Orders";
            }


            //navbar info
            string name="";
            if (Session["login_opt"].Equals("user"))
            {
                name = Session["u_name"].ToString();
                List6.Visible = false;
                List8.Visible=false;
                List10.Visible=false;
                List4.Visible=false;
                List11.Visible=true;
                List7.Visible = true;
                List3.Visible = true;
                List12.Visible = false;
                //Response.Write("<script>alert('" + name + "');</script>");
            }
            else if (Session["login_opt"].Equals("admin"))
            {
                name = "Admin";
                List8.Visible = true;
                List10.Visible = true;
                List6.Visible = false;
                List4.Visible = true;
                List11.Visible = false;
                List7.Visible = false;
                List3.Visible=false;
                List12.Visible = false;
            }
            else if (Session["login_opt"].Equals("agency"))
            {
                name = Session["ag_name"].ToString();
                List6.Visible = true;
                List8.Visible = false;
                List10.Visible = false;
                List4.Visible = false;
                List11.Visible = false;
                List7.Visible=false;
                List3.Visible = false;
                List12.Visible = true;
            }
            UserTxt.InnerText= name;
            setImage();
        }

      
        protected void Dashboard_ServerClick(object sender, EventArgs e)
        {
            
            Session["click"] = "dash";
            //List1.Attributes.Add("class", "active");
            Response.Redirect("Dashboard.aspx");
        }

        protected void Account_ServerClick(object sender, EventArgs e)
        {
           
            Session["click"] = "acc";
            Response.Redirect("Account.aspx");
        }

        protected void History_ServerClick(object sender, EventArgs e)
        {
            
            Session["click"] = "hist";
            Response.Redirect("History.aspx");
        }

        protected void Blog_ServerClick(object sender, EventArgs e)
        {
            Session["click"] = "blog";
            Response.Redirect("BlogWriting.aspx");
        }

        protected void Add_place_ServerClick(object sender, EventArgs e)
        {
            Session["click"] = "place";
            Response.Redirect("AddPlace.aspx");
        }

        protected void add_tour_ServerClick(object sender, EventArgs e)
        {
            Session["click"] = "tour";
            Response.Redirect("AddTour.aspx");
        }

        protected void Add_product_ServerClick(object sender, EventArgs e)
        {
            Session["click"] = "product";
            Response.Redirect("AddProduct.aspx");
        }

        protected void logoutBtn_ServerClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session["isLogout"] = true;
            Response.Redirect("Home.aspx");
        }

        protected void orderHist_ServerClick(object sender, EventArgs e)
        {
            Session["click"] = "order_hist";
            Response.Redirect("OrderHistory.aspx");
        }

        void setImage()
        {
            con.Open();
            string sql = "SELECT PROFILE_IMAGE FROM user_info where email=:em";
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.Parameters.Add(":em", OracleDbType.Varchar2).Value = Session["u_email"].ToString();
            OracleDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("PROFILE_IMAGE")))
                {
                    byte[] imageData = (byte[])reader["PROFILE_IMAGE"];
                    string base64Image = Convert.ToBase64String(imageData);
                    string imageUrl = "data:image/jpeg;base64," + base64Image;
                    //ClientScript.RegisterStartupScript(this.GetType(), "image", "setImage('" + imageUrl + "');", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "image2", "setNavImage('" + imageUrl + "');", true);
                    navImg.Attributes["src"] = imageUrl;
                }
                else
                {
                    navImg.Attributes["src"] = "../images/profile.png";
                }
            }
            con.Close();
        }

        protected void bokings_ServerClick(object sender, EventArgs e)
        {
            Session["click"] = "bookings";
            Response.Redirect("Bookings.aspx");
        }

        protected void orders_ServerClick(object sender, EventArgs e)
        {
            Session["click"] = "orders";
            Response.Redirect("Orders.aspx");
        }
    }
}