using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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
                    string qn = reader["QUANTITY"].ToString();

                    Constant.quantity = Convert.ToInt32(qn);
                    pdct_name.InnerText = name;
                    pdct_rate.InnerText = rating;
                    
                    pdct_price.InnerText = price + "tk";
                    

                    product_info.InnerHtml = details;
                    string txt = qn + " Products are available";
                    pd_quantity.InnerText = txt;
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
            
            pdctCount.InnerText = TextBox1.Text;
            
            Panel1.Visible = false;
        }

        protected void BuyBtn_Click(object sender, EventArgs e)
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
                        if (pdctCount.InnerText.Equals("Select Quantity"))
                        {
                            error.Text = "Please Select quantity";
                        }
                        else
                        {
                            string id = Request.QueryString["data"];
                            con.Open();
                            string del = "delete from temp_cart";
                            OracleCommand oracleCommand=new OracleCommand(del, con);
                            oracleCommand.ExecuteNonQuery();
                            string qr = "select product_name,price,image from product where id='" + id + "'";
                            OracleCommand cmd = new OracleCommand(qr, con);
                            OracleDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                string productName, price;
                                productName = reader["PRODUCT_NAME"].ToString();
                                price = reader["PRICE"].ToString();
                                //pr = Convert.ToInt64(price);

                                byte[] imageData = (byte[])reader["IMAGE"];
                                string base64Image = Convert.ToBase64String(imageData);
                                string imageUrl = "data:image/jpeg;base64," + base64Image;

                                string qr2 = "insert into temp_cart (PRODUCT_ID,PRODUCT_NAME,PRICE,QUANTITY,IMAGE,USER_EMAIL) values(:id,:name,:price,:qn,:img,:em)";
                                OracleCommand cmd2 = new OracleCommand(qr2, con);
                                cmd2.Parameters.Add(":id", OracleDbType.Int32).Value = id;
                                cmd2.Parameters.Add(":name", OracleDbType.Varchar2).Value = productName;
                                cmd2.Parameters.Add(":price", OracleDbType.Int64).Value = price;
                                cmd2.Parameters.Add(":qn", OracleDbType.Int32).Value = pdctCount.InnerText;
                                cmd2.Parameters.Add(":img", OracleDbType.Blob).Value = imageData;
                                cmd2.Parameters.Add(":em", OracleDbType.Varchar2).Value = Session["u_email"].ToString();
                                cmd2.ExecuteNonQuery();

                            }
                            con.Close();
                            Session["buyBtn"] = true;
                            Response.Redirect("DeliveryInfo.aspx");
                        }
                    }
                    else
                    {
                        error.Text = "Please Log In First";
                    }
                }
                else
                {
                    error.Text = "Please Log In First";
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                error.Text = msg;
            }
        }

        protected void AddToCartBtn_Click(object sender, EventArgs e)
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
                        if (pdctCount.InnerText.Equals("Select Quantity"))
                        {
                            error.Text = "Please Select quantity";
                        }
                        else
                        {
                            string id = Request.QueryString["data"];
                            if(!isItemAlreadyExist(id))
                            {
                                con.Open();
                                string qr = "select product_name,price,image from product where id='" + id + "'";
                                OracleCommand cmd = new OracleCommand(qr, con);
                                OracleDataReader reader = cmd.ExecuteReader();

                                while (reader.Read())
                                {
                                    string productName, price;
                                    productName = reader["PRODUCT_NAME"].ToString();
                                    price = reader["PRICE"].ToString();
                                    //pr = Convert.ToInt64(price);

                                    byte[] imageData = (byte[])reader["IMAGE"];
                                    string base64Image = Convert.ToBase64String(imageData);
                                    string imageUrl = "data:image/jpeg;base64," + base64Image;

                                    string qr2 = "insert into cart (PRODUCT_ID,PRODUCT_NAME,PRICE,QUANTITY,IMAGE,USER_EMAIL) values(:id,:name,:price,:qn,:img,:em)";
                                    OracleCommand cmd2 = new OracleCommand(qr2, con);
                                    cmd2.Parameters.Add(":id", OracleDbType.Int32).Value = id;
                                    cmd2.Parameters.Add(":name", OracleDbType.Varchar2).Value = productName;
                                    cmd2.Parameters.Add(":price", OracleDbType.Int64).Value = price;
                                    cmd2.Parameters.Add(":qn", OracleDbType.Int32).Value = pdctCount.InnerText;
                                    cmd2.Parameters.Add(":img", OracleDbType.Blob).Value = imageData;
                                    cmd2.Parameters.Add(":em", OracleDbType.Varchar2).Value = Session["u_email"].ToString();
                                    cmd2.ExecuteNonQuery();

                                }
                            }
                            
                            con.Close();
                            Response.Redirect("Cart.aspx");
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
                string msg= ex.Message;
                error.Text = msg;
            }
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            int qnt=Convert.ToInt32(TextBox1.Text);
            
            if (qnt <= 0) 
            {
                TextBox1.Text = "1";
            }
            else if (qnt > Constant.quantity)
            {
                TextBox1.Text = Constant.quantity.ToString();
            }
            
        }

        bool isItemAlreadyExist(string pid)
        {
            con.Open();
            string qr = "select * from cart where PRODUCT_ID='" + pid + "' and USER_EMAIL='" + Session["u_email"].ToString() + "'";
            OracleCommand cmd = new OracleCommand(qr, con);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string qr2 = "update cart set QUANTITY=:qn where PRODUCT_ID='" + pid + "' and USER_EMAIL='" + Session["u_email"].ToString() + "'";
                OracleCommand cmd2 = new OracleCommand(qr2, con);
                cmd2.Parameters.Add(":qn", OracleDbType.Int32).Value = pdctCount.InnerText;
                cmd2.ExecuteNonQuery();
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
    }
}