using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Ghuraghuri.pages
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckDuplicate())
                {
                    //Response.Write("<script>alert('User already exits');</script>");
                    error.Text = "User already exits!";
                    error.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    //userSignUp();
                }
                userSignUp();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        bool CheckDuplicate()
        {
            try
            {
                con.Open();
                string qr = "select * from user_data where email=:1";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleParameter email = new OracleParameter();
                email.OracleDbType = OracleDbType.Varchar2;
                email.Value = TextBox1.Text;
                cmd.Parameters.Add(email);
                //Response.Write("<script>alert('" + qr + "');</script>");

                OracleDataReader reder = cmd.ExecuteReader();

                if (reder.HasRows)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            return false;
        }

        void userSignUp()
        {
            con.Open();

            string qr = "insert into user_data values(:1, :2)";
            OracleCommand cmd = new OracleCommand(qr, con);
            OracleParameter name = new OracleParameter();
            

            OracleParameter email = new OracleParameter();
            email.OracleDbType = OracleDbType.Varchar2;
            email.Value = TextBox1.Text;

            OracleParameter pass = new OracleParameter();
            pass.OracleDbType = OracleDbType.Varchar2;
            pass.Value = TextBox2.Text;

            
            cmd.Parameters.Add(email);
            cmd.Parameters.Add(pass);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("WebForm16.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm16.aspx");
        }
    }
}