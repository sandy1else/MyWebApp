using LogicLayer;
using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp.Login
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
                string loginId = txtLoginId.Text.Trim();
                string typedPassword = txtPassword.Text.Trim();

                if (!string.IsNullOrEmpty(loginId) && !string.IsNullOrEmpty(typedPassword))
                {
                    User user = UserManager.UserGetByLoginId(loginId);

                    if (user != null)
                    {
                        string actualPassword = user.Password;
                        string dcdc = Utilites.EncryptString(actualPassword);
                        if (actualPassword == typedPassword)
                        {
                            Session["CurrentUser"] = null;
                            Session["CurrentUser"] = user;

                            Response.Redirect("~/Login/Home.aspx");

                        }
                        else
                        {
                            Response.Redirect("~/Login/Login.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Login/Login.aspx");
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LogInProcedure();
        }
    }
}