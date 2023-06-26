using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm24 : System.Web.UI.Page
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

                TableHeaderCell headerCellStatus = new TableHeaderCell();
                headerCellStatus.Text = "Status";
                headerCellStatus.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellStatus);

                OrderHistoryTable.Rows.Add(headerRow);

                con.Open();
                string qr = "select * from USER_ORDER where USER_EMAIL='" + Session["u_email"].ToString() + "'";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                int i = 1;
                while (reader.Read())
                {
                    string productName, price, qn, pid;
                    productName = reader["PRODUCT_NAME"].ToString();
                    price = reader["PRICE"].ToString();
                    qn = reader["QUANTITY"].ToString();
                    DateTime dateTime = reader.GetDateTime(7);
                    string st = reader["STATUS"].ToString();
                    string time=dateTime.ToString("dd MMM,yyyy hh:mm tt");
                    //pid = reader["PRODUCT_ID"].ToString();
                    

                    Int64 totalPrice = Convert.ToInt64(qn) * Convert.ToInt64(price);
                    //total += totalPrice;
                    TableRow row = new TableRow();
                    //row.ID = "Tablerow_" + pid;
                    TableCell sl = new TableCell();
                    TableCell product = new TableCell();
                    TableCell sub = new TableCell();
                    TableCell date = new TableCell();
                    TableCell status = new TableCell();
                    sl.Attributes["class"] = "td";
                    product.Attributes["class"] = "td";
                    date.Attributes["class"] = "td";
                    sub.Attributes["class"] = "td";
                    status.Attributes["class"] = "td";

                    sl.Text = i.ToString();
                    
                    string celldata = productName + ", " + qn + "x<br/>" + "Price: " + price + " tk";
                    
                    product.Text=celldata;

                    sub.Text = totalPrice.ToString();
                    date.Text = time;
                    status.Text = st;
                    
                    row.Cells.Add(sl);
                    row.Cells.Add(product);
                    row.Cells.Add(sub);
                    row.Cells.Add(date);
                    row.Cells.Add(status);
                    OrderHistoryTable.Rows.Add(row);
                    i++;

                }
                con.Close();

                for(int j = 0; j < OrderHistoryTable.Rows.Count; j++)
                {
                    if(j%2==1)
                    {
                        OrderHistoryTable.Rows[j].Attributes["class"] = "odd_row";
                    }
                }

            }
            catch(Exception ex)
            {
                string msg=ex.Message;
                error.Text = msg;
            }
        }
    }
}