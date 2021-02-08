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
    public partial class AjaxAPICall : System.Web.UI.Page
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

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                List<LogicLayer.BusinessObject.Menu> menuList = null;
                gvMenu.DataSource = menuList;
                gvMenu.DataBind();
            }
            catch (Exception ex)
            { }
        }

        [WebMethod]
        public static List<LogicLayer.BusinessObject.Menu> GetMenus()
        {
            List<LogicLayer.BusinessObject.Menu> menuList = null;
            return menuList;

        } 

        [WebMethod]
        public static async Task<List<LogicLayer.BusinessObject.Menu>> GetMenuList()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:81/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Call the API & wait for response. 
            // If the API call fails, call it again according to the re-try policy
            // specified in Startup.cs
            var result = await client.GetAsync("api/Menu/Get/");

            if (result.IsSuccessStatusCode)
            {
                // Read all of the response and deserialise it into an instace of
                // WeatherForecast class
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LogicLayer.BusinessObject.Menu>>(content);
            }
            return null;
        }

    }
}