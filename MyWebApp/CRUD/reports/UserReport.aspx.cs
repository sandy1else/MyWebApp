using LogicLayer.BusinessLogic;
using LogicLayer.BusinessObject;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp.CRUD.reports
{
    public partial class UserReport : BasePage
    {

        //private Microsoft.Reporting.WebForms.ReportViewer reportViewer1;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPageLoad();
            if (!IsPostBack)
            {
                ShowMessege("Start", Color.Yellow);
                ShowProcessMessege("Start", Color.Yellow);


            }
        }
         
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                ShowMessege(ex.Message, Color.Red);
            }
        }

        private void LoadData()
        {
            ShowMessege("Loaded", Color.Blue);

            List<User> userList = UserManager.GetAll();

            if (userList != null && userList.Count > 0)
            {
                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("UserName", currentUser.LoginId));

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CRUD/reports/UserReport.rdlc");
                ReportDataSource userData = new ReportDataSource("UserDataSet", userList);

                ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DisplayName = "UserInfo";
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(userData);
                ReportViewer1.Visible = true;
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.Visible = false;
            }
        }

        [WebMethod]
        public static string LenthyProcess(string firstName)
        {
            ThreadStart s = FildDownload;
            Thread t1 = new Thread(s);

            t1.Start();
            return firstName + " Ok Here";
        }

        private void PDFSave()
        {
            //string FileName = "File_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
            string FileName = "File_B" + ".pdf";
            string extension;
            string encoding;
            string mimeType;
            string[] streams;
            Warning[] warnings;

            string contentType = "application/pdf";

            Byte[] mybytes = ReportViewer1.LocalReport.Render("PDF", null,
                            out extension, out encoding,
                            out mimeType, out streams, out warnings); //for exporting to PDF  

            if (File.Exists(FileName))
            {
                File.Delete(Server.MapPath("~/Reports/") + FileName);
            }

            using (FileStream fs = File.Create(Server.MapPath("~/Reports/") + FileName))
            {
                fs.Write(mybytes, 0, mybytes.Length);
            }

            //Response.ClearHeaders();
            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.Clear();

            //Response.Close();
            //Response.End(); 


            //Response.ContentType = contentType;
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
            //Response.WriteFile(Server.MapPath("~/Reports/" + FileName));
            //Response.Flush();
        }

        private static void FildDownload()
        {
            Task.Delay(10000).Wait(); 
        }

        private void ShowMessege(string messege, Color color)
        {
            lblMessege.ForeColor = color;
            lblMessege.Text = messege;
        }

        private void ShowProcessMessege(string messege, Color color)
        {
            lblProcessMessege.ForeColor = color;
            lblProcessMessege.Text = messege;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        { 

            //ShowProcessMessege("Refresh", Color.Red);
            //LenthyProcess();
            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Only alert Message');", true);
            //ThreadStart s = LenthyProcess;
            //Thread t1 = new Thread(s);

            //t1.Start();
            //ShowProcessMessege("End", Color.Green);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.Visible = false;

        }

        protected void btnSavePDF_Click(object sender, EventArgs e)
        {
            LoadData();
            PDFSave();
        }

        protected void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            //FildDownload();

            ThreadStart s = FildDownload;
            Thread t1 = new Thread(s);

            t1.Start();
        }

         
        protected void btnThread_Click(object sender, EventArgs e)
        {
             
        }


    }
}