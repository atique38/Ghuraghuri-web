using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BCrypt.Net;
using System.Data;
using System.Xml.Linq;

namespace Ghuraghuri.pages
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login_opt"]!=null && Session["login_opt"].Equals("user"))
            {
                proPic.Visible = true;
                u_info.Visible = true;
                u_pass.Visible = true;
                ag_info.Visible = false;
                ag_pass.Visible = false;
                ad_info.Visible = false;
                ad_pass.Visible = false;

                try
                {
                    con.Open();
                    string userEmail = Session["u_email"].ToString();
                    u_email.InnerText = userEmail;
                    string sql = "SELECT * FROM user_info where email=:em";
                    OracleCommand cmd = new OracleCommand(sql, con);

                    cmd.Parameters.Add(":em", OracleDbType.Varchar2).Value = userEmail;
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        
                        if (!reader.IsDBNull(reader.GetOrdinal("profile_image")))
                        {
                            byte[] imageData = (byte[])reader["profile_image"];
                            string base64Image = Convert.ToBase64String(imageData);
                            string imageUrl = "data:image/jpeg;base64," + base64Image;
                            ClientScript.RegisterStartupScript(this.GetType(), "image", "setImage('" + imageUrl + "');", true);
                        }


                        string name, phn, displayName,gender;
                        name = reader["NAME"].ToString();
                        //pass = reader["PASSWORD"].ToString();
                        displayName = reader["DISPLAYNAME"].ToString();
                        phn = reader["PHONE_NO"].ToString();
                        gender = reader["GENDER"].ToString();
                        U_Name.InnerText = name;
                        u_disName.InnerText = displayName;
                        u_phn.InnerText = phn;
                        u_gender.InnerText = gender;

                        //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pass);
                        //error.Text = pass;
                    }



                    con.Close();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    Response.Write("<script>alert('" + msg + "');</script>");
                }
            }
            else if (Session["login_opt"] != null && Session["login_opt"].Equals("agency"))
            {
                proPic.Visible = false;
                u_info.Visible = false;
                u_pass.Visible = false;
                ag_info.Visible = true;
                ag_pass.Visible = true;
                ad_info.Visible = false;
                ad_pass.Visible = false;

                try
                {
                    con.Open();
                    string userEmail = Session["u_email"].ToString();
                    agEmail.InnerText = userEmail;
                    string sql = "SELECT * FROM agency_info where email=:em";
                    OracleCommand cmd = new OracleCommand(sql, con);

                    cmd.Parameters.Add(":em", OracleDbType.Varchar2).Value = userEmail;
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        string agname, ownername, adrs,phone;
                        agname = reader["AGENCY_NAME"].ToString();
                        ownername = reader["OWNER_NAME"].ToString();
                        //pass = reader["PASSWORD"].ToString();
                        adrs = reader["ADDRESS"].ToString();
                        phone = reader["PHONE"].ToString();
                        agName.InnerText = agname;
                        ownName.InnerText=ownername;
                        ag_adrs.InnerText = adrs;
                        ag_phn.InnerText = phone;


                        //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pass);
                        //error.Text = pass;
                    }



                    con.Close();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    Response.Write("<script>alert('" + msg + "');</script>");
                }
            }
            else if (Session["login_opt"] != null && Session["login_opt"].Equals("admin"))
            {
                proPic.Visible = false;
                u_info.Visible = false;
                u_pass.Visible = false;
                ag_info.Visible = false;
                ag_pass.Visible = false;
                ad_info.Visible = true;
                ad_pass.Visible = true;

                try
                {
                    
                    string userEmail = Session["u_email"].ToString();
                    ad_email.InnerText = userEmail;
                   con.Close();
                    
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    Response.Write("<script>alert('" + msg + "');</script>");
                }
            }
            /*try
            {
                con.Open();
                string sql = "SELECT profile_image FROM user_info where email=:em";
                OracleCommand cmd = new OracleCommand(sql, con);
                string userEmail = Session["u_email"].ToString();
                cmd.Parameters.Add(":em", OracleDbType.Varchar2).Value = userEmail;

                OracleDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    //Response.Write("<script>alert('ok');</script>");
                    byte[] imageData = (byte[])reader["profile_image"];
                    string base64Image = Convert.ToBase64String(imageData);
                    string imageUrl = "data:image/jpeg;base64," + base64Image;
                    ClientScript.RegisterStartupScript(this.GetType(), "image", "setImage('" + imageUrl + "');", true);
                }
               


                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Response.Write("<script>alert('"+ msg+"');</script>");
            }*/

        }

        protected void ImageUpload_Click(object sender, EventArgs e)
        {
            try
            {
               
                con.Open();
                
                var file = Request.Files[0];
                byte[] imageData;
                var stream = file.InputStream;
                imageData = new byte[stream.Length];
                stream.Read(imageData, 0, (int)stream.Length);
                //Response.Write("<script>alert('" + imageData + "');</script>");
                string sql = "update user_info set profile_image=:imageData where email=:em";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.Parameters.Add(":imageData", OracleDbType.Blob).Value = imageData;
                cmd.Parameters.Add(":em", OracleDbType.Varchar2).Value = "abc@gmail.com";
                cmd.ExecuteNonQuery();
                
                //Response.Write("<script>alert('Refresh the page to see updated photo');</script>");
                con.Close();
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Response.Write("<script>alert('" + msg + "');</script>"); 

            }
        }

        protected void u_pass_update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string userEmail = Session["u_email"].ToString();

                string sql = "SELECT PASSWORD FROM user_info where email=:em";
                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.Parameters.Add(":em", OracleDbType.Varchar2).Value = userEmail;
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string pass = reader["PASSWORD"].ToString();

                    string curr, newPass, confPass;
                    curr = TextBox3.Text.Trim();
                    newPass = TextBox1.Text.Trim();
                    confPass = TextBox2.Text.Trim();

                    if (string.IsNullOrEmpty(curr) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confPass))
                    {
                        u_error.Text = "Empty field not allowed";
                    }
                    else
                    {
                        bool matched = BCrypt.Net.BCrypt.Verify(curr, pass);
                        if (matched)
                        {
                            if (newPass.Equals(confPass))
                            {
                                string hashedPass = BCrypt.Net.BCrypt.HashPassword(newPass);
                                string passQr = "update user_info set password='" + hashedPass + "' where email='" + userEmail + "'";
                                OracleCommand command = new OracleCommand(passQr, con);
                                int x = command.ExecuteNonQuery();
                                if (x > 0)
                                {
                                    u_done.Text = "Password changed";
                                    Session.Abandon();
                                    Session.Clear();
                                    Session["isLogout"] = true;
                                    //Session["login_opt"] = "user";
                                    con.Close();
                                    Response.Redirect("LogInOption.aspx");
                                }
                            }
                            else
                            {
                                u_error.Text = "Password not matched";
                            }
                        }
                        else
                        {
                            u_error.Text = "Invalid Password";
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                u_error.Text= msg;
            }
            
        }

        protected void ag_pass_update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string userEmail = Session["u_email"].ToString();

                string sql = "SELECT PASSWORD FROM agency_info where email=:em";
                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.Parameters.Add(":em", OracleDbType.Varchar2).Value = userEmail;
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string pass = reader["PASSWORD"].ToString();

                    string curr, newPass, confPass;
                    curr = TextBox4.Text.Trim();
                    newPass = TextBox5.Text.Trim();
                    confPass = TextBox6.Text.Trim();

                    if (string.IsNullOrEmpty(curr) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confPass))
                    {
                        u_error.Text = "Empty field not allowed";
                    }
                    else
                    {
                        bool matched = BCrypt.Net.BCrypt.Verify(curr, pass);
                        if (matched)
                        {
                            if (newPass.Equals(confPass))
                            {
                                string hashedPass = BCrypt.Net.BCrypt.HashPassword(newPass);
                                string passQr = "update agency_info set password='" + hashedPass + "' where email='" + userEmail + "'";
                                OracleCommand command = new OracleCommand(passQr, con);
                                int x = command.ExecuteNonQuery();
                                if (x > 0)
                                {
                                    ag_done.Text = "Password changed";
                                    Session.Abandon();
                                    Session.Clear();
                                    Session["isLogout"] = true;
                                    //Session["login_opt"] = "agency";
                                    con.Close();
                                    Response.Redirect("LogInOption.aspx");
                                }
                            }
                            else
                            {
                                ag_error.Text = "Password not matched";
                            }
                        }
                        else
                        {
                            ag_error.Text = "Invalid Password";
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                u_error.Text = msg;
            }
        }

        protected void ad_update_pass_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                string userEmail = Session["u_email"].ToString();
                
                string sql = "SELECT PASSWORD FROM ADMIN_INFO where email=:em";
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                ad_error.Text = userEmail;
                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.Parameters.Add(":em", OracleDbType.Varchar2).Value = userEmail;
                OracleDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    
                    string pass = reader["PASSWORD"].ToString();

                    string curr, newPass, confPass;
                    curr = TextBox7.Text.Trim();
                    newPass = TextBox8.Text.Trim();
                    confPass = TextBox9.Text.Trim();

                    if (string.IsNullOrEmpty(curr) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confPass))
                    {
                        u_error.Text = "Empty field not allowed";
                    }
                    else
                    {
                        bool matched = BCrypt.Net.BCrypt.Verify(curr, pass);
                        if (matched)
                        {
                            if (newPass.Equals(confPass))
                            {
                                string hashedPass = BCrypt.Net.BCrypt.HashPassword(newPass);
                                string passQr = "update ADMIN_INFO set password='" + hashedPass + "' where email='" + userEmail + "'";
                                OracleCommand command = new OracleCommand(passQr, con);
                                int x = command.ExecuteNonQuery();
                                if (x > 0)
                                {
                                    //ag_done.Text = "Password changed";
                                    Session.Abandon();
                                    Session.Clear();
                                    Session["isLogout"] = true;
                                    //Session["login_opt"] = "agency";
                                    con.Close();
                                    Response.Redirect("LogInOption.aspx");
                                }
                            }
                            else
                            {
                                ad_error.Text = "Password not matched";
                            }
                        }
                        else
                        {
                            ad_error.Text = "Invalid Password";
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                u_error.Text = msg;
            }
        }

        protected void U_NameEdt_Click(object sender, EventArgs e)
        {
            try
            {
                
                string name = TextBox10.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    uname_edt_error.Text = "Empty field not allowed";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string userEmail = Session["u_email"].ToString();
                    string qr = "update user_info set NAME='" + name + "' where email='" + userEmail + "'";
                    OracleCommand cmd= new OracleCommand(qr,con);
                    int x=cmd.ExecuteNonQuery();
                    if(x > 0)
                    {
                        U_Name.InnerText = name;
                        uname_edt_error.Text = "Successful";
                    }
                    con.Close() ;
                }
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                uname_edt_error.Text = msg;
            }
        }

        protected void DisnameEdt_Click(object sender, EventArgs e)
        {
            try
            {

                string txt = TextBox16.Text.Trim();
                if (string.IsNullOrEmpty(txt))
                {
                    Label1.Text = "Empty field not allowed";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string userEmail = Session["u_email"].ToString();
                    string qr = "update user_info set DISPLAYNAME='" + txt + "' where email='" + userEmail + "'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        u_disName.InnerText = txt;
                        Label1.Text = "Successful";
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label1.Text = msg;
            }
        }

        protected void U_phn_edt_Click(object sender, EventArgs e)
        {
            try
            {

                string txt = TextBox11.Text.Trim();
                if (string.IsNullOrEmpty(txt))
                {
                    Label2.Text = "Empty field not allowed";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string userEmail = Session["u_email"].ToString();
                    string qr = "update user_info set PHONE_NO='" + txt + "' where email='" + userEmail + "'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        u_phn.InnerText = txt;
                        Label2.Text = "Successful";
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label2.Text = msg;
            }
        }

        protected void GenderEdt_Click(object sender, EventArgs e)
        {
            try
            {

                string txt = RadioButtonList1.SelectedItem.Text;
                if (string.IsNullOrEmpty(txt))
                {
                    Label3.Text = "Empty field not allowed";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string userEmail = Session["u_email"].ToString();
                    string qr = "update user_info set GENDER='" + txt + "' where email='" + userEmail + "'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        u_gender.InnerText = txt;
                        Label3.Text = "Successful";
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label3.Text = msg;
            }
        }

        protected void ag_name_edt_Click(object sender, EventArgs e)
        {
            try
            {

                string txt = TextBox12.Text.Trim();
                if (string.IsNullOrEmpty(txt))
                {
                    Label4.Text = "Empty field not allowed";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string userEmail = Session["u_email"].ToString();
                    string qr = "update agency_info set AGENCY_NAME='" + txt + "' where email='" + userEmail + "'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        agName.InnerText = txt;
                        Session["ag_name"] = txt;
                        Label4.Text = "Successful";
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label4.Text = msg;
            }
        }

        protected void ag_ownername_edt_Click(object sender, EventArgs e)
        {
            try
            {

                string txt = TextBox13.Text.Trim();
                if (string.IsNullOrEmpty(txt))
                {
                    Label5.Text = "Empty field not allowed";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string userEmail = Session["u_email"].ToString();
                    string qr = "update agency_info set OWNER_NAME='" + txt + "' where email='" + userEmail + "'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        ownName.InnerText = txt;
                        Session["u_name"] = txt;
                        Label5.Text = "Successful";
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label5.Text = msg;
            }
        }

        protected void ag_phn_edt_Click(object sender, EventArgs e)
        {
            try
            {

                string txt = TextBox14.Text.Trim();
                if (string.IsNullOrEmpty(txt))
                {
                    Label6.Text = "Empty field not allowed";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string userEmail = Session["u_email"].ToString();
                    string qr = "update agency_info set PHONE='" + txt + "' where email='" + userEmail + "'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        ag_phn.InnerText = txt;
                        //Session["u_name"] = txt;
                        Label6.Text = "Successful";
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label6.Text = msg;
            }
        }

        protected void ag_adrs_edt_Click(object sender, EventArgs e)
        {
            try
            {

                string txt = TextBox15.Text.Trim();
                if (string.IsNullOrEmpty(txt))
                {
                    Label7.Text = "Empty field not allowed";
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string userEmail = Session["u_email"].ToString();
                    string qr = "update agency_info set ADDRESS='" + txt + "' where email='" + userEmail + "'";
                    OracleCommand cmd = new OracleCommand(qr, con);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        ag_adrs.InnerText = txt;
                        //Session["u_name"] = txt;
                        Label7.Text = "Successful";
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Label7.Text = msg;
            }
        }
    }
}