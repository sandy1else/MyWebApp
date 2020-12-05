using RestFullWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestFullWebServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public Contact[] GET()
        {
            return new Contact[] {
               new Contact{
               ID =1,
               Name ="Uttom"},
               new Contact
               {
                   ID =2,
                   Name = "Gour"
               }

            };

        }
    }
}
