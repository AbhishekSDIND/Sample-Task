using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace taks28
{
    public partial class FrmWelcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               if (Session["USER_NAME"] != null)
                {
                    // Session["FirstName"] = "Sarthak";
                    // Session["LastName"] = " Varshney";
                    lblusername.Text = "Welcome " + Session["USER_NAME"];// + Session["LastName"];
                    lblUsertype.Text= Session["USER_TYPE"].ToString();
                }
               else
               {
                    lblusername.Text = "Welcome " + Session["USER_NAME"];
                    lblUsertype.Text = Session["USER_TYPE"].ToString();
                    //lblString.Text = Session["FirstName"] + " " + Session["LastName"];
                    //lblfName.Text = Session["FirstName"].ToString();
                    //lbllName.Text = Session["LastName"].ToString();
                }
            }
        }

        protected void LnkReport_Click(object sender, EventArgs e)
        {
            string strusertype = Session["USER_TYPE"].ToString();
            if (strusertype == "Admin")
            {
                Response.Redirect("FrmAdminReport.aspx", false);
            }
            else if (strusertype == "Manager")
            {
                Response.Redirect("FrmManagerReport.aspx", false);
            }
            else if (strusertype == "Users")
            {
                Response.Redirect("Register.aspx", false);
            }
        }
    }
}