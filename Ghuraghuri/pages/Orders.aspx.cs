using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Ghuraghuri.pages
{
    public partial class WebForm26 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Attributes["class"] = "tr";
                TableHeaderCell headerCellSl = new TableHeaderCell();
                headerCellSl.Text = "SL No.";
                headerCellSl.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellSl);

                TableHeaderCell headerCellProduct = new TableHeaderCell();
                headerCellProduct.Text = "Product";
                headerCellProduct.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellProduct);

                TableHeaderCell headerCellSubtotal = new TableHeaderCell();
                headerCellSubtotal.Text = "Sub Total";
                headerCellSubtotal.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellSubtotal);

                TableHeaderCell headerCellDate = new TableHeaderCell();
                headerCellDate.Text = "Order Date";
                headerCellDate.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellDate);

                TableHeaderCell headerCellContact = new TableHeaderCell();
                headerCellContact.Text = "Contact";
                headerCellContact.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellContact);

                TableHeaderCell headerCellStatus = new TableHeaderCell();
                headerCellStatus.Text = "Status";
                headerCellStatus.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellStatus);

                OrdersTable.Rows.Add(headerRow);

                con.Open();
                string qr = "select * from USER_ORDER where STATUS='Pending'";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                int i = 1;
                while (reader.Read())
                {
                    string productName, price, qn, pid, uEmail,odr_id;
                    productName = reader["PRODUCT_NAME"].ToString();
                    price = reader["PRICE"].ToString();
                    qn = reader["QUANTITY"].ToString();
                    DateTime dateTime = reader.GetDateTime(7);
                    string st = reader["STATUS"].ToString();
                    string time = dateTime.ToString("dd MMM,yyyy hh:mm tt");
                    pid = reader["PRODUCT_ID"].ToString();
                    uEmail = reader["USER_EMAIL"].ToString();
                    odr_id = reader["ID"].ToString();


                    Int64 totalPrice = Convert.ToInt64(qn) * Convert.ToInt64(price);
                    //total += totalPrice;
                    TableRow row = new TableRow();
                    //row.ID = "Tablerow_" + pid;
                    TableCell sl = new TableCell();
                    TableCell product = new TableCell();
                    TableCell sub = new TableCell();
                    TableCell date = new TableCell();
                    TableCell status = new TableCell();
                    TableCell contact = new TableCell();
                    sl.Attributes["class"] = "td";
                    product.Attributes["class"] = "td";
                    date.Attributes["class"] = "td";
                    sub.Attributes["class"] = "td";
                    status.Attributes["class"] = "td";
                    contact.Attributes["class"] = "td";

                    sl.Text = i.ToString();

                    string celldata = productName + "<br/>Quantity: " + qn + "x<br/>" + "Price: " + price + " tk";

                    product.Text = celldata;

                    sub.Text = totalPrice.ToString();
                    date.Text = time;
                    //status.Text = st;
                    DropDownList dropDownList = new DropDownList();
                    dropDownList.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);
                    dropDownList.AutoPostBack = true;
                    dropDownList.Attributes["pack_id"] = odr_id;
                    dropDownList.Attributes["u_mail"] = uEmail;

                    dropDownList.Items.Add("Pending");
                    dropDownList.Items.Add("Received");
                    dropDownList.Items.Add("Delivered");
                    //dropDownList.Items.Add("Unavailable");

                    dropDownList.SelectedValue = st;
                    status.Controls.Add(dropDownList);

                    string query = "select * from DELIVERY_INFO where ORDER_ID='" + odr_id + "' and USER_EMAIL='" + uEmail + "'";
                    OracleCommand command = new OracleCommand(query,con);
                    OracleDataReader reader1 = command.ExecuteReader();
                    if(reader1.Read())
                    {
                        string q = "select NAME from user_info where email='" + uEmail + "'";
                        OracleCommand command1=new OracleCommand(q,con);
                        string name = command1.ExecuteScalar().ToString();
                        string adrs, phn;
                        adrs = reader1["ADDRESS"].ToString();
                        phn = reader1["PHONE"].ToString();
                        string data = name + "<br/>" + uEmail + "<br/>" + phn + "<br/>" + adrs;
                        contact.Text= data;
                    }
                    row.Cells.Add(sl);
                    row.Cells.Add(product);
                    row.Cells.Add(sub);
                    row.Cells.Add(date);
                    row.Cells.Add(contact);
                    row.Cells.Add(status);
                    OrdersTable.Rows.Add(row);
                    i++;

                }
                con.Close();

                for (int j = 0; j < OrdersTable.Rows.Count; j++)
                {
                    if (j % 2 == 1)
                    {
                        OrdersTable.Rows[j].Attributes["class"] = "odd_row";
                    }
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label5.Text = msg;
            }
        }

        protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            //TableCell statusCell = (TableCell)ddl.Parent;
            //TableRow row = (TableRow)statusCell.Parent;
            //TableCell slCell = row.Cells[0];

            //string slNo = slCell.Text;
            string newStatus = ddl.SelectedValue;
            string id = ddl.Attributes["pack_id"];
            string mail = ddl.Attributes["u_mail"];

            // Update the status in the Oracle database
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string updateQuery = "UPDATE USER_ORDER SET STATUS = :status WHERE ID = :pid AND USER_EMAIL = :email";
                OracleCommand cmd = new OracleCommand(updateQuery, con);
                cmd.Parameters.Add(new OracleParameter("status", newStatus));
                cmd.Parameters.Add(new OracleParameter("pid", id));
                //cmd.Parameters.Add(new OracleParameter("slNo", slNo));
                cmd.Parameters.Add(new OracleParameter("email", mail));
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Orders.aspx");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label5.Text = msg;
            }
        }
    }
}