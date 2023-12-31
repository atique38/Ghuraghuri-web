﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm22 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        bool ok = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_opt"] != null && (Session["login_opt"].Equals("agency") || Session["login_opt"].Equals("admin")))
            {
                error.Text = "Please log in as user to buy something";
            }
            else if (Session["login_opt"] != null && Session["login_opt"].Equals("user"))
            {
                if (Session["u_email"] != null)
                {
                    string id = Request.QueryString["data"];

                    //error.Text = Constant.clicked.ToString();
                    if (!string.IsNullOrEmpty(id))
                    {
                        //Constant.clicked = false;

                        if (!isItemAlreadyExist(id))
                        {
                            addToCart(id);
                            //Response.Redirect("Cart.aspx");
                        }
                    }
                    PopulateProductList();


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
        void PopulateProductList()
        {
            try
            {
                cartTable.Rows.Clear();
                // Create the table heading row
                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Attributes["class"] = "tr";
                TableHeaderCell headerCellProduct = new TableHeaderCell();
                headerCellProduct.Text = "Product";
                headerCellProduct.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellProduct);
                TableHeaderCell headerCellQuantity = new TableHeaderCell();
                headerCellQuantity.Text = "Quantity";
                headerCellQuantity.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellQuantity);
                TableHeaderCell headerCellPrice = new TableHeaderCell();
                headerCellPrice.Text = "Price";
                headerCellPrice.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellPrice);
                cartTable.Rows.Add(headerRow);

                con.Open();
                string qr = "select * from cart where USER_EMAIL='" + Session["u_email"].ToString() + "'";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                Int64 total=0;
                while (reader.Read())
                {
                    string productName, price, qn, pid;
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
                    total += totalPrice;
                    TableRow row = new TableRow();
                    row.ID ="Tablerow_"+pid;

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
                    

                    Button button1 = new Button();
                    
                    button1.CommandArgument = pid;
                    button1.Click += new EventHandler(DeleteCartItem_Click);
                    button1.Text = "Remove";


                    div2.Controls.Add(h4);
                    div2.Controls.Add(p);
                    div2.Controls.Add(button1);

                    div.Controls.Add(img);
                    div.Controls.Add(div2);
                    product.Controls.Add(div);

                    row.Cells.Add(product);

                    //int mxqn = Convert.ToInt32(qn);
                    TextBox textBox = new TextBox();
                    textBox.Attributes["class"] = "input";
                    textBox.TextMode = TextBoxMode.Number;
                    textBox.Text = qn;
                    textBox.Attributes["data-baseprice"] = price;
                    textBox.Attributes["data-productId"] = pid;
                    textBox.AutoPostBack = true;
                    textBox.Attributes["oninput"] = "validateNonNegative(this)";
                    textBox.TextChanged +=new EventHandler(Quantity_TextChanged);
                    quantity.Controls.Add(textBox);
                    row.Cells.Add(quantity);

                    cost.Text = totalPrice + " tk";
                    row.Cells.Add(cost);
                    cartTable.Rows.Add(row);

                    
                }
               
                con.Close();
                totalCost.InnerText = total + " tk";
                if(total==0)
                {
                    PlaceOrder.Enabled= false;
                    PlaceOrder.CssClass = "disabled";
                }
                else
                {
                    PlaceOrder.Enabled=true;
                    PlaceOrder.CssClass = "btn";
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                error.Text= msg;
            }
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
            Response.Redirect("Cart.aspx");
        }

        protected void DeleteCartItem_Click(object sender, EventArgs e)
        {
            Constant.clicked = true;
            Button button = (Button)sender;
            string pid = button.CommandArgument;
           
            string email = Session["u_email"].ToString();
            con.Open();
            string delQr = "delete from cart where PRODUCT_ID=:prd_id and USER_EMAIL=:em";
            OracleCommand command = new OracleCommand(delQr, con);
            command.Parameters.Add(":prd_id", pid);
            command.Parameters.Add(":em", email);
            command.ExecuteNonQuery();
            
            con.Close();
            //PopulateProductList();
            Response.Redirect("Cart.aspx");
            

        }

        void addToCart(string pid)
        {
            con.Open();
            string qr = "select product_name,price,image from product where id='" + pid + "'";
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

                string qr2 = "insert into cart (PRODUCT_ID,PRODUCT_NAME,PRICE,QUANTITY,IMAGE,USER_EMAIL) values(:id,:name,:price,1,:img,:em)";
                OracleCommand cmd2 = new OracleCommand(qr2, con);
                cmd2.Parameters.Add(":id", OracleDbType.Int32).Value = pid;
                cmd2.Parameters.Add(":name", OracleDbType.Varchar2).Value = productName;
                cmd2.Parameters.Add(":price", OracleDbType.Int64).Value = price;
                cmd2.Parameters.Add(":img", OracleDbType.Blob).Value = imageData;
                cmd2.Parameters.Add(":em", OracleDbType.Varchar2).Value = Session["u_email"].ToString();
                int x = cmd2.ExecuteNonQuery();
                if (x <= 0)
                {
                    error.Text = "Something went wrong";
                }

            }
            con.Close();
            
        }

        bool isItemAlreadyExist(string pid)
        {
            con.Open();
            string qr = "select * from cart where PRODUCT_ID='" + pid + "' and USER_EMAIL='" + Session["u_email"].ToString() + "'";
            OracleCommand cmd = new OracleCommand(qr, con);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        protected void PlaceOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeliveryInfo.aspx");
        }
    }
}