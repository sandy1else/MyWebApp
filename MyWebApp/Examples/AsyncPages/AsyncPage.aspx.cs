using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Drawing;

namespace MyWebApp.Examples.AsyncPages
{
    public partial class AsyncPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPageLoad();
            if (!IsPostBack)
            {

            }
        }
        protected void btnfisrtAsync_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetUserAsync));
        }
        protected void btnSecondAsync_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetGenderAsync));
        }
        protected void btnThirdAsync_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetRoleAsync));
        }
        protected void btnFourthAsync_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetReligionAsync));
        }
        public async Task<List<User>> GetUserAsync()
        {
            List<User> users = null;
            await Task.Run(() =>
            {
                users = UserManager.GetAllAsync();
                lblone.Text = "Complete One";
                lblone.ForeColor = Color.Red;

            });
            return users;
        }
        public async Task<List<Gender>> GetGenderAsync()
        {
            List<Gender> genders = null;
            await Task.Run(() =>
            {
                genders = GenderManager.GetAllAsync();
                lbltwo.Text = "Complete Two";
                lbltwo.ForeColor = Color.Blue;

            });
            return genders;
        }
        public async Task<List<LogicLayer.BusinessObject.Role>> GetRoleAsync()
        {
            List<LogicLayer.BusinessObject.Role> roles = null;
            await Task.Run(() =>
            {
                roles = RoleManager.GetAllAsync();
                lblthird.Text = "Complete Three";
                lblthird.ForeColor = Color.DarkSeaGreen;

            });
            return roles;
        }
        public async Task<List<Religion>> GetReligionAsync()
        {
            List<Religion> religions = null;
            await Task.Run(() =>
            {
                religions = ReligionManager.GetAllAsync();
                lblfour.Text = "Complete Four";
                lblfour.ForeColor = Color.Purple;

            });
            return religions;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblone.Text = "Reset";
            lbltwo.Text = "Reset";
            lblthird.Text = "Reset";
            lblfour.Text = "Reset";

        }
        protected void btnAllInOne_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetAllDoing));
        }

        public async Task GetAllDoing()
        {

            var userTask = GetUserAsync();
            var genderTask = GetGenderAsync();
            var religionTask = GetReligionAsync();
            var roleTask = GetRoleAsync();

            await Task.WhenAll(userTask, genderTask, religionTask, roleTask);

            var breakfastTasks = new List<Task> { userTask, genderTask, religionTask, roleTask };

            foreach (var finishedTask in breakfastTasks)
            {
                if (finishedTask == userTask)
                {
                    lblone.Text = "Complete one" + DateTime.Now.ToString("dd/MM/yyyy mm ss");
                    List<User> users = userTask.Result;
                    gvUser.DataSource = users;
                    gvUser.DataBind();
                }
                else if (finishedTask == genderTask)
                {
                    lbltwo.Text = "Complete two" + DateTime.Now.ToString("dd/MM/yyyy  mm ss");
                    List<Gender> genders = genderTask.Result;
                    gvGender.DataSource = genders;
                    gvGender.DataBind();
                }
                else if (finishedTask == religionTask)
                {
                    lblthird.Text = "Complete three" + DateTime.Now.ToString("dd/MM/yyyy  mm ss");
                    List<Religion> religions = religionTask.Result;
                    gvReligion.DataSource = religions;
                    gvReligion.DataBind();
                }
                else if (finishedTask == roleTask)
                {
                    lblfour.Text = "Complete four" + DateTime.Now.ToString("dd/MM/yyyy  mm ss");
                    List<LogicLayer.BusinessObject.Role> roles = roleTask.Result;
                    gvRole.DataSource = roles;
                    gvRole.DataBind();
                }
            }

            //while (breakfastTasks.Count > 0)
            //{
            //    Task finishedTask = Task.WhenAny(breakfastTasks);
            //    if (finishedTask == userTask)
            //    {
            //        lblone.Text = "Complete one"+ DateTime.Now.ToString("dd/MM/yyyy mm ss");
            //    }
            //    else if (finishedTask == genderTask)
            //    {
            //        lbltwo.Text = "Complete two" + DateTime.Now.ToString("dd/MM/yyyy  mm ss");
            //    }
            //    else if (finishedTask == religionTask)
            //    {
            //        lblthird.Text = "Complete three" + DateTime.Now.ToString("dd/MM/yyyy  mm ss");
            //    }
            //    else if (finishedTask == menuTask)
            //    {
            //        lblfour.Text = "Complete four" + DateTime.Now.ToString("dd/MM/yyyy  mm ss");
            //    }
            //    breakfastTasks.Remove(finishedTask);
            //}


        }
    }
}