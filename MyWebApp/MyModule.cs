using System;
using System.IO;
using System.Web;

namespace MyWebApp
{
    public class MyModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            //context.LogRequest += new EventHandler(OnLogRequest);
            context.AcquireRequestState += new EventHandler(OnSessionRequest);
            //context.PostAcquireRequestState += new EventHandler(OnSessionRequest);
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
            HttpContext context = ((HttpApplication)source).Context;
            string filePath = @"D:\WebAppLog.txt";

            

            // This text is added only once to the file.
            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(context.Request.Path);

                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(context.Request.Path);
            }

        }

        public void OnSessionRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
            HttpContext context = ((HttpApplication)source).Context;
            string filePath = @"D:\WebAppLog.txt";

            LogicLayer.BusinessObject.User user = null;
            if (HttpContext.Current.Session["CurrentUser"] != null)
            {
                user = (LogicLayer.BusinessObject.User)HttpContext.Current.Session["CurrentUser"];
            }

            bool isValid = false;
            if (user != null)
            {
                isValid = true;
            }

            // This text is added only once to the file.
            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(context.Request.Path + " " + isValid.ToString());

                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(context.Request.Path + " " + isValid.ToString());
            }

        }
    }
}
