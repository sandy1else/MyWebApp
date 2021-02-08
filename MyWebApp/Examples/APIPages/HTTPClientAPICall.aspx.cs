using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp.Examples.APIPages
{
    public partial class HTTPClientAPICall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                List<LogicLayer.BusinessObject.Menu> menuList = await GetMenuList();
                gvMenu.DataSource = menuList;
                gvMenu.DataBind();
            }
            catch(Exception ex)
            { }
        }

        private async Task<List<LogicLayer.BusinessObject.Menu>> GetMenuList()
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