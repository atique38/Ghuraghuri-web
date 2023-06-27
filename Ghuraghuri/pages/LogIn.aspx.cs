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
    public partial class WebForm2 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       /* protected void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //con.Open();
                string qr = "";
                if (Session["user_login"].Equals("user"))
                {
                    Response.Write("<script>alert('" + Session["user_login"] + "');</script>");
                    qr = "select * from user_info where email=:1 and password=:2";
                }
                if (Session["agency_login"].Equals("agency"))
                {
                    qr = "select * from agency_info where email=:1 and password=:2";
                }
                if (Session["admin_login"].Equals("admin"))
                {
                    qr = "select * from admin_info where email=:1 and password=:2";
                }
                Response.Write("<script>alert('" + qr + "');</script>");
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleParameter email = new OracleParameter();
                email.OracleDbType = OracleDbType.Varchar2;
                email.Value = Text1.Value.ToString().Trim();

                OracleParameter pass = new OracleParameter();
                pass.OracleDbType = OracleDbType.Varchar2;
                pass.Value = Text2.Value.ToString().Trim();

                cmd.Parameters.Add(email);
                cmd.Parameters.Add(pass);
                Response.Write("<script>alert('" + qr + "');</script>");
                //Response.Write("<script>alert('" + Session["admin_login"] + "');</script>");

                OracleDataReader reder = cmd.ExecuteReader();
                if (reder.Read())
                {
                    Session["u_name"] = reder.GetValue(0).ToString();
                    Session["u_email"] = reder.GetValue(1).ToString();
                    //Response.Write("<script>alert('" + Session["u_name"] + "');</script>");
                    Response.Redirect("Home.aspx");
                    con.Close();
                }
                else
                {
                    error.Text = "Invalid email or password";
                    error.ForeColor = System.Drawing.Color.Red;
                    Response.Write("<script>alert('Invalid email or password');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }*/

        protected void Loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //Response.Write("<script>alert('ok');</script>");
                string qr = "";
                if (Session["login_opt"].Equals("user"))
                {
                    //Response.Write("<script>alert('" + Session["login_opt"] + "');</script>");
                    qr = "select * from user_info where email=:1";
                }
                else if (Session["login_opt"].Equals("admin"))
                {
                    qr = "select * from admin_info where email=:1";// and password=:2
                                                                   //Response.Write("<script>alert('" + Session["login_opt"] + "');</script>");
                }
                else if (Session["login_opt"].Equals("agency"))
                {
                    qr = "select * from agency_info where email=:1";// and password=:2
                    //Response.Write("<script>alert('" + Session["login_opt"] + "');</script>");
                }
                OracleCommand cmd = new OracleCommand(qr, con);
                OracleParameter email = new OracleParameter();
                email.OracleDbType = OracleDbType.Varchar2;
                email.Value = Text1.Value.ToString().Trim();

               /* OracleParameter pass = new OracleParameter();
                pass.OracleDbType = OracleDbType.Varchar2;
                pass.Value = Text2.Value.ToString().Trim();*/

                cmd.Parameters.Add(email);
                //cmd.Parameters.Add(pass);
                

                OracleDataReader reder = cmd.ExecuteReader();
                if (reder.Read())
                {
                    string enteredPass= Text2.Value.ToString().Trim();
                    string pass = reder["PASSWORD"].ToString();
                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(enteredPass, pass);

                    if (isPasswordValid)
                    {
                        if (Session["login_opt"].Equals("agency"))
                        {
                            Session["ag_name"] = reder.GetValue(0).ToString();
                            Session["u_name"] = reder.GetValue(1).ToString();
                            Session["u_email"] = reder.GetValue(2).ToString();
                            Session["address"] = reder.GetValue(4).ToString();
                            Session["status"] = reder.GetValue(5).ToString();
                        }
                        else
                        {
                            Session["u_name"] = reder.GetValue(0).ToString();
                            Session["u_email"] = reder.GetValue(1).ToString();
                        }
                        con.Close();
                        Response.Redirect("Home.aspx");
                        
                    }
                    else
                    {
                        error.Text = "Invalid Password.";
                        error.ForeColor = System.Drawing.Color.Red;
                    }
                    
                }
                
                else
                {
                    error.Text = "User not exist.";
                    error.ForeColor = System.Drawing.Color.Red;
                    //Response.Write("<script>alert('Invalid email or password');</script>");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            
        }
    }
}