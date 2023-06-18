using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Runtime.Remoting.Contexts;
using System.Text.Encodings.Web;

namespace Ghuraghuri.tinyMce
{
    public partial class tinytest2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            try
            {
                string content = Server.HtmlEncode(tiny.InnerText.ToString());
                //Response.Write("<script>alert('" +content+ "');</script>");
                //string dc = Server.HtmlDecode(content);
                //newdiv.InnerHtml= dc;
                //Response.Write("<script>alert('" + dc + "');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
           

        }
    }
}