using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm23 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ConfirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string address = adrs.Text;
                string phone = phn.Text;
                string method = RadioButtonList1.SelectedValue;
                //error.Text = method;
                con.Open();
                string qr = "";
                if(Session["buyBtn"] != null && (bool)Session["buyBtn"])
                {
                    qr = "SELECT * FROM temp_cart WHERE USER_EMAIL = :u_email";
                    //Session["buyBtn"] = false;
                }
                else
                {
                    qr = "SELECT * FROM cart WHERE USER_EMAIL = :u_email";
                }
                OracleCommand cmd = new OracleCommand(qr, con);
                cmd.Parameters.Add(":u_email", OracleDbType.Varchar2).Value = Session["u_email"].ToString();
                OracleDataReader reader = cmd.ExecuteReader();

                int cnt = 0;
                while (reader.Read()) 
                {
                    string productName = reader["PRODUCT_NAME"].ToString();
                    string price = reader["PRICE"].ToString();
                    string qn = reader["QUANTITY"].ToString();
                    string pid = reader["PRODUCT_ID"].ToString();

                    string qr2 = "INSERT INTO USER_ORDER (USER_EMAIL, USER_NAME, PRODUCT_ID, PRODUCT_NAME, QUANTITY, PRICE, ORDER_DATE, STATUS) VALUES (:em, :uname, :pdid, :pdname, :qn, :price, :od_date, :status)";
                    OracleCommand cmd2 = new OracleCommand(qr2, con);
                    cmd2.Parameters.Add(":em", OracleDbType.Varchar2).Value = Session["u_email"].ToString();
                    cmd2.Parameters.Add(":uname", OracleDbType.Varchar2).Value = Session["u_name"].ToString();
                    cmd2.Parameters.Add(":pdid", OracleDbType.Int32).Value = Convert.ToInt32(pid);
                    cmd2.Parameters.Add(":pdname", OracleDbType.Varchar2).Value = productName;
                    cmd2.Parameters.Add(":qn", OracleDbType.Int32).Value = Convert.ToInt32(qn);
                    cmd2.Parameters.Add(":price", OracleDbType.Int32).Value = Convert.ToInt32(price);
                    cmd2.Parameters.Add(":od_date", OracleDbType.Date).Value = DateTime.Now;
                    cmd2.Parameters.Add(":status", OracleDbType.Varchar2).Value = "Pending";

                    //, USER_NAME, PRODUCT_ID, PRODUCT_NAME, QUANTITY, PRICE, ORDER_DATE, STATUS
                    //, :uname, :pdid, :pdname, :qn, :price, :date, :status

                    cmd2.ExecuteNonQuery();
                    cnt++;

                }

                string sql = "select id from (select * from user_order order by id desc) WHERE ROWNUM = 1";
                OracleCommand command = new OracleCommand(sql, con);
                int ord_id = Convert.ToInt32(command.ExecuteScalar());
                for(int i=cnt;i>0;i--)
                {
                    string qr3 = "insert into delivery_info values('" + Session["u_email"].ToString() + "','" + address + "','" + phone + "','" + method + "','"+ord_id+"')";
                    OracleCommand cmd3 = new OracleCommand(qr3, con);
                    cmd3.ExecuteNonQuery();
                    ord_id--;
                }
                
                if (Session["buyBtn"]!=null && !(bool)Session["buyBtn"])
                {
                    string qr4 = "delete from cart where user_email='" + Session["u_email"].ToString() + "'";
                    OracleCommand cmd4 = new OracleCommand(qr4, con);
                    cmd4.ExecuteNonQuery();
                }
                else
                {
                    string qr5 = "delete from temp_cart";
                    OracleCommand cmd5 = new OracleCommand(qr5, con);
                    cmd5.ExecuteNonQuery();
                }
               
                con.Close();
                Session["buyBtn"] = false;
                Session["click"] = "order_hist";
                Response.Redirect("OrderHistory.aspx");
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                error.Text = msg;
            }


        }
    }
}