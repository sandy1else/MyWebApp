using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp
{
    public partial class Home : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CurrentUser"] !=null)
            {
                User user = (User)Session["CurrentUser"];
                lblLoginId.Text = user.LoginId + " !";
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}