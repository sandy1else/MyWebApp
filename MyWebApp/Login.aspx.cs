using LogicLayer;
using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using LogLayer.BusinessLogic;
using LogLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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
                //bool isRemember = chkRemember.Checked;

                if (!string.IsNullOrEmpty(loginId) && !string.IsNullOrEmpty(typedPassword))
                {
                    User user = UserManager.UserGetByLoginId(loginId);

                    if (user != null)
                    {
                        string actualPassword = user.Password;
                        string encryptedPass = Utilites.Encrypt(typedPassword);

                        if (actualPassword == encryptedPass)
                        {
                            Session["CurrentUser"] = null;
                            Session["CurrentUser"] = user;

                            string message = "Login Success";
                            bool isSuccess = true;
                            SaveLog(message, isSuccess);

                            Response.Redirect("~/Home.aspx", false);

                        }
                        else
                        {
                            string message = "Password failer";
                            bool isSuccess = false;
                            SaveLog(message, isSuccess);

                            //Response.Redirect("~/Login.aspx", false);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "Hello();", true);
                        }
                    }
                    else
                    {

                        string message = "authentication failer";
                        bool isSuccess = false;
                        SaveLog(message, isSuccess);

                        //Response.Redirect("~/Login.aspx", false);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "Hello();", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Exception Occure');", true);
                //lblError.Text = ex.Message; 

                string message = "Exception";
                bool isSuccess = false;
                SaveLog(message, isSuccess);
            }
        }

        private void SaveLog(string message, bool isSuccess)
        {
            #region Log Entry

            string loginId = inputEmail.Value.Trim();
            string password = inputPassword.Value.Trim();
            int loginTypeId = (int)Utilites.LoginType.Login;
            string ipAddress = Request.UserHostAddress;
            DateTime createdDate = DateTime.Now;
            LoginLogManager.InsertLog(loginId, password, loginTypeId, isSuccess, ipAddress, message, createdDate);

            #endregion
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LogInProcedure();
        } 
         
    }
}