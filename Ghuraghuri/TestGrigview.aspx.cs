using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ghuraghuri
{
    public partial class TestGrigview : System.Web.UI.Page
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            // Fetch data from the Oracle database
            DataTable dataTable = GetDataFromOracle();

            // Bind the data to the GridView control
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }

        private DataTable GetDataFromOracle()
        {
            // Create a new DataTable to hold the data
            DataTable dataTable = new DataTable();

            // Fetch data from the Oracle database using the connection string
            string query = "SELECT * FROM user_info";
            OracleDataAdapter adapter = new OracleDataAdapter(query, con);

            // Fill the DataTable with data from the Oracle database
            adapter.Fill(dataTable);

            return dataTable;
        }
    }
}