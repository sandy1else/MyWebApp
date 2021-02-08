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
    public partial class MenuReport : BasePage
    {

        //private Microsoft.Reporting.WebForms.ReportViewer reportViewer1;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPageLoad();
            if (!IsPostBack)
            {
                ShowMessege("", Color.Yellow);  

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
            ShowMessege("", Color.Blue);

            List<LogicLayer.BusinessObject.Menu> MenuList = MenuManager.GetAll();

            if (MenuList != null && MenuList.Count > 0)
            {
                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("UserName", currentUser.LoginId));

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CRUD/reports/MenuReport.rdlc");
                ReportDataSource MenuData = new ReportDataSource("MenuDataSet", MenuList);

                ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DisplayName = "MenuInfo";
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(MenuData);
                ReportViewer1.Visible = true;
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.Visible = false;
            }
        } 
        private void FildDownload()
        {
            string FileName = "MenuReport" + ".pdf";
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
              
            Response.ContentType = contentType;
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
            Response.WriteFile(Server.MapPath("~/Reports/" + FileName));
            Response.Flush();
        } 
        private void ShowMessege(string messege, Color color)
        {
            lblMessege.ForeColor = color;
            lblMessege.Text = messege;
        } 
        protected void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            FildDownload();

        }


    }
}