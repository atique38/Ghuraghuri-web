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
                        //Response.Write("<script>alert('ok');</script>");
                        /*
                        if (imageData != null)
                        {
                            string base64Image = Convert.ToBase64String(imageData);
                            string imageUrl = "data:image/jpeg;base64," + base64Image;
                            ClientScript.RegisterStartupScript(this.GetType(), "image", "setImage('" + imageUrl + "');", true);
                        }*/

                        if (!reader.IsDBNull(reader.GetOrdinal("profile_image")))
                        {
                            byte[] imageData = (byte[])reader["profile_image"];
                            string base64Image = Convert.ToBase64String(imageData);
                            string imageUrl = "data:image/jpeg;base64," + base64Image;
                            ClientScript.RegisterStartupScript(this.GetType(), "image", "setImage('" + imageUrl + "');", true);
                        }


                        string name, pass, displayName;
                        name = reader["NAME"].ToString();
                        pass = reader["PASSWORD"].ToString();
                        displayName = reader["DISPLAYNAME"].ToString();
                        U_Name.InnerText = name;
                        //Response.Write("<script>alert('" + name + "');</script>");

                    }



                    con.Close();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    Response.Write("<script>alert('" + msg + "');</script>");
                }
            }
            try
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
            }
           
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
        
    }
}