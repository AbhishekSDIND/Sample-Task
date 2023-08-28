using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using taks28.Models;

namespace taks28
{
    public partial class Login : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        string query;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Button_Click(object sender, EventArgs e)
        {
            RegisterModel objr = new RegisterModel();
            try
            {
                DataTable Dtget = new DataTable();
                objr.UserName = UserName.Text.Trim();
                objr.Password = Password.Text.Trim();
                objr.MODE = "USERS_LOGIN_SELECT";
                query = "SP_USERDETAIL";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@USER_NAME", objr.UserName);
                cmd.Parameters.AddWithValue("@USER_PASSWORD", objr.Password);
                cmd.Parameters.AddWithValue("@MODE", objr.MODE);
                Dtget.Load(cmd.ExecuteReader());
                con.Close();
                if (Dtget.Rows.Count > 0)
                {
                    int intcnt = Convert.ToInt16(Dtget.Rows[0]["CNT"]);
                    if (intcnt > 0)
                    {
                        Session["USER_NAME"] = objr.UserName;
                        Session["USER_TYPE"] = Dtget.Rows[0]["USER_TYPE"].ToString();

                        int userids= Convert.ToInt16(Dtget.Rows[0]["UserId"]);
                        Session["USER_IDS"] = userids;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Available')", true);
                        InsertLogData(userids);
                        Response.Redirect("FrmWelcome.aspx", false);
                    }
                    else 
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Available')", true);
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Available')", true);
            }
          
        }

        public void InsertLogData(int userids)
        {
            RegisterModel objr = new RegisterModel();
            try
            {
               
                objr.UserName = UserName.Text.Trim();
               
                objr.MODE = "USERS_LOG_INSERT";
                query = "SP_USERDETAIL";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;             
                cmd.Parameters.AddWithValue("@USER_NAME", objr.UserName);
                cmd.Parameters.AddWithValue("@UserId", userids);
                cmd.Parameters.AddWithValue("@MODE", objr.MODE);
                cmd.ExecuteNonQuery();
                con.Close();
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
               // ClearData();
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Inserted Successfully')", true);
            }
        }
    }
}