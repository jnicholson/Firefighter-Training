using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.Instructor.Class
{
    public partial class Class_Info : System.Web.UI.Page
    {
        private List<HalonModels.Firefighter> firefighters;
        private List<HalonModels.Course> courses;
        private readonly HalonContext _db = new HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<HalonModels.Class> GetClasses()
        {
            IQueryable<HalonModels.Firefighter> fireFighterHolder = _db.Firefighters;
            firefighters = fireFighterHolder.ToList();

            IQueryable<HalonModels.Course> courseHolder = _db.Courses;
            courses = courseHolder.ToList();

            IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = _db.Firefighters;
            string firefighter_UName = Page.User.Identity.Name;
            ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));

            IQueryable<HalonModels.Class> query = _db.Classes;
            query = query.Where(c => c.Firefighter_ID == ffquery.First().Firefighter_ID);
            return query;
        }

        protected void Classes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HalonModels.Class cls = e.Row.DataItem as HalonModels.Class;
                for (int i = 0; i < firefighters.Count; i++)
                {
                    if (cls.Firefighter_ID == firefighters[i].Firefighter_ID)
                    {
                        e.Row.Cells[2].Text = firefighters[i].Firefighter_Lname + ", " + firefighters[i].Firefighter_Fname;
                    }
                }
                for (int i = 0; i < courses.Count; i++)
                {
                    if (cls.Course_ID == courses[i].Course_ID)
                    {
                        e.Row.Cells[4].Text = courses[i].Course_Name;
                    }
                }
            }
        }

        protected void EditClassButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ClassTable.Rows.Count; i++)
            {
                int classID = Convert.ToInt32(ClassTable.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)ClassTable.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    var myClass = (from c in _db.Classes where c.Class_ID == classID select c).FirstOrDefault();
                    if (myClass != null)
                    {
                        string pageUrl = "/Class/Class_Add.aspx";
                        Response.Redirect(pageUrl + "?ClassId=" + classID.ToString());
                    }
                }
            }
        }

        protected void DeleteClassButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ClassTable.Rows.Count; i++)
            {
                int classID = Convert.ToInt32(ClassTable.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)ClassTable.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    var myClass = (from c in _db.Classes where c.Class_ID == classID select c).FirstOrDefault();
                    if (myClass != null)
                    {
                        //cascade the class removal

                        //then remove the class
                        _db.Classes.Remove(myClass);
                        _db.SaveChanges();

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl);
                    }
                    else
                    {
                        //LabelRemoveStatus.Text = "Unable to locate Department.";
                    }
                }
            }
        }

        /// <summary>
        /// Print out Shipping Label
        /// for the product Buyer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OrderSellItemList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Print out PDF Shipping Label
            // Create a new PDF document
            String directory1 = Server.MapPath("~/PDF/Course Request Form_fillable format.pdf");
            PdfDocument document = PdfReader.Open(directory1, PdfDocumentOpenMode.Modify);
            //document.Info.Title = "Created with PDFsharp";
            // Create an empty page
            PdfPage page = document.Pages[0];

            // Retrieve Order Information
            int id = Convert.ToInt32(e.CommandArgument);
            List<WebApplication1.HalonModels.Class> allclass = _db.Classes.ToList();
            List<WebApplication1.HalonModels.Course> allcourse = _db.Courses.ToList();

            WebApplication1.HalonModels.Class cl = new WebApplication1.HalonModels.Class();
            cl = allclass.Where(c => c.Class_ID == id).FirstOrDefault();

            int temp1 = Convert.ToInt32(cl.Course_ID.ToString()); // Get its Course_ID

            // Look for the course related to above class
            WebApplication1.HalonModels.Course co = allcourse.Where(d => d.Course_ID == temp1).FirstOrDefault();

            // Look for the teacher teaches this class
            int fid = Convert.ToInt32(cl.Firefighter_ID.ToString());
            WebApplication1.HalonModels.Firefighter t = _db.Firefighters.Where(f => f.Firefighter_ID == fid).FirstOrDefault();

            // Get the current Department
            WebApplication1.HalonModels.Department de = _db.Departments.ToList().FirstOrDefault();
            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 11, XFontStyle.Bold);
            XFont font1 = new XFont("Arial", 30, XFontStyle.Bold);
            XFont font2 = new XFont("Arial", 28, XFontStyle.Regular);
            XFont font3 = new XFont("Arial", 32, XFontStyle.Bold);

            // Retrieve Information

            String class_name = co.Course_Name;
            String request_date = DateTime.Now.ToShortDateString();
            String department_name = de.Dept_Name;
            String department_address = de.Dept_Address + " " + de.Dept_City;
            String user = Context.User.Identity.Name + "'s role";
            String department_phone = de.Dept_Tel_No;
            String teacher = t.Firefighter_Fname + " " + t.Firefighter_Lname;
            // Draw the text
            gfx.DrawString(class_name, font, XBrushes.Black,
              new XRect(143, 148, page.Width, page.Height),
              XStringFormat.TopLeft);
            gfx.DrawString(request_date, font, XBrushes.Black,
              new XRect(475, 148, page.Width, page.Height),
              XStringFormat.TopLeft);
            gfx.DrawString(department_name, font, XBrushes.Black,
              new XRect(228, 175, page.Width, page.Height),
              XStringFormat.TopLeft);
            gfx.DrawString(department_address, font, XBrushes.Black,
             new XRect(228, 202, page.Width, page.Height),
             XStringFormat.TopLeft);
            gfx.DrawString(user, font, XBrushes.Black,
             new XRect(156, 229, page.Width, page.Height),
             XStringFormat.TopLeft);
            gfx.DrawString(department_phone, font, XBrushes.Black,
             new XRect(279, 267, page.Width, page.Height),
             XStringFormat.TopLeft);
            gfx.DrawString(teacher, font, XBrushes.Black,
             new XRect(156, 498, page.Width, page.Height),
             XStringFormat.TopLeft);

            String directory = @"R:\";
            // Save the document...
            string filename = "NewClass" + id + "request.pdf";
            document.Save(Path.Combine(directory, filename));
            // ...and start a viewer.
            //    Process.Start(filename);
            var fileName1 = @"R:\" + filename;
            var startInfo = new ProcessStartInfo(fileName1);
            string verbToUse = "Open";
            startInfo.Verb = verbToUse;
            Process print = Process.Start(startInfo);
            ClassTable.DataBind();
        }
    }
}