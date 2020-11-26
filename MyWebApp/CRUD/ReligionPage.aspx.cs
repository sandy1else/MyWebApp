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
    public partial class ReligionPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            CheckPageLoad();

            lblMessage.Text = "";
            if(!IsPostBack)
            {
                LoadReligion();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            LoadReligion();
        }

        private void LoadReligion()
        {
            try
            {
                List<Religion> list = ReligionManager.GetAll();
                if (list != null && list.Count > 0)
                {
                    gvReligion.DataSource = list;
                    gvReligion.DataBind();
                }
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }
    }
}