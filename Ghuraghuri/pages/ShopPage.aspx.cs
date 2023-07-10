using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm20 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string qr = "select * from product order by ratings desc";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id, productName, price;
                    double rating;
                    id = reader["id"].ToString();
                    productName = reader["PRODUCT_NAME"].ToString();
                    price = reader["PRICE"].ToString();
                    //details = reader["description"].ToString();
                    rating = Convert.ToDouble( reader["RATINGS"]);

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
                    div.Attributes["class"] = "slide";

                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    div2.Attributes["class"] = "image";

                    HtmlGenericControl img1 = new HtmlGenericControl("img");
                    img1.Attributes["src"] = imageUrl;
                    div2.Controls.Add(img1);

                    HtmlGenericControl div3 = new HtmlGenericControl("div");
                    div3.Attributes["class"] = "icons";

                    HtmlGenericControl a1 = new HtmlGenericControl("a");
                    a1.Attributes["class"] = "fa-solid fa-cart-shopping";
                    a1.Attributes["onclick"] = "addToCart('" + id + "')";
                    HtmlGenericControl a2 = new HtmlGenericControl("a");
                    a2.Attributes["class"] = "fa-solid fa-eye";
                    a2.Attributes["onclick"] = "productClicked('" + id + "')"; 
                    div3.Controls.Add(a1);
                    div3.Controls.Add(a2);

                    div2.Controls.Add(div3);

                    HtmlGenericControl div4 = new HtmlGenericControl("div");
                    div4.Attributes["class"] = "content";
                    HtmlGenericControl h3 = new HtmlGenericControl("h3");
                    h3.InnerText = productName;
                    HtmlGenericControl div5 = new HtmlGenericControl("div");
                    div5.Attributes["class"] = "price";
                    div5.InnerText = price+" tk";

                    HtmlGenericControl div6 = new HtmlGenericControl("div");
                    div6.Attributes["class"] = "stars";

                    div6.InnerHtml = starHtml.ToString();

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

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string search = searchTxt.Text.ToLower();
                if (!string.IsNullOrEmpty(search))
                {
                    shop_container.InnerHtml = "";
                    con.Open();
                    string qr = "select * from product where lower(product_name) like '%' || :searchQuery || '%'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    cmd.Parameters.Add(":searchQuery", "%" + search + "%");
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id, productName, price;
                        double rating;
                        id = reader["id"].ToString();
                        productName = reader["PRODUCT_NAME"].ToString();
                        price = reader["PRICE"].ToString();
                        //details = reader["description"].ToString();
                        rating = Convert.ToDouble(reader["RATINGS"]);

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
                        div.Attributes["class"] = "slide";

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

                        div4.Controls.Add(h3);
                        div4.Controls.Add(div5);
                        div4.Controls.Add(div6);

                        div.Controls.Add(div2);
                        div.Controls.Add(div4);

                        shop_container.Controls.Add(div);

                    }
                    if (!reader.HasRows)
                    {
                        error.Text = "Nothing to show";
                    }
                    con.Close();
                }
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                error.Text = msg;
            }
        }
    }
}