using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp.CRUD
{
    public partial class MenuPage : BasePage
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPageLoad();

            if (!IsPostBack)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false; 
                btnAddNew.Enabled = false;

                ClearAll(true);

                PopulatedRootNode();
            }
        }

        private void PopulatedRootNode()
        {
            List<LogicLayer.BusinessObject.Menu> lists = MenuManager.GetAll();
            PopulatedNode(lists.Where(m => m.ParentId == null).ToList(), tvMenu.Nodes);
        }

        private void PopulatedNode(List<LogicLayer.BusinessObject.Menu> lists, TreeNodeCollection tnCollection)
        {
            foreach (var item in lists)
            {
                TreeNode tn = new TreeNode();
                tn.Value = item.Id.ToString();
                tn.Text = item.Name;

                tnCollection.Add(tn);
                tn.PopulateOnDemand = true;
            }
        }

        private void PopulatedChildNode(int ParentId, TreeNode tn)
        {
            List<LogicLayer.BusinessObject.Menu> lists = MenuManager.GetAll();

            PopulatedNode(lists.Where(p => p.ParentId == ParentId).ToList(), tn.ChildNodes);
        }

        protected void tvMenu_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            PopulatedChildNode(Convert.ToInt32(e.Node.Value), e.Node);
        }

        protected void tvMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            btnAddNew.Enabled = true;
            int menuId = Convert.ToInt32(tvMenu.SelectedNode.Value);
            hdnParentMenuId.Value = menuId.ToString();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int menuId = Convert.ToInt32(tvMenu.SelectedNode.Value);
            LogicLayer.BusinessObject.Menu menu = MenuManager.GetById(menuId);

            hdnParentMenuId.Value = menu.ParentId == null ? "0" : menu.ParentId.ToString();
            hdnMenuId.Value = menu.Id.ToString();
            txtMenuName.Text = menu.Name;
            txtMenuURL.Text = menu.URL;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //
            int menuId = Convert.ToInt32(tvMenu.SelectedNode.Value);
            bool isDelete = MenuManager.Delete(menuId);
            if(isDelete)
            { }
             
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            // Hidden Parent ID will not be reset
            ClearAll(false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int parentMenuId = Convert.ToInt32(hdnParentMenuId.Value);
            int menuId = Convert.ToInt32(hdnMenuId.Value);

            string menuName = txtMenuName.Text.Trim();
            string menuURL = txtMenuURL.Text.Trim();

            if (!string.IsNullOrEmpty(menuName) && !string.IsNullOrEmpty(menuURL))
            {
                LogicLayer.BusinessObject.Menu menu;
                if (menuId != 0)
                {
                    menu = MenuManager.GetById(menuId);
                }
                else
                {
                    menu = new LogicLayer.BusinessObject.Menu();
                }


                menu.Name = menuName;
                menu.URL = menuURL;
                menu.ParentId = parentMenuId == 0 ? null : (Nullable<int>)parentMenuId;

                if (menuId != 0)
                {
                    menu.ModifiedBy = currentUser.Id;
                    menu.ModifiedDate = DateTime.Now;
                    MenuManager.Update(menu);
                }
                else
                {
                    menu.CreatedBy = currentUser.Id;
                    menu.CreatedDate = DateTime.Now;
                    MenuManager.Insert(menu);
                }
            }

        }

        protected void btnAddNewRoot_Click(object sender, EventArgs e)
        {
            // Hidden Parent ID will be reset
            ClearAll(true);
        }

        private void ClearAll(bool isRoot)
        {
            if (isRoot)
                hdnParentMenuId.Value = "0";

            hdnMenuId.Value = "0";

            txtMenuName.Text = "";
            txtMenuURL.Text = "";
        }
    }
}