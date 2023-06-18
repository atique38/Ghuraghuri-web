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
    public partial class SignUpAgency : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
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
                    agencySignUp();
                }

                
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
                string qr = "select * from agency_info where email=:1";
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleParameter email = new OracleParameter();
                email.OracleDbType = OracleDbType.Varchar2;
                email.Value = Text3.Value.ToString().Trim();
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

        void agencySignUp()
        {
            con.Open();

            string qr = "insert into agency_info (agency_name,owner_name,email,password,address,status) values(:1, :2, :3, :4, :5,'Pending')";
            OracleCommand cmd = new OracleCommand(qr, con);
            OracleParameter agency_name = new OracleParameter();
            agency_name.OracleDbType = OracleDbType.Varchar2;
            agency_name.Value = Text1.Value.ToString().Trim();

            OracleParameter owner_name = new OracleParameter();
            owner_name.OracleDbType = OracleDbType.Varchar2;
            owner_name.Value = Text2.Value.ToString().Trim();

            OracleParameter email = new OracleParameter();
            email.OracleDbType = OracleDbType.Varchar2;
            email.Value = Text3.Value.ToString().Trim();

            OracleParameter pass = new OracleParameter();
            pass.OracleDbType = OracleDbType.Varchar2;
            pass.Value = Text4.Value.ToString().Trim();

            OracleParameter address = new OracleParameter();
            address.OracleDbType = OracleDbType.Varchar2;
            address.Value = Text5.Value.ToString().Trim();

            cmd.Parameters.Add(agency_name);
            cmd.Parameters.Add(owner_name);
            cmd.Parameters.Add(email);
            cmd.Parameters.Add(pass);
            cmd.Parameters.Add(address);

            int ok=cmd.ExecuteNonQuery();
            con.Close();
            if(ok>0)
            {
                Session["login_opt"] = "agency";
                Response.Redirect("LogIn.aspx");
            }

        }
    }
}