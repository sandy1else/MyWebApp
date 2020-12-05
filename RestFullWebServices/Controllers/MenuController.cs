using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFullWebServices.Controllers
{
    public class MenuController : ApiController
    {
        // GET: api/Menu
        public IEnumerable<LogicLayer.BusinessObject.Menu> Get()
        {
            return  MenuManager.GetAll();
        }

         
    }
}
