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
    public partial class WebForm16 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //Response.Write("<script>alert('ok');</script>");
                string qr = "";
                qr = "select * from user_data where email=:1 and password=:2";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleParameter email = new OracleParameter();
                email.OracleDbType = OracleDbType.Varchar2;
                email.Value = TextBox1.Text;

                OracleParameter pass = new OracleParameter();
                pass.OracleDbType = OracleDbType.Varchar2;
                pass.Value = TextBox2.Text;

                cmd.Parameters.Add(email);
                cmd.Parameters.Add(pass);

                OracleDataReader reder = cmd.ExecuteReader();
                if (reder.Read())
                {

                    //Response.Write("<script>alert('" + Session["u_name"] + "');</script>");
                    Response.Redirect("Home.aspx");
                    con.Close();
                }

                else
                {
                    error.Text = "Invalid email or password";
                    error.ForeColor = System.Drawing.Color.Red;
                    con.Close();
                    //Response.Write("<script>alert('Invalid email or password');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm15.aspx");
        }
    }
}