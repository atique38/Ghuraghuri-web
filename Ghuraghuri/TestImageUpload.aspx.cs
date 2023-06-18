using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;

namespace Ghuraghuri
{

    public partial class TestImageUpload : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int i;
                for(i=0;i<Request.Files.Count;i++)
                {
                    var file = Request.Files[i];
                    if(file.ContentLength > 0)
                    {
                        byte[] imageData;
                        var stream = file.InputStream;
                        imageData = new byte[stream.Length];
                        stream.Read(imageData, 0, (int)stream.Length);

                        string sql = "INSERT INTO image (pic) VALUES (:imageData)";
                        OracleCommand cmd = new OracleCommand(sql, con);
                        cmd.Parameters.Add(":imageData", OracleDbType.Blob).Value = imageData;
                        cmd.ExecuteNonQuery();
                    }
                }
                Response.Write("Images uploaded successfully!");
                con.Close();
                
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                Response.Write(msg);
            }
        }

        protected void Display_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "SELECT pic FROM image";
                OracleCommand cmd=new OracleCommand(sql, con);
                OracleDataReader reader=cmd.ExecuteReader();

                while(reader.Read())
                {
                    byte[] imageData = (byte[])reader["pic"];
                    string base64Image = Convert.ToBase64String(imageData);
                    string imageUrl = "data:image/jpeg;base64," + base64Image;

                    HtmlImage image = new HtmlImage();
                    image.Src=imageUrl;
                    container.Controls.Add(image);
                    
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Response.Write(msg);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] image1Data = fileUpload1.FileBytes;
                byte[] image2Data = fileUpload2.FileBytes;

                con.Open();
                string sql = "INSERT INTO image (featured) VALUES (:imageData)";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.Parameters.Add(":imageData", OracleDbType.Blob).Value = image1Data;
                cmd.ExecuteNonQuery();


                string sql2 = "INSERT INTO image (gallery) VALUES (:imageData2)";
                OracleCommand cmd2 = new OracleCommand(sql2, con);
                cmd2.Parameters.Add(":imageData2", OracleDbType.Blob).Value = image2Data;
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Response.Write(msg);
            }
            

        }
    }
}