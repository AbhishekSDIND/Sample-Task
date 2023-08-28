using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace taks28
{
    public partial class FrmAdminReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        string query;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        public void DisplayData()
        { 
         DataTable dt = new DataTable();
            query = "SP_USERDETAIL";
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
           
            cmd.Parameters.AddWithValue("@MODE", "ADMIN_REPORTS");
            dt.Load(cmd.ExecuteReader());
            con.Close();
            if (dt.Rows.Count > 0)
            {
                dtAdminGrid.DataSource = dt;
                dtAdminGrid.DataBind();
            }
        }
    }
}