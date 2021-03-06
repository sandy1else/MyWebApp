﻿using LogicLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp
{
    public partial class BasePage : System.Web.UI.Page,IHttpModule
    {
        public static User currentUser;

        
        public static void CheckPageLoad()
        {
            string url = HttpContext.Current.Request.Path;
            if (HttpContext.Current.Session["CurrentUser"] != null)
            {
                currentUser = (User)HttpContext.Current.Session["CurrentUser"];
                int roleId = currentUser.RoleId; 
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
        }

        void IHttpModule.Init(HttpApplication context)
        {
            throw new NotImplementedException();
        }
    }
}