using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace Ghuraghuri.pages
{
    public partial class SignUp : System.Web.UI.Page
    {
        OracleConnection con=new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckDuplicate())
                {
                    //Response.Write("<script>alert('User already exits');</script>");
                    error.Text = "User already exits!";
                    error.ForeColor= System.Drawing.Color.Red;
                }
                else
                {
                    userSignUp();
                }
                
                /*if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string qr = "insert into user_info (name,email,password) values(:1, :2, :3)";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleParameter name = new OracleParameter();
                name.OracleDbType = OracleDbType.Varchar2;
                name.Value = u_name.Value.ToString().Trim();

                OracleParameter email = new OracleParameter();
                email.OracleDbType = OracleDbType.Varchar2;
                email.Value = u_email.Value.ToString().Trim();

                OracleParameter pass = new OracleParameter();
                pass.OracleDbType = OracleDbType.Varchar2;
                pass.Value = u_pass.Value.ToString().Trim();

                cmd.Parameters.Add(name);
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(pass);

                cmd.ExecuteNonQuery();*/
            }
            catch(Exception ex) {
                Response.Write("<script>alert('" + ex.Message+"');</script>");
            }
            

           
        }

       

        bool CheckDuplicate()
        {
            try
            {
                con.Open();
                string qr = "select * from user_info where email=:1";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleParameter email = new OracleParameter();
                email.OracleDbType = OracleDbType.Varchar2;
                email.Value = u_email.Value.ToString().Trim();
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
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            return false;
        }

        void userSignUp()
        {
            con.Open();

            string qr = "insert into user_info (name,email,password,displayname,phone_no) values(:1, :2, :3, :4, :5)";
            OracleCommand cmd = new OracleCommand(qr, con);
            OracleParameter name = new OracleParameter();
            name.OracleDbType = OracleDbType.Varchar2;
            name.Value = u_name.Value.ToString().Trim();

            OracleParameter email = new OracleParameter();
            email.OracleDbType = OracleDbType.Varchar2;
            email.Value = u_email.Value.ToString().Trim();

            OracleParameter pass = new OracleParameter();
            pass.OracleDbType = OracleDbType.Varchar2;
            pass.Value = u_pass.Value.ToString().Trim();

            OracleParameter dis_name = new OracleParameter();
            dis_name.OracleDbType = OracleDbType.Varchar2;
            dis_name.Value = DisplayName.Value.ToString().Trim();

            OracleParameter phone = new OracleParameter();
            phone.OracleDbType = OracleDbType.Varchar2;
            phone.Value = Phone.Value.ToString().Trim();

            cmd.Parameters.Add(name);
            cmd.Parameters.Add(email);
            cmd.Parameters.Add(pass);
            cmd.Parameters.Add(dis_name);
            cmd.Parameters.Add(phone);

            int x = cmd.ExecuteNonQuery();
            if (x>0)
            {
                Session["login_opt"] = "user";
                Response.Redirect("LogIn.aspx");
            }
            con.Close();

        }
    }
}