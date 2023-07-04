using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitProduct_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string content = tiny.Text;
                byte[] img1 = featuredUpload.FileBytes;
                string qr1 = "INSERT INTO product (PRODUCT_NAME,PRICE,PRODUCT_DETAILS,RATINGS,QUANTITY,IMAGE) VALUES (:name, :price, :detail, :rating, :quantity, :image)";

                OracleCommand cmd1 = new OracleCommand(qr1, con);
               
                cmd1.Parameters.Add(":name", OracleDbType.Varchar2).Value = pd_name.Text.ToString().Trim();
                cmd1.Parameters.Add(":price", OracleDbType.Int32).Value = Cost.Text;
                cmd1.Parameters.Add(":detail", OracleDbType.Clob).Value = content;
                cmd1.Parameters.Add(":rating", OracleDbType.Decimal).Value = rtBox.Text;
                cmd1.Parameters.Add(":quantity", OracleDbType.Int32).Value = pd_quantity.Text;
                cmd1.Parameters.Add(":image", OracleDbType.Blob).Value = img1;
                

                //Response.Write("<script>alert('" + content + "');</script>");

                //byte[] img2 = galleryUpload.FileBytes;


                cmd1.ExecuteNonQuery();

                string query = "SELECT id FROM (select * from product order by id desc) where rownum=1";
                OracleCommand command = new OracleCommand(query, con);
                int cnt = Convert.ToInt32(command.ExecuteScalar());
                //Response.Write("<script>alert('" + cnt + "');</script>");

                foreach (HttpPostedFile postedFile in galleryUpload.PostedFiles)
                {
                    byte[] fileData;
                    BinaryReader reader = new BinaryReader(postedFile.InputStream);
                    fileData = reader.ReadBytes(postedFile.ContentLength);

                    string qr2 = "INSERT INTO product_gallery (id,image_data) VALUES (:id,:FileData)";
                    OracleCommand cmd2 = new OracleCommand(qr2, con);

                    cmd2.Parameters.Add(":id", OracleDbType.Int32).Value = cnt;
                    cmd2.Parameters.Add(":FileData", OracleDbType.Blob).Value = fileData;
                    cmd2.ExecuteNonQuery();

                }
                error.Text = "Added Successfully.";
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