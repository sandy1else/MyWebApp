using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp.MasterPages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CurrentUser"] != null)
                {
                    User user = (User)Session["CurrentUser"];
                    lblLoginId.Text = user.LoginId + " !";

                    List<LogicLayer.BusinessObject.Menu> menuList = MenuManager.GetAll();
                    Session["MenuList"] = null;
                    Session["MenuList"] = menuList;
                    LoadMenu(null, menuList.Where(m => m.ParentId == null).ToList());
                }
                else
                {
                    lblLoginId.Text = "";
                }
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Remove("CurrentUser");
            Response.Redirect("~/Login/Login.aspx");
        }

        private void LoadMenu(MenuItem parentMenu, List<LogicLayer.BusinessObject.Menu> menuList)
        {
            foreach (var item in menuList)
            {
                MenuItem menu = new MenuItem();
                menu.Value = item.Id.ToString();
                menu.Text = item.Name;
                menu.NavigateUrl = item.URL;

                if (parentMenu != null)
                {
                    parentMenu.ChildItems.Add(menu);
                }
                else
                {
                    MainMenu.Items.Add(menu);
                }

                List<LogicLayer.BusinessObject.Menu> allMenu = (List<LogicLayer.BusinessObject.Menu>)Session["MenuList"];
                List<LogicLayer.BusinessObject.Menu> childList = allMenu.Where(m => m.ParentId == item.Id).ToList();

                if (childList != null && childList.Count > 0)
                {
                    LoadMenu(menu, childList);
                }

            }
        }

    }
}