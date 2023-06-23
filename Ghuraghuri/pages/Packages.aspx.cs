using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                string qr = "select * from tour";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string email, title, id, cost, duration, rating;
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
                    div.Attributes["class"] = "packages_slide";

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
                    p1.InnerText = agencyName;
                    div4.Controls.Add(i1);
                    div4.Controls.Add(p1);

                    div3.Controls.Add(div4);

                    HtmlGenericControl h3 = new HtmlGenericControl("h3");
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
                    p4.InnerText = cost + "tk";
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

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                error.Text = string.Empty;
                string search = searchTxt.Text.ToLower();
                if(!string.IsNullOrEmpty(search) )
                {
                    package_container.InnerHtml = "";
                    con.Open();
                    string qr = "select * from tour where lower(tour_name) like '%' || :searchQuery || '%'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    cmd.Parameters.Add(":searchQuery", "%" + search + "%");
                    OracleDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string email, title, id, cost, duration, rating;
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
                        div.Attributes["class"] = "packages_slide";

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
                        p1.InnerText = agencyName;
                        div4.Controls.Add(i1);
                        div4.Controls.Add(p1);

                        div3.Controls.Add(div4);

                        HtmlGenericControl h3 = new HtmlGenericControl("h3");
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
                        p4.InnerText = cost + "tk";
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
                error.Text=msg;
            }
        }
    }
}