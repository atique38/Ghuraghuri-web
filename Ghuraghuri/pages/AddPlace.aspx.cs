using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if(!IsPostBack)
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM spot";
                OracleCommand command = new OracleCommand(query, con);
                cnt = Convert.ToInt32(command.ExecuteScalar());
                con.Close();
            }*/
            
        }

        protected void Submit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string content = tiny.Text;
                string qr1 = "INSERT INTO spot (spot_name,spot_type,location,description,featured_photo) VALUES (:name, :type, :loc, :description, :fetured)";
                
                OracleCommand cmd1 = new OracleCommand(qr1, con);
                cmd1.Parameters.Add(":name", OracleDbType.Varchar2).Value = PlaceName.Text.ToString().Trim();
                cmd1.Parameters.Add(":type", OracleDbType.Varchar2).Value = PlaceType.Text.ToString().Trim();
                cmd1.Parameters.Add(":loc", OracleDbType.Varchar2).Value = PlaceLocation.Text.ToString().Trim();

                
                //Response.Write("<script>alert('" + content + "');</script>");
                byte[] img1 = featuredUpload.FileBytes;
                //byte[] img2 = galleryUpload.FileBytes;
                cmd1.Parameters.Add(":description", OracleDbType.Clob).Value = content;
                cmd1.Parameters.Add(":featured", OracleDbType.Blob).Value = img1;
                cmd1.ExecuteNonQuery();

                string query = "SELECT id FROM (select * from spot order by id desc) where rownum=1";
                OracleCommand command = new OracleCommand(query, con);
                int cnt = Convert.ToInt32(command.ExecuteScalar());
                //Response.Write("<script>alert('" + cnt + "');</script>");

                foreach (HttpPostedFile postedFile in galleryUpload.PostedFiles)
                {
                    byte[] fileData;
                    BinaryReader reader = new BinaryReader(postedFile.InputStream);
                    fileData = reader.ReadBytes(postedFile.ContentLength);

                    string qr2 = "INSERT INTO gallery (id,image_data) VALUES (:id,:FileData)";
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