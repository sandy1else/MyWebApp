using LogicLayer;
using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LogInProcedure()
        {
            try
            {
                string loginId = inputEmail.Value.Trim();
                string typedPassword = inputPassword.Value.Trim();
                bool isRemember = chkRemember.Checked;

                if (!string.IsNullOrEmpty(loginId) && !string.IsNullOrEmpty(typedPassword))
                {
                    User user = UserManager.UserGetByLoginId(loginId);

                    if (user != null)
                    {
                        string actualPassword = user.Password;
                        string decryptedPass = Utilites.Decrypt(actualPassword);

                        if (decryptedPass == typedPassword)
                        {
                            Session["CurrentUser"] = null;
                            Session["CurrentUser"] = user;

                            Response.Redirect("~/Home.aspx");

                        }
                        else
                        {
                            Response.Redirect("~/Login.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Only alert Message');", true);
                //lblError.Text = ex.Message;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LogInProcedure();
        }
    }
}