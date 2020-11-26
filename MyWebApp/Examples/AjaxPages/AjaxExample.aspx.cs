using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp.Examples.AjaxPages
{
    public partial class AjaxExample : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CheckPageLoad();
            if (!IsPostBack)
            {

            }
        }

        //[WebMethod]

        //public static List<User> LoadFirst(string firstName)
        //{

        //    List<User> users = null;
        //    Thread thread = new System.Threading.Thread(() =>
        //    {
        //        users = UserManager.GetAllAsync();
        //    });
        //    thread.Start();
        //    thread.Join();
        //    return users;
        //}


        //[WebMethod]
        //public static List<Religion> LoadSecond(string firstName)
        //{

        //    List<Religion> usreligions = null;
        //    Thread thread = new System.Threading.Thread(() =>
        //    {
        //        usreligions = ReligionManager.GetAllAsync();

        //    });
        //    thread.Start();
        //    thread.Join();
        //    return usreligions;

        //}


        [WebMethod]
        public static async Task<List<User>> LoadFirst(string firstName)
        {

            List<User> userList = null;
            await Task.Run(() =>
            {
                //Take 20 sec to retrive from DB
                userList = UserManager.GetAllAsync();

            });

            return userList;

        }

        [WebMethod]
        public static async Task<List<Religion>> LoadSecond(string firstName)
        {

            List<Religion> usreligions = null;
            await Task.Run(() =>
            {
                //Take 20 sec to retrive from DB
                usreligions = ReligionManager.GetAllAsync();

            });

            return usreligions;

        }

        [WebMethod]
        public static List<User> LoadThird(string firstName)
        {
            List<User> users = UserManager.GetAllAsync();
            return users;

        }


        public void Show()
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Only alert Message');", true);
        }

        [WebMethod]
        public static List<Religion> LoadFour(string firstName)
        {
            List<Religion> users = ReligionManager.GetAllAsync();

            return users;

        }
    }
}