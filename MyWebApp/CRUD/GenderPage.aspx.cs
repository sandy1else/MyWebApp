using LogicLayer;
using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using LogicLayer.DataLogic.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp.CRUD
{
    public partial class GenderPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            CheckPageLoad();

            lblMessage.Text = "";
            if(!IsPostBack)
            {
                LoadGender();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            LoadGender();
        }

        private void LoadGender()
        {
            try
            {
                List<Gender> list = GenderManager.GetAll();
                if (list != null && list.Count > 0)
                {
                    gvGender.DataSource = list;
                    gvGender.DataBind();
                }
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }
    }
}