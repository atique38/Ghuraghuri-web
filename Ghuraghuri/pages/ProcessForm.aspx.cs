using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri.pages
{
    public partial class ProcessForm : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //string content = Request.Form["hiddenField"];
            //Label1.Text = content;

           /* string data = Request.QueryString["data"];
            Response.Write(data);*/
            /*con.Open();
            string content = Request.Form["hiddenField"];
            OracleCommand cmd = new OracleCommand("INSERT INTO TINY (text) VALUES (:content)", con);
            cmd.Parameters.Add(":content", OracleDbType.Clob).Value = content;
            cmd.ExecuteNonQuery();
            con.Close();*/

            string str = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nesciunt voluptatem commodi earum in verita.";
            Response.Write(str.Length);

            string content = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam placerat metus venenatis fringilla ornare. Sed luctus quis nunc sed hendrerit. Praesent vestibulum congue massa, non lacinia lacus pretium vitae. In congue id purus non eleifend. Pellentesque sollicitudin arcu quam, eget cursus dolor iaculis nec. In nec orci fermentum, euismod diam eget, luctus augue. Nunc aliquam quam ex, eget laoreet libero mollis in. Pellentesque ultricies ultricies felis ut volutpat. Donec sit amet tortor nisi. Phasellus aliquet ut quam ac iaculis. Nam egestas dictum enim et maximus. Donec dignissim ex dui, vitae commodo dui varius ultricies. Cras efficitur lobortis tortor eget fermentum. Phasellus quis condimentum dolor. Vivamus tincidunt tellus sit amet hendrerit pellentesque. Integer ac elit vitae dui fermentum rhoncus.</>";
            string plaintext = Regex.Replace(content, "<.*?>", String.Empty);

            string cut = plaintext.Length <= 105 ? plaintext : plaintext.Substring(0, 105)+"...";
            Response.Write(cut);

            DateTime date = DateTime.Now;
            string strdate = date.ToString("dd MMM, yyyy");
            Response.Write(strdate);
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string selectedRating = Request.Form["rating"];
            Response.Write(selectedRating);
        }
    }
}