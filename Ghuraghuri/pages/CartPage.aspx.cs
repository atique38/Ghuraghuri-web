using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm21 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["data"];

                if (Session["login_opt"] != null && (Session["login_opt"].Equals("agency") || Session["login_opt"].Equals("admin")))
                {
                    error.Text = "Please log in as user to buy something";
                }
                else if (Session["login_opt"] != null && Session["login_opt"].Equals("user"))
                {
                    if (Session["u_email"] != null)
                    {
                        if (isItemAlreadyExist(id))
                        {
                            //error.Text = "exist";
                            readFromCart();
                        }
                        else
                        {
                            //error.Text = "new";
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

                                saveToCart(id, productName, price, imageData);

                            }
                            con.Close();
                            readFromCart();

                        }

                    }
                }
                else
                {
                    error.Text = "Please Log In First.";
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                error.Text = msg;
            }


        }

       

        void saveToCart(string pId, string pName, string price, byte[] image)
        {
            string qr = "insert into cart (PRODUCT_ID,PRODUCT_NAME,PRICE,QUANTITY,IMAGE,USER_EMAIL) values(:id,:name,:price,1,:img,:em)";
            OracleCommand cmd= new OracleCommand(qr,con);
            cmd.Parameters.Add(":id",OracleDbType.Int32).Value = pId;
            cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = pName;
            cmd.Parameters.Add(":price", OracleDbType.Int64).Value = price;
            cmd.Parameters.Add(":img", OracleDbType.Blob).Value = image;
            cmd.Parameters.Add(":em", OracleDbType.Varchar2).Value = Session["u_email"].ToString();
            int x=cmd.ExecuteNonQuery();
            if(x<=0)
            {
                error.Text = "Something went wrong";
            }
            //con.Close();
        }
        bool isItemAlreadyExist(string pid)
        {
            con.Open();
            string qr = "select * from cart where PRODUCT_ID='" + pid + "' and USER_EMAIL='" + Session["u_email"].ToString() + "'";
            OracleCommand cmd= new OracleCommand( qr,con);
            OracleDataReader reader= cmd.ExecuteReader();
            if(reader.Read())
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
        void readFromCart()
        {
            error.Text = "again";
            con.Open();
            string qr = "select * from cart where USER_EMAIL='" + Session["u_email"].ToString() + "'";
            OracleCommand cmd = new OracleCommand(qr, con);
            OracleDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                string productName, price,qn,pid;
                productName = reader["PRODUCT_NAME"].ToString();
                price = reader["PRICE"].ToString();
                qn = reader["QUANTITY"].ToString();
                pid = reader["PRODUCT_ID"].ToString();
                //pr = Convert.ToInt64(price);
                //error.Text = pid;
                byte[] imageData = (byte[])reader["IMAGE"];
                string base64Image = Convert.ToBase64String(imageData);
                string imageUrl = "data:image/jpeg;base64," + base64Image;

                Int64 totalPrice = Convert.ToInt64(qn) * Convert.ToInt64(price);
                TableRow row = new TableRow();
                row.ID = "row_" + pid;

                TableCell product = new TableCell();
                TableCell quantity = new TableCell();
                TableCell cost = new TableCell();
                product.Attributes["class"] = "td";
                quantity.Attributes["class"] = "td";
                cost.Attributes["class"] = "td";

                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes["class"] = "cart_info";

                HtmlGenericControl img = new HtmlGenericControl("img");
                img.Attributes["src"] = imageUrl;

                HtmlGenericControl div2 = new HtmlGenericControl("div");
                div2.Attributes["class"] = "info";
                HtmlGenericControl h4 = new HtmlGenericControl("h4");
                h4.InnerText = productName;
                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerText = "Price: " + price + "tk";
                /*LinkButton button = new LinkButton();
                button.CommandArgument = row.ID;
                button.Click += DeleteCartItem_Click;
                //button.UseSubmitBehavior = true;

                HtmlGenericControl i = new HtmlGenericControl("i");
                i.Attributes["class"] = "fa-solid fa-trash-can";
                button.Controls.Add(i);*/

                Button button1 = new Button();
                //button1.UseSubmitBehavior = true;
                button1.CommandArgument = row.ID;
                button1.Click +=new EventHandler(DeleteCartItem_Click);
                button1.Text = "Remove";
                

                div2.Controls.Add(h4);
                div2.Controls.Add(p);
                div2.Controls.Add(button1);

                div.Controls.Add(img);
                div.Controls.Add(div2);
                product.Controls.Add(div);

                row.Cells.Add(product);

                TextBox textBox = new TextBox();
                textBox.Attributes["class"] = "input";
                textBox.TextMode = TextBoxMode.Number;
                textBox.Text = qn;
                textBox.Attributes["data-baseprice"] =price;
                textBox.Attributes["data-productId"] = pid;
                textBox.AutoPostBack = true;
                textBox.Attributes["oninput"] = "validateNonNegative(this)";
                textBox.TextChanged += Quantity_TextChanged;
                quantity.Controls.Add(textBox);
                row.Cells.Add(quantity);

                cost.Text = totalPrice + " tk";
                row.Cells.Add(cost);
                cartTable.Rows.Add(row);
            }
            con.Close();
            Table myTable = UpdatePanel2.FindControl("cartTable") as Table;
            //error.Text = myTable.Rows.Count.ToString();
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                if (i % 2 == 1) // Check if it's an even row
                {
                    myTable.Rows[i].CssClass = "even-row";
                }
            }
        }

        void deleteFromCart(string pdid)
        {
            string pid = pdid.Replace("row_", "");
            if(con.State== ConnectionState.Closed)
            {
                con.Open();
            }
            string qr = "delete from cart where PRODUCT_ID='" + pid + "' and USER_EMAIL='" + Session["u_email"].ToString() + "'";
            OracleCommand cmd= new OracleCommand(qr,con);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }


        protected void DeleteCartItem_Click(object sender, EventArgs e)
        {
            //error.Text = "clicked";
            Button button = (Button)sender;
            string rowId = button.CommandArgument;
            string pid= rowId.Replace("row_", "");
            string email = Session["u_email"].ToString();
            con.Open();
            string delQr = "delete from cart where PRODUCT_ID=:prd_id and USER_EMAIL=:em";
            OracleCommand command=new OracleCommand(delQr,con);
            command.Parameters.Add(":prd_id", pid);
            command.Parameters.Add(":em", email);
            int x=command.ExecuteNonQuery();
            if(x>0)
            {
                error.Text = "executed";
            }
            con.Close();
            //clicked = true;
            // Find the clicked LinkButton and get the associated row ID
            /*LinkButton clickedButton = (LinkButton)sender;
            string rowId = clickedButton.CommandArgument;*/

            /*Button button = (Button)sender;
            string rowId = button.CommandArgument;
            // Find the row by its ID and remove it
            *//*TableRow row = cartTable.FindControl(rowId) as TableRow;
            
            Table table = (Table)row.Parent;
            table.Rows.Remove(row);*//*
            string pid = rowId.Replace("row_", "");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string qr = "delete from cart where PRODUCT_ID='" + pid + "' and USER_EMAIL='" + Session["u_email"].ToString() + "'";
            OracleCommand cmd = new OracleCommand(qr, con);
            cmd.ExecuteNonQuery();
            con.Close();*/
            //deleteFromCart(rowId);
            //readFromCart();

        }
        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            //clicked = true;
            TextBox textBox = (TextBox)sender;
            TableRow row = (TableRow)textBox.Parent.Parent;
            TableCell quantityCell = row.Cells[1]; // Assuming the quantity cell is the second cell (index 1)
            TableCell priceCell = row.Cells[2]; // Assuming the price cell is the third cell (index 2)

            int quantity = Convert.ToInt32(textBox.Text);
            int basePrice = Convert.ToInt32(textBox.Attributes["data-baseprice"]);

            Int64 totalPrice = (Int64)quantity * basePrice;
            priceCell.Text = totalPrice + " tk";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string pid = textBox.Attributes["data-productId"];
            string qr = "update cart set QUANTITY='" + quantity + "' where PRODUCT_ID='" + pid + "' and USER_EMAIL='" + Session["u_email"].ToString() + "'";
            OracleCommand cmd = new OracleCommand(qr, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}