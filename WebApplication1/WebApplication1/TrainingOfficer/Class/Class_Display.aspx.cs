using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.TrainingOfficer.Class
{
    public partial class Class_Display : System.Web.UI.Page
    {
        private List<HalonModels.Firefighter> firefighters;
        private List<HalonModels.Course> courses;
        private readonly HalonContext _db = new HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<HalonModels.Class> GetClasses()
        {
            IQueryable<HalonModels.Firefighter> fireFighterHolder = _db.Firefighters;
            firefighters = fireFighterHolder.ToList();

            IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = _db.Firefighters;
            string firefighter_UName = Page.User.Identity.Name;
            ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));

            IQueryable<HalonModels.Course> courseHolder = _db.Courses;
            courses = courseHolder.ToList();

            IQueryable<HalonModels.Class> query = _db.Classes;

            fireFighterHolder = fireFighterHolder.Where(f => f.Dept_ID == ffquery.FirstOrDefault().Dept_ID);

            List<HalonModels.Firefighter> fireFighterList = fireFighterHolder.ToList();
            List<HalonModels.Class> classList = query.ToList();
            List<HalonModels.Class> deptClass = new List<HalonModels.Class>();

            for (int j = 0; j < classList.Count; j++)
            {
                for (int i = 0; i < fireFighterList.Count; i++)
                {
                    if (classList[j].Firefighter_ID == fireFighterList[i].Firefighter_ID)
                    {
                        deptClass.Add(classList[j]);
                    }
                }
            }

            List<DateTime> dateList = new List<DateTime>();
            List<DateTime> startList = new List<DateTime>();
            for (int i = 0; i < deptClass.Count(); i++)
            {
                dateList.Add(DateTime.Parse(deptClass[i].Class_Date));
                startList.Add(DateTime.Parse(deptClass[i].Class_Date));
            }
            dateList = dateList.OrderByDescending(d => d.Year).ThenByDescending(d => d.Month).ThenByDescending(d => d.Day).ToList();
            List<HalonModels.Class> returnList = new List<HalonModels.Class>();
            for (int i = 0; i < dateList.Count(); i++)
            {
                for (int j = 0; j < startList.Count(); j++)
                {
                    if (dateList[i].Equals(startList[j]))
                    {
                        returnList.Add(deptClass[j]);
                    }
                }
            }
            return returnList;
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
            for (int i = 0; i < ClassInfo.Rows.Count; i++)
            {
                int classID = Convert.ToInt32(ClassInfo.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)ClassInfo.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    var myClass = (from c in _db.Classes where c.Class_ID == classID select c).FirstOrDefault();
                    if (myClass != null)
                    {
                        string pageUrl = "/TrainingOfficer/Class/Class_Add.aspx";
                        Response.Redirect(pageUrl + "?ClassId=" + classID.ToString());
                    }
                }
            }
        }

        protected void DeleteClassButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ClassInfo.Rows.Count; i++)
            {
                int classID = Convert.ToInt32(ClassInfo.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)ClassInfo.Rows[i].FindControl("editDeleteBox");
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
            String tag = e.CommandName.ToString();
            CreatePDF(Convert.ToInt32(e.CommandArgument), tag);
        }

        public void CreatePDF(int id, String tag)
        {
            PdfDocument document = null;
            string filename = "";
            if (tag.Equals("Label"))
            {
                // Print out PDF Shipping Label
                // Create a new PDF document
                String directory1 = Server.MapPath("~/PDF/Course Request Form_fillable format.pdf");
                document = PdfReader.Open(directory1, PdfDocumentOpenMode.Modify);
                //document.Info.Title = "Created with PDFsharp";
                // Create an empty page
                PdfPage page = document.Pages[0];

                // Retrieve Order Information
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

                String user1 = Context.User.Identity.Name;
                WebApplication1.HalonModels.Firefighter rank = _db.Firefighters.Where(f => f.Firefighter_Account_Username.Equals(user1)).FirstOrDefault();
                String user = rank.Firefighter_Rank;
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
                // Save the document...
                filename = "NewClass" + id + "request.pdf";
            }
            else
            {
                if (tag.Equals("Label2"))
                {
                    // Print out PDF Shipping Label
                    // Create a new PDF document
                    String directory1 = Server.MapPath("~/PDF/Copy of roster.pdf");
                    document = PdfReader.Open(directory1, PdfDocumentOpenMode.Modify);
                    //document.Info.Title = "Created with PDFsharp";
                    // Create an empty page
                    PdfPage page = document.Pages[0];

                    // Retrieve Order Information
                    List<WebApplication1.HalonModels.Class> allclass = _db.Classes.ToList();
                    List<WebApplication1.HalonModels.Course> allcourse = _db.Courses.ToList();
                    List<WebApplication1.HalonModels.Department> alldept = _db.Departments.ToList();

                    WebApplication1.HalonModels.Class cl = new WebApplication1.HalonModels.Class();
                    cl = allclass.Where(c => c.Class_ID == id).FirstOrDefault();

                    int temp1 = Convert.ToInt32(cl.Course_ID.ToString()); // Get its Course_ID

                    // Look for the course related to above class
                    WebApplication1.HalonModels.Course co = allcourse.Where(d => d.Course_ID == temp1).FirstOrDefault();

                    // Look for the teacher teaches this class
                    int fid = Convert.ToInt32(cl.Firefighter_ID.ToString());
                    WebApplication1.HalonModels.Firefighter t = _db.Firefighters.Where(f => f.Firefighter_ID == fid).FirstOrDefault();

                    // Look for all the enrollments for this class
                    List<WebApplication1.HalonModels.Enrollment> enrollList = cl.Enrollments.ToList();

                    // Get the current Department
                    WebApplication1.HalonModels.Department de = _db.Departments.ToList().FirstOrDefault();
                    // Get an XGraphics object for drawing
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Create a font
                    XFont font = new XFont("Verdana", 11, XFontStyle.Bold);
                    XFont font1 = new XFont("Arial", 9, XFontStyle.Bold);
                    XFont font2 = new XFont("Arial", 28, XFontStyle.Regular);
                    XFont font3 = new XFont("Arial", 32, XFontStyle.Bold);

                    // Retrieve Information

                    String class_name = co.Course_Name;
                    String course_num = co.Course_ID.ToString();
                    String course_hour = co.Course_Credit_Hours.ToString();
                    String course_start = cl.Class_Date.ToString();

                    // Draw the text
                    gfx.DrawString(class_name, font, XBrushes.Black,
                      new XRect(110, 157, page.Width, page.Height),
                      XStringFormat.TopLeft);
                    gfx.DrawString(course_num, font, XBrushes.Black,
                      new XRect(290, 157, page.Width, page.Height),
                      XStringFormat.TopLeft);
                    gfx.DrawString(course_hour, font, XBrushes.Black,
                      new XRect(390, 157, page.Width, page.Height),
                      XStringFormat.TopLeft);
                    gfx.DrawString(course_start, font, XBrushes.Black,
                      new XRect(485, 157, page.Width, page.Height),
                      XStringFormat.TopLeft);

                    // Populate roster

                    for (int i = 0; i < enrollList.Count; i++)
                    {
                        int y = (i * 15) + 252;
                        String ffter_lname = enrollList[i].Firefighter.Firefighter_Lname.ToString();
                        String ffter_fname = enrollList[i].Firefighter.Firefighter_Fname.ToString();
                        String ffter_mname = enrollList[i].Firefighter.Firefighter_MI.ToString();
                        String ffter_dob = enrollList[i].Firefighter.Firefighter_DOB.ToString();
                        int? temp = enrollList[i].Firefighter.Dept_ID;
                        String ffter_dept = alldept.Where(d => d.Dept_ID == temp.Value).FirstOrDefault().Dept_Name.ToString();
                        String ffter_fdid = alldept.Where(d => d.Dept_ID == temp.Value).FirstOrDefault().Dept_FDID.ToString();

                        gfx.DrawString(ffter_lname, font1, XBrushes.Black,
                          new XRect(110, y, page.Width, page.Height),
                          XStringFormat.TopLeft);
                        gfx.DrawString(ffter_fname, font1, XBrushes.Black,
                          new XRect(251, y, page.Width, page.Height),
                          XStringFormat.TopLeft);
                        gfx.DrawString(ffter_mname, font1, XBrushes.Black,
                          new XRect(330, y, page.Width, page.Height),
                          XStringFormat.TopLeft);
                        gfx.DrawString(ffter_dob, font1, XBrushes.Black,
                          new XRect(348, y, page.Width, page.Height),
                          XStringFormat.TopLeft);
                        gfx.DrawString(ffter_dept, font1, XBrushes.Black,
                          new XRect(430, y, page.Width, page.Height),
                          XStringFormat.TopLeft);
                        gfx.DrawString(ffter_fdid, font1, XBrushes.Black,
                          new XRect(540, y, page.Width, page.Height),
                          XStringFormat.TopLeft);
                    }

                    // Save the document...
                    filename = "Class " + id + "Roster.pdf";
                }
            }

            String directory = @"R:\";
            document.Save(Path.Combine(directory, filename));
            // ...and start a viewer.
            //    Process.Start(filename);
            var fileName1 = @"R:\" + filename;
            var startInfo = new ProcessStartInfo(fileName1);
            string verbToUse = "Open";
            startInfo.Verb = verbToUse;
            Process print = Process.Start(startInfo);
            ClassInfo.DataBind();
        }
    }
}