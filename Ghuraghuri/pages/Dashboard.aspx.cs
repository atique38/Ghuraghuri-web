using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_opt"] != null && Session["login_opt"].Equals("user"))
            {
                try
                {
                    user_dash.Visible = true;
                    agency_dash.Visible = false;
                    admin_dash.Visible = false;
                    order_hist.Visible = true;
                    booking_hist.Visible= true;
                    ag_booking_dash.Visible = false;
                    ad_order_dash.Visible = false;
                    string spanId1 = "counter1";
                    string spanId2 = "counter2";
                    string spanId3 = "counter3";
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string qr1 = "select count(*) from BOOKING where status <> 'Pending'";
                    OracleCommand cmd1 = new OracleCommand(qr1, con);
                    int tourCount = Convert.ToInt32(cmd1.ExecuteScalar());
                    //error.Text = tourCount.ToString();

                    string qr2 = "select count(*) from blog where email='" + Session["u_email"].ToString() + "'";
                    OracleCommand cmd2 = new OracleCommand(qr2, con);
                    int blogCount = Convert.ToInt32(cmd2.ExecuteScalar());

                    string qr3 = "select count(*) from USER_ORDER where USER_EMAIL='" + Session["u_email"].ToString() + "'";
                    OracleCommand cmd3 = new OracleCommand(qr3, con);
                    int orderCount = Convert.ToInt32(cmd3.ExecuteScalar());
                    //error.Text=orderCount.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "count1", "counter('" + spanId1 + "'," + tourCount + "," + 500 + "," + 1 + ");", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "count2", "counter('" + spanId2 + "'," + blogCount + "," + 500 + "," + 1 + ");", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "count3", "counter('" + spanId3 + "'," + orderCount + "," + 500 + "," + 1 + ");", true);
                    con.Close();
                }
                catch(Exception ex) 
                {
                    string msg = ex.Message;
                    error.Text= msg;
                }

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
                    string qr = "select * from USER_ORDER where USER_EMAIL='" + Session["u_email"].ToString() + "' and STATUS <> 'Delivered'";
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
                        string time = dateTime.ToString("dd MMM,yyyy hh:mm tt");
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

                        string celldata = productName + "<br/>Quantity: " + qn + "x<br/>" + "Price: " + price + " tk";

                        product.Text = celldata;

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
                    Label3.Text = msg;
                }

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

                    BookingHistoryTable.Rows.Add(headerRow);

                    con.Open();
                    string qr = "select * from BOOKING where USER_EMAIL='" + Session["u_email"].ToString() + "' and STATUS <> 'Completed'";
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

                        string celldata = packageName + "<br/>Members: " + qn + "<br/>" + "Price: " + price + " tk";

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
            else if (Session["login_opt"] != null && Session["login_opt"].Equals("agency"))
            {
                
                try
                {
                    user_dash.Visible = false;
                    agency_dash.Visible = true;
                    admin_dash.Visible = false;
                    order_hist.Visible = false;
                    booking_hist.Visible = false;
                    ag_booking_dash.Visible = true;
                    ad_order_dash.Visible = false;
                    string spanId1 = "counter7";
                    string spanId2 = "counter8";
                    string spanId3 = "counter9";
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string qr1 = "select count(*) from TOUR where AGENCY_EMAIL='" + Session["u_email"].ToString() + "'";
                    OracleCommand cmd1 = new OracleCommand(qr1, con);
                    int tourCount = Convert.ToInt32(cmd1.ExecuteScalar());
                    //error.Text = tourCount.ToString();

                    string qr2 = "select * from BOOKING where AGENCY_EMAIL='" + Session["u_email"].ToString() + "' and status = 'Completed'";
                    OracleCommand cmd2 = new OracleCommand(qr2, con);
                    OracleDataReader reader = cmd2.ExecuteReader();

                    Int64 total = 0;
                    while (reader.Read())
                    {
                        Int64 qn, pr;
                        qn = Convert.ToInt64(reader["TOTAL_TORIST"].ToString());
                        pr = Convert.ToInt64(reader["PRICE"].ToString());

                        total += (qn*pr);
                    }

                    string qr3 = "select count(*) from BOOKING where AGENCY_EMAIL='" + Session["u_email"].ToString() + "' and STATUS='Pending'";
                    OracleCommand cmd3 = new OracleCommand(qr3, con);
                    int pendingCount = Convert.ToInt32(cmd3.ExecuteScalar());
                    //error.Text=orderCount.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "count4", "counter('" + spanId1 + "'," + tourCount + "," + 300 + "," + 1 + ");", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "count5", "counter('" + spanId3 + "'," + pendingCount + "," + 300 + "," + 1 + ");", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "count6", "counter('" + spanId2 + "'," + total + "," + 50 + "," + 300 + ");", true);
                    
                    con.Close();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    Label2.Text = msg;
                }

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

                    AgBookingDash.Rows.Add(headerRow);

                    con.Open();
                    string qr = "select * from BOOKING where AGENCY_EMAIL='" + Session["u_email"].ToString() + "' and STATUS = 'Accepted'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    OracleDataReader reader = cmd.ExecuteReader();

                    int i = 1;
                    while (reader.Read())
                    {
                        string packageName, price, qn, pid, uEmail;
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

                        dropDownList.Items.Add("Accepted");
                        dropDownList.Items.Add("Completed");
                        
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
                        AgBookingDash.Rows.Add(row);
                        i++;

                    }
                    con.Close();

                    for (int j = 0; j < AgBookingDash.Rows.Count; j++)
                    {
                        if (j % 2 == 1)
                        {
                            AgBookingDash.Rows[j].Attributes["class"] = "odd_row";
                        }
                    }

                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    Label5.Text = msg;
                }
            }
            else if (Session["login_opt"] != null && Session["login_opt"].Equals("admin"))
            {

                try
                {
                    user_dash.Visible = false;
                    agency_dash.Visible = false;
                    admin_dash.Visible = true;
                    order_hist.Visible = false;
                    booking_hist.Visible = false;
                    ag_booking_dash.Visible = false;
                    ad_order_dash.Visible = true;
                    string spanId1 = "counter4";
                    string spanId2 = "counter5";
                    string spanId3 = "counter6";
                    string spanId4 = "counter10";
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string qr1 = "select count(*) from user_info";
                    OracleCommand cmd1 = new OracleCommand(qr1, con);
                    int userCount = Convert.ToInt32(cmd1.ExecuteScalar());
                    //error.Text = tourCount.ToString();

                    string qr2 = "select count(*) from agency_info";
                    OracleCommand cmd2 = new OracleCommand(qr2, con);
                    int agencyCount = Convert.ToInt32(cmd2.ExecuteScalar());

                    string qr3 = "select count(*) from spot";
                    OracleCommand cmd3 = new OracleCommand(qr3, con);
                    int spotCount = Convert.ToInt32(cmd3.ExecuteScalar());

                    string qr4 = "select count(*) from USER_ORDER where STATUS='Pending'";
                    OracleCommand cmd4 = new OracleCommand(qr4, con);
                    int pendingCount = Convert.ToInt32(cmd4.ExecuteScalar());
                    //error.Text=orderCount.ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "count4", "counter('" + spanId1 + "'," + userCount + "," + 300 + "," + 1 + ");", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "count5", "counter('" + spanId2 + "'," + agencyCount + "," + 300 + "," + 1 + ");", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "count6", "counter('" + spanId3 + "'," + spotCount + "," + 300 + "," + 1 + ");", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "count10", "counter('" + spanId4 + "'," + pendingCount + "," + 300 + "," + 1 + ");", true);

                    con.Close();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    Label1.Text = msg;
                }

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
                    string qr = "select * from USER_ORDER where STATUS='Received'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    OracleDataReader reader = cmd.ExecuteReader();

                    int i = 1;
                    while (reader.Read())
                    {
                        string productName, price, qn, pid, uEmail, odr_id;
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
                        dropDownList.SelectedIndexChanged += new EventHandler(dropDownListad_SelectedIndexChanged);
                        dropDownList.AutoPostBack = true;
                        dropDownList.Attributes["pack_id"] = odr_id;
                        dropDownList.Attributes["u_mail"] = uEmail;

                        //dropDownList.Items.Add("Pending");
                        dropDownList.Items.Add("Received");
                        dropDownList.Items.Add("Delivered");
                        //dropDownList.Items.Add("Unavailable");

                        dropDownList.SelectedValue = st;
                        status.Controls.Add(dropDownList);

                        string query = "select * from DELIVERY_INFO where ORDER_ID='" + odr_id + "' and USER_EMAIL='" + uEmail + "'";
                        OracleCommand command = new OracleCommand(query, con);
                        OracleDataReader reader1 = command.ExecuteReader();
                        if (reader1.Read())
                        {
                            string q = "select NAME from user_info where email='" + uEmail + "'";
                            OracleCommand command1 = new OracleCommand(q, con);
                            string name = command1.ExecuteScalar().ToString();
                            string adrs, phn;
                            adrs = reader1["ADDRESS"].ToString();
                            phn = reader1["PHONE"].ToString();
                            string data = name + "<br/>" + uEmail + "<br/>" + phn + "<br/>" + adrs;
                            contact.Text = data;
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
                    Label6.Text = msg;
                }
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

                string updateQuery = "UPDATE BOOKING SET STATUS = :status WHERE PACKAGE_ID = :pid AND USER_EMAIL = :email";
                OracleCommand cmd = new OracleCommand(updateQuery, con);
                cmd.Parameters.Add(new OracleParameter("status", newStatus));
                cmd.Parameters.Add(new OracleParameter("pid", id));
                //cmd.Parameters.Add(new OracleParameter("slNo", slNo));
                cmd.Parameters.Add(new OracleParameter("email", mail));
                cmd.ExecuteNonQuery();
                con.Close();
                Session["click"] = "dash";
                Response.Redirect("Dashboard.aspx");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label5.Text = msg;
            }
        }

        protected void dropDownListad_SelectedIndexChanged(object sender, EventArgs e)
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
                Session["click"] = "dash";
                Response.Redirect("Dashboard.aspx");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label5.Text = msg;
            }
        }
    }
    
}