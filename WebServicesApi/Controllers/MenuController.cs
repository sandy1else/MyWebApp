using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Web;
using System.Web.Http;

namespace WebServicesApi.Controllers
{
    public class MenuController : ApiController
    {
        // GET api/Menu 
        public IEnumerable<Menu> Get()
        {
            string filePath = @"D:\WebAPILog.txt";



            // This text is added only once to the file.
            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(HttpContext.Current.Request.Path);

                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(HttpContext.Current.Request.Path);
            }

            List<Menu> menues = MenuManager.GetAll();
            return menues;
        }

        public string GetMenusJSON()
        { 
            List<LogicLayer.BusinessObject.Menu> menues = MenuManager.GetAll();

            string menustrings = JsonSerializer.Serialize(menues);
            return menustrings;
        }


        // GET api/Menu/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Menu
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Menu/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Menu/5
        public void Delete(int id)
        {
        }
    }
}