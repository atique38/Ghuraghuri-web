using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Ghuraghuri.pages
{
    public partial class WebForm25 : System.Web.UI.Page
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

                TableHeaderCell headerCellContact = new TableHeaderCell();
                headerCellContact.Text = "Contact";
                headerCellContact.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellContact);

                TableHeaderCell headerCellStatus = new TableHeaderCell();
                headerCellStatus.Text = "Status";
                headerCellStatus.Attributes["class"] = "th";
                headerRow.Cells.Add(headerCellStatus);

                BookingHistoryTable.Rows.Add(headerRow);

                con.Open();
                string qr = "select * from BOOKING where AGENCY_EMAIL='" + Session["u_email"].ToString() + "' and STATUS = 'Pending'";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleDataReader reader = cmd.ExecuteReader();

                int i = 1;
                while (reader.Read())
                {
                    string packageName, price, qn, pid,uEmail;
                    packageName = reader["PACKAGE_NAME"].ToString();
                    price = reader["PRICE"].ToString();
                    qn = reader["TOTAL_TORIST"].ToString();
                    DateTime dateTime = reader.GetDateTime(3);
                    string st = reader["STATUS"].ToString();
                    string jrDate = reader["JOURNEY_DATE"].ToString();
                    string time = dateTime.ToString("dd MMM,yyyy hh:mm tt");
                    pid = reader["PACKAGE_ID"].ToString();
                    uEmail = reader["USER_EMAIL"].ToString();


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
                    TableCell contact = new TableCell();
                    sl.Attributes["class"] = "td";
                    package.Attributes["class"] = "td";
                    bkdate.Attributes["class"] = "td";
                    jrdate.Attributes["class"] = "td";
                    total.Attributes["class"] = "td";
                    status.Attributes["class"] = "td";
                    contact.Attributes["class"] = "td";

                    sl.Text = i.ToString();

                    string celldata = packageName + "<br/>Members: " + qn + "<br/>" + "Price: " + price + " tk";

                    package.Text = celldata;

                    total.Text = totalPrice.ToString();
                    bkdate.Text = time;
                    jrdate.Text = jrDate;
                    //status.Text = st;

                    DropDownList dropDownList = new DropDownList();
                    dropDownList.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);
                    dropDownList.AutoPostBack = true;
                    dropDownList.Attributes["pack_id"] = pid;
                    dropDownList.Attributes["u_mail"] = uEmail;

                    dropDownList.Items.Add("Pending");
                    dropDownList.Items.Add("Accepted");
                    dropDownList.Items.Add("Completed");
                    dropDownList.Items.Add("Unavailable");

                    dropDownList.SelectedValue = st;
                    status.Controls.Add(dropDownList);

                    string qr2 = "select * from USER_INFO where EMAIL='" + uEmail + "'";
                    OracleCommand command = new OracleCommand(qr2, con);
                    OracleDataReader reader1 = command.ExecuteReader();
                    if (reader1.Read())
                    {
                        string name, phn;
                        name = reader1["NAME"].ToString();
                        phn = reader1["PHONE_NO"].ToString();

                        string info = name + "<br/>Email: " + uEmail + "<br/>Phone: " + phn;
                        contact.Text = info;
                    }

                    row.Cells.Add(sl);
                    row.Cells.Add(package);
                    row.Cells.Add(total);
                    row.Cells.Add(bkdate);
                    row.Cells.Add(jrdate);
                    row.Cells.Add(contact);
                    row.Cells.Add(status);
                    BookingHistoryTable.Rows.Add(row);
                    i++;

                }
                con.Close();

                for (int j = 0; j < BookingHistoryTable.Rows.Count; j++)
                {
                    if (j % 2 == 1)
                    {
                        BookingHistoryTable.Rows[j].Attributes["class"] = "odd_row";
                    }
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label4.Text = msg;
            }
        }

        // DropDownList SelectedIndexChanged event handler
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
                
                string updateQuery = "UPDATE BOOKING SET STATUS = :status WHERE PACKAGE_ID = :pid AND USER_EMAIL = :email";
                OracleCommand cmd = new OracleCommand(updateQuery, con);
                cmd.Parameters.Add(new OracleParameter("status", newStatus));
                cmd.Parameters.Add(new OracleParameter("pid", id));
                //cmd.Parameters.Add(new OracleParameter("slNo", slNo));
                cmd.Parameters.Add(new OracleParameter("email", mail));
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Bookings.aspx");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label4.Text = msg;
            }
        }
    }
}