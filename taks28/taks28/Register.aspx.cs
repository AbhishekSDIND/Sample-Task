using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using taks28.Models;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace taks28
{
    public partial class Register : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        string query;
        SqlCommand cmd;
        protected System.Web.UI.HtmlControls.HtmlInputFile oFile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USER_IDS"] != null)
                {
                    String struser = Session["USER_IDS"].ToString();
                    GetData(Convert.ToInt16(struser));
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            RegisterModel objr = new RegisterModel();
            try
            {
                if (FirstName.Text == "" && FirstName.Text.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter First Name')", true);
                    FirstName.Focus();
                    return;
                }
                if (LastName.Text == "" && LastName.Text.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Last Name')", true);
                    LastName.Focus();
                    return;
                }
                if (UserName.Text == "" && UserName.Text.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter User Name')", true);
                    UserName.Focus();
                    return;
                }
                if (Password.Text == "" && Password.Text.Length == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Password')", true);
                    Password.Focus();
                    return;
                }
                objr.FirstName = FirstName.Text.Trim();
                objr.LastName = LastName.Text.Trim();
                objr.UserName = UserName.Text.Trim();
                objr.Password = Password.Text.Trim();
                if (UserType.SelectedItem.Text.Trim() == "Admin")
                {
                    objr.USER_TYPE = 1;
                }
                else if (UserType.SelectedItem.Text.Trim() == "Manager")
                {
                    objr.USER_TYPE = 2;
                }
                else if (UserType.SelectedItem.Text.Trim() == "Users")
                {
                    objr.USER_TYPE = 3;
                }
                
                query = "SP_USERDETAIL";
                con.Open();
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;              
                if (Session["USER_IDS"] != null)
                {
                    String struser = Session["USER_IDS"].ToString();
                    objr.MODE = "UPDATE";
                    cmd.Parameters.AddWithValue("@UserId", Convert.ToInt16(struser));
                }
                else 
                {
                    objr.MODE = "INSERT";                
                }
                cmd.Parameters.AddWithValue("@FIRST_NAME", objr.FirstName);
                cmd.Parameters.AddWithValue("@LAST_NAME", objr.LastName);
                cmd.Parameters.AddWithValue("@USER_NAME", objr.UserName);
                cmd.Parameters.AddWithValue("@USER_PASSWORD", objr.Password);
                cmd.Parameters.AddWithValue("@USER_TYPE", objr.USER_TYPE);
                cmd.Parameters.AddWithValue("@MODE", objr.MODE);
                cmd.ExecuteNonQuery();
                con.Close();
                if (Session["USER_IDS"] != null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Successfully')", true);
                    Session["USER_IDS"] = null;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                }
                ClearData();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Not Inserted Successfully')", true);
            }
            
        }
        public void ClearData()
        {
            FirstName.Text = "";
            LastName.Text = "";
            UserName.Text = "";
            Password.Text = "";
            UserType.SelectedIndex  = 0;
        }

        public void GetData(int uid)
        {
            DataTable dt = new DataTable();
            query = "SP_USERDETAIL";
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserId", uid);
            cmd.Parameters.AddWithValue("@MODE", "USER_PROFILE");
            dt.Load(cmd.ExecuteReader());
            con.Close();
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UserId.Text = uid.ToString();
                    FirstName.Text = dt.Rows[i]["FIRST_NAME"].ToString();
                    LastName.Text = dt.Rows[i]["LAST_NAME"].ToString();
                    UserName.Text = dt.Rows[i]["USER_NAME"].ToString();
                    Password.Text = dt.Rows[i]["USER_PASSWORD"].ToString();
                    if (dt.Rows[i]["USER_TYPE"].ToString() == "Users")
                    {
                        UserType.SelectedIndex = 3;
                    }
                    else if(dt.Rows[i]["USER_TYPE"].ToString() == "Manager")
                    {
                        UserType.SelectedIndex = 2;
                    }
                    else if (dt.Rows[i]["USER_TYPE"].ToString() == "Admin")
                    {
                        UserType.SelectedIndex = 1;
                    }
                }
            }
        }

        //protected void btnUpload_Click(object sender, EventArgs e)
        //{
        //    string strFileName;
        //    string strFilePath;
        //    string strFolder;
        //    strFolder = Server.MapPath("./");
        //    // Get the name of the file that is posted.
        //    strFileName = oFile.PostedFile.FileName;
        //    strFileName = Path.GetFileName(strFileName);
        //    if (oFile.Value != "")
        //    {
        //        // Create the directory if it does not exist.
        //        if (!Directory.Exists(strFolder))
        //        {
        //            Directory.CreateDirectory(strFolder);
        //        }
        //        // Save the uploaded file to the server.
        //        strFilePath = strFolder + strFileName;
        //        if (File.Exists(strFilePath))
        //        {
        //            lblUploadResult.Text = strFileName + " already exists on the server!";
        //        }
        //        else
        //        {
        //            oFile.PostedFile.SaveAs(strFilePath);
        //            lblUploadResult.Text = strFileName + " has been successfully uploaded.";
        //        }
        //    }
        //    else
        //    {
        //        lblUploadResult.Text = "Click 'Browse' to select the file to upload.";
        //    }
        //    // Display the result of the upload.
        //    frmConfirmation.Visible = true;
        //}
       
    }
}