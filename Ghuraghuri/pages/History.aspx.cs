using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm6 : System.Web.UI.Page
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
                headerCellProduct.Text = "Package";
                headerCellProduct.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellProduct);

                TableHeaderCell headerCellSubtotal = new TableHeaderCell();
                headerCellSubtotal.Text = "Cost";
                headerCellSubtotal.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellSubtotal);

                TableHeaderCell headerCellDate = new TableHeaderCell();
                headerCellDate.Text = "Booking Date";
                headerCellDate.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellDate);

                TableHeaderCell headerCellJourDate = new TableHeaderCell();
                headerCellJourDate.Text = "Journey Date";
                headerCellJourDate.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellJourDate);

                TableHeaderCell headerCellStatus = new TableHeaderCell();
                headerCellStatus.Text = "Status";
                headerCellStatus.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellStatus);

                OrderHistoryTable.Rows.Add(headerRow);

                con.Open();
                string qr = "select * from BOOKING where USER_EMAIL='" + Session["u_email"].ToString() + "'";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                int i = 1;
                while (reader.Read())
                {
                    string packageName, price, qn, pid;
                    packageName = reader["PACKAGE_NAME"].ToString();
                    price = reader["PRICE"].ToString();
                    qn = reader["TOTAL_TORIST"].ToString();
                    DateTime dateTime = reader.GetDateTime(3);
                    string st = reader["STATUS"].ToString();
                    string jrDate = reader["JOURNEY_DATE"].ToString();
                    string time = dateTime.ToString("dd MMM,yyyy hh:mm tt");
                    //pid = reader["PRODUCT_ID"].ToString();


                    Int64 totalPrice = Convert.ToInt64(qn) * Convert.ToInt64(price);
                    //total += totalPrice;
                    TableRow row = new TableRow();
                    //row.ID = "Tablerow_" + pid;
                    TableCell sl = new TableCell();
                    TableCell package = new TableCell();
                    TableCell total = new TableCell();
                    TableCell bkdate = new TableCell();
                    TableCell jrdate = new TableCell();
                    TableCell status = new TableCell();
                    sl.Attributes["class"] = "td";
                    package.Attributes["class"] = "td";
                    bkdate.Attributes["class"] = "td";
                    jrdate.Attributes["class"] = "td";
                    total.Attributes["class"] = "td";
                    status.Attributes["class"] = "td";

                    sl.Text = i.ToString();

                    string celldata = packageName+ "<br/>Members: "+qn+"<br/>" + "Price: " + price + " tk";

                    package.Text = celldata;

                    total.Text = totalPrice.ToString();
                    bkdate.Text = time;
                    jrdate.Text = jrDate;
                    status.Text = st;

                    row.Cells.Add(sl);
                    row.Cells.Add(package);
                    row.Cells.Add(total);
                    row.Cells.Add(bkdate);
                    row.Cells.Add(jrdate);
                    row.Cells.Add(status);
                    OrderHistoryTable.Rows.Add(row);
                    i++;

                }
                con.Close();

                for (int j = 0; j < OrderHistoryTable.Rows.Count; j++)
                {
                    if (j % 2 == 1)
                    {
                        OrderHistoryTable.Rows[j].Attributes["class"] = "odd_row";
                    }
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