using LogicLayer.BusinessLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp.Examples.APIPages
{
    public partial class AjaxAPICallJSON : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<LogicLayer.BusinessObject.Menu> menuList = MenuManager.GetAll();
            //gvMenu.DataSource = menuList;
            //gvMenu.DataBind();
            if(!IsPostBack)
            { 
                BindDummyRow();
            }
        }

        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("Id");
            dummy.Columns.Add("ParentId");
            dummy.Columns.Add("Name");
            dummy.Columns.Add("URL");
            dummy.Columns.Add("CreatedBy");
            dummy.Columns.Add("CreatedDate");
            dummy.Columns.Add("ModifiedBy");
            dummy.Columns.Add("ModifiedDate"); 

            dummy.Rows.Add();
            gvMenu.DataSource = dummy;
            gvMenu.DataBind();
        }
         

    }
}