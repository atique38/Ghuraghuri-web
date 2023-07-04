using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitTour_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string content = tiny.Text;
                string qr1 = "INSERT INTO tour (agency_email,tour_name,price,tour_duration,description,photo,ratings) VALUES (:email, :name, :price, :duration, :description, :image,:rt)";
                string email = Session["u_email"].ToString();
                OracleCommand cmd1 = new OracleCommand(qr1, con);
                cmd1.Parameters.Add(":email", OracleDbType.Varchar2).Value = email;
                cmd1.Parameters.Add(":name", OracleDbType.Varchar2).Value = Tr_name.Text.ToString().Trim();
                cmd1.Parameters.Add(":price", OracleDbType.Int32).Value = Cost.Text;
                cmd1.Parameters.Add(":duration", OracleDbType.Varchar2).Value = Dur.Text.ToString().Trim();
                
                
                //Response.Write("<script>alert('" + content + "');</script>");
                byte[] img1 = featuredUpload.FileBytes;
                //byte[] img2 = galleryUpload.FileBytes;
                cmd1.Parameters.Add(":description", OracleDbType.Clob).Value = content;
                cmd1.Parameters.Add(":image", OracleDbType.Blob).Value = img1;
                cmd1.Parameters.Add(":rt", OracleDbType.Decimal).Value = rt_tour.Text;
                cmd1.ExecuteNonQuery();

                string query = "SELECT id FROM (select * from tour order by id desc) where rownum=1";
                OracleCommand command = new OracleCommand(query, con);
                int cnt = Convert.ToInt32(command.ExecuteScalar());
                //Response.Write("<script>alert('" + cnt + "');</script>");

                foreach (HttpPostedFile postedFile in galleryUpload.PostedFiles)
                {
                    byte[] fileData;
                    BinaryReader reader = new BinaryReader(postedFile.InputStream);
                    fileData = reader.ReadBytes(postedFile.ContentLength);

                    string qr2 = "INSERT INTO tour_gallery (id,image_data) VALUES (:id,:FileData)";
                    OracleCommand cmd2 = new OracleCommand(qr2, con);

                    cmd2.Parameters.Add(":id", OracleDbType.Int32).Value = cnt;
                    cmd2.Parameters.Add(":FileData", OracleDbType.Blob).Value = fileData;
                    cmd2.ExecuteNonQuery();

                }
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