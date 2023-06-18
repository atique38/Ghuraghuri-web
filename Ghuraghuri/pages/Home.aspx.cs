using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text;

namespace Ghuraghuri.pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["u_name"] != null)
            {
               started_btn1.Visible = false;
               started_btn2.Visible = false;
               started_btn3.Visible = false;
            }
            else
            {
                started_btn1.Visible = true;
                started_btn2.Visible = true;
                started_btn3.Visible = true;
            }
            spotData();
            blogData();
            packageData();
            shopData();
        }
        void spotData()
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
                    div.Attributes["class"] = "swiper-slide t_slide";
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

        void blogData()
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
                    if(reader2.Read())
                    {
                        userName= reader2["displayname"].ToString();
                    }

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "swiper-slide slide";

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
        void packageData()
        {
            try
            {
                con.Open();
                string qr = "select * from tour";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string email, title, id,cost,duration,rating;
                    id = reader["id"].ToString();
                    email = reader["agency_email"].ToString();
                    title = reader["tour_name"].ToString();
                    //details = reader["description"].ToString();
                    duration = reader["tour_duration"].ToString();
                    cost = reader["price"].ToString();
                    rating = reader["ratings"].ToString();
                   

                    

                    byte[] imageData = (byte[])reader["photo"];
                    string base64Image = Convert.ToBase64String(imageData);
                    string imageUrl = "data:image/jpeg;base64," + base64Image;

                    string qr2 = "select agency_name from agency_info where email='" + email + "'";
                    OracleCommand cmd2 = new OracleCommand(qr2, con);
                    OracleDataReader reader2 = cmd2.ExecuteReader();

                    string agencyName = "";
                    if (reader2.Read())
                    {
                        agencyName = reader2["agency_name"].ToString();
                    }

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "swiper-slide box";

                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    div2.Attributes["class"] = "image";

                    HtmlGenericControl img1 = new HtmlGenericControl("img");
                    img1.Attributes["src"] = imageUrl;
                    div2.Controls.Add(img1);

                    HtmlGenericControl div3 = new HtmlGenericControl("div");
                    div3.Attributes["class"] = "content";

                    HtmlGenericControl div4 = new HtmlGenericControl("div");
                    div4.Attributes["class"] = "agency";

                    HtmlGenericControl i1 = new HtmlGenericControl("i");
                    i1.Attributes["class"] = "fa-solid fa-building";
                    HtmlGenericControl p1 = new HtmlGenericControl("p");
                    p1.InnerText= agencyName;
                    div4.Controls.Add(i1);
                    div4.Controls.Add(p1);

                    div3.Controls.Add(div4);

                    HtmlGenericControl h3 = new HtmlGenericControl("h4");
                    HtmlGenericControl p2 = new HtmlGenericControl("p");
                    h3.InnerText = title;
                    p2.InnerText = duration;

                    div3.Controls.Add(h3);
                    div3.Controls.Add(p2);

                    HtmlGenericControl div5 = new HtmlGenericControl("div");
                    div5.Attributes["class"] = "price_rating";

                    HtmlGenericControl div6 = new HtmlGenericControl("div");
                    div6.Attributes["class"] = "rate";
                    HtmlGenericControl i2 = new HtmlGenericControl("i");
                    HtmlGenericControl p3 = new HtmlGenericControl("p");
                    HtmlGenericControl p4 = new HtmlGenericControl("p");
                    i2.Attributes["class"] = "fa-solid fa-star";
                    p3.Attributes["style"] = "color: #DC7303;";
                    p3.InnerText = rating;
                    div6.Controls.Add(i2);
                    div6.Controls.Add(p3);

                    p4.Attributes["class"] = "amount";
                    p4.InnerText = cost+ "tk";
                    div5.Controls.Add(div6);
                    div5.Controls.Add(p4);

                    div3.Controls.Add(div5);

                    HtmlGenericControl a1 = new HtmlGenericControl("a");
                    a1.Attributes["class"] = "explore_btn";
                    a1.Attributes["onclick"] = "packageClicked('" + id + "')";
                    a1.InnerText = "Explore Now";

                    div3.Controls.Add(a1);

                    div.Controls.Add(div2);
                    div.Controls.Add(div3);

                    package_container.Controls.Add(div);


                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Response.Write("<script>alert('" + msg + "');</script>");
            }
        }
        void shopData()
        {
            try
            {
                con.Open();
                string qr = "select * from product";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id,productName, price;
                    double rating;
                    id = reader["id"].ToString();
                    productName = reader["PRODUCT_NAME"].ToString();
                    price = reader["PRICE"].ToString();
                    //details = reader["description"].ToString();
                    rating = Convert.ToDouble(reader["RATINGS"].ToString());

                    int fullStars = (int)Math.Floor(rating);
                    bool hasHalfStar = (rating - fullStars) >= 0.5;
                    int emptyStar = 5 - fullStars;
                    StringBuilder starHtml = new StringBuilder();
                    for (int i = 0; i < fullStars; i++)
                    {
                        starHtml.Append("<i class=\"fa-solid fa-star\"></i>");
                    }
                    if (hasHalfStar)
                    {
                        starHtml.Append("<i class=\"fa-solid fa-star-half-stroke\"></i>");
                        emptyStar--;
                    }

                    for (int i = 0; i < emptyStar; i++)
                    {

                        starHtml.Append("<i class=\"fa-regular fa-star\"></i>");
                    }

                    byte[] imageData = (byte[])reader["IMAGE"];
                    string base64Image = Convert.ToBase64String(imageData);
                    string imageUrl = "data:image/jpeg;base64," + base64Image;

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "swiper-slide slide";

                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    div2.Attributes["class"] = "image";

                    HtmlGenericControl img1 = new HtmlGenericControl("img");
                    img1.Attributes["src"] = imageUrl;
                    div2.Controls.Add(img1);

                    HtmlGenericControl div3 = new HtmlGenericControl("div");
                    div3.Attributes["class"] = "icons";

                    HtmlGenericControl a1 = new HtmlGenericControl("a");
                    a1.Attributes["class"] = "fa-solid fa-cart-shopping";
                    HtmlGenericControl a2 = new HtmlGenericControl("a");
                    a2.Attributes["class"] = "fa-solid fa-eye";
                    a2.Attributes["onclick"] = "productClicked('" + id + "')"; ;
                    div3.Controls.Add(a1);
                    div3.Controls.Add(a2);

                    div2.Controls.Add(div3);

                    HtmlGenericControl div4 = new HtmlGenericControl("div");
                    div4.Attributes["class"] = "content";
                    HtmlGenericControl h3 = new HtmlGenericControl("h3");
                    h3.InnerText = productName;
                    HtmlGenericControl div5 = new HtmlGenericControl("div");
                    div5.Attributes["class"] = "price";
                    div5.InnerText = price + " tk";

                    HtmlGenericControl div6 = new HtmlGenericControl("div");
                    div6.Attributes["class"] = "stars";
                    div6.InnerHtml = starHtml.ToString();
                    /*HtmlGenericControl i1 = new HtmlGenericControl("i");
                    i1.Attributes["class"] = "fa-solid fa-star";
                    HtmlGenericControl i2 = new HtmlGenericControl("i");
                    i2.Attributes["class"] = "fa-solid fa-star";
                    HtmlGenericControl i3 = new HtmlGenericControl("i");
                    i3.Attributes["class"] = "fa-solid fa-star";
                    HtmlGenericControl i4 = new HtmlGenericControl("i");
                    i4.Attributes["class"] = "fa-solid fa-star";
                    HtmlGenericControl i5 = new HtmlGenericControl("i");
                    i5.Attributes["class"] = "fa-solid fa-star-half-stroke";
                    div6.Controls.Add(i1);
                    div6.Controls.Add(i2);
                    div6.Controls.Add(i3);
                    div6.Controls.Add(i4);
                    div6.Controls.Add(i5);*/

                    div4.Controls.Add(h3);
                    div4.Controls.Add(div5);
                    div4.Controls.Add(div6);

                    div.Controls.Add(div2);
                    div.Controls.Add(div4);

                    shop_container.Controls.Add(div);

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