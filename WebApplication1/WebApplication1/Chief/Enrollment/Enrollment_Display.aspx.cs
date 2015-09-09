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

namespace WebApplication1.Chief.Enrollment
{
    public partial class Enrollment_Display : System.Web.UI.Page
    {
        private List<HalonModels.Firefighter> firefighters;
        private List<HalonModels.Class> classes;
        private List<HalonModels.Course> courses;
        private readonly HalonContext _db = new HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<HalonModels.Enrollment> GetEnrollments()
        {
            IQueryable<HalonModels.Firefighter> fireFighterHolder = _db.Firefighters;
            firefighters = fireFighterHolder.ToList();

            IQueryable<HalonModels.Class> classHolder = _db.Classes;
            classes = classHolder.ToList();

            IQueryable<HalonModels.Course> courseHolder = _db.Courses;
            courses = courseHolder.ToList();

            IQueryable<HalonModels.Enrollment> query = _db.Enrollments;
            return query;
        }

        protected void Enrollments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HalonModels.Enrollment enroll = e.Row.DataItem as HalonModels.Enrollment;
                for (int i = 0; i < classes.Count; i++)
                {
                    if (enroll.Class_ID == classes[i].Class_ID)
                    {
                        for (int j = 0; j < courses.Count; j++)
                        {
                            if (classes[i].Course_ID == courses[j].Course_ID)
                            {
                                e.Row.Cells[4].Text = courses[j].Course_Name;
                            }
                        }
                    }
                }
                for (int i = 0; i < firefighters.Count; i++)
                {
                    if (enroll.Firefighter_ID == firefighters[i].Firefighter_ID)
                    {
                        e.Row.Cells[2].Text = firefighters[i].Firefighter_Lname + ", " + firefighters[i].Firefighter_Fname;
                    }
                }
            }
        }

        protected void EditEnrollmentButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < EnrollmentInfo.Rows.Count; i++)
            {
                int enrollmentID = Convert.ToInt32(EnrollmentInfo.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)EnrollmentInfo.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    var myEnrollment = (from c in _db.Enrollments where c.Enrollment_ID == enrollmentID select c).FirstOrDefault();
                    if (myEnrollment != null)
                    {
                        string pageUrl = "/Chief/Enrollment/Enrollment_Add.aspx";
                        Response.Redirect(pageUrl + "?EnrollmentId=" + enrollmentID.ToString());
                    }
                }
            }
        }

        protected void DeleteEnrollmentButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < EnrollmentInfo.Rows.Count; i++)
            {
                int enrollmentID = Convert.ToInt32(EnrollmentInfo.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)EnrollmentInfo.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    var myEnrollment = (from c in _db.Enrollments where c.Enrollment_ID == enrollmentID select c).FirstOrDefault();
                    if (myEnrollment != null)
                    {
                        //cascade the enrollment removal

                        //then remove the enrollment
                        _db.Enrollments.Remove(myEnrollment);
                        _db.SaveChanges();

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl);
                    }
                    else
                    {
                        //LabelRemoveStatus.Text = "Unable to locate Enrollment.";
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
            if (tag.Equals("AA"))
            {
                // Print out PDF Shipping Label
                // Create a new PDF document
                String directory1 = Server.MapPath("~/PDF/afta_course_app_rev9-10.pdf");
                document = PdfReader.Open(directory1, PdfDocumentOpenMode.Modify);
                //document.Info.Title = "Created with PDFsharp";
                // Create an empty page
                PdfPage page = document.Pages[0];

                // Retrieve Order Information
                List<WebApplication1.HalonModels.Class> allclass = _db.Classes.ToList();
                List<WebApplication1.HalonModels.Course> allcourse = _db.Courses.ToList();
                List<WebApplication1.HalonModels.Department> alldept = _db.Departments.ToList();
                List<WebApplication1.HalonModels.Enrollment> allen = _db.Enrollments.ToList();
                List<WebApplication1.HalonModels.State> allstate = _db.States.ToList();

                // Look for this enrollment based on the ID
                WebApplication1.HalonModels.Enrollment en = allen.Where(e => e.Enrollment_ID == id).FirstOrDefault();
                int cid = Convert.ToInt32(en.Class_ID.ToString());

                // Look for the class related to this enrollment
                WebApplication1.HalonModels.Class cl = new WebApplication1.HalonModels.Class();
                cl = allclass.Where(c => c.Class_ID == cid).FirstOrDefault();

                int temp1 = Convert.ToInt32(cl.Course_ID.ToString()); // Get its Course_ID

                // Look for the course related to above class
                WebApplication1.HalonModels.Course co = allcourse.Where(d => d.Course_ID == temp1).FirstOrDefault();

                // Look for the student/firefighter related to this enrollment
                int fid = Convert.ToInt32(en.Firefighter_ID.ToString());
                WebApplication1.HalonModels.Firefighter t = _db.Firefighters.Where(f => f.Firefighter_ID == fid).FirstOrDefault();

                // Look for the state this student live in
                int sid = Convert.ToInt32(t.State_ID.ToString());
                WebApplication1.HalonModels.State st = allstate.Where(s => s.State_ID == sid).FirstOrDefault();

                // Get the current Department
                int did = Convert.ToInt32(t.Dept_ID.ToString());
                WebApplication1.HalonModels.Department de = _db.Departments.Where(d => d.Dept_ID == did).FirstOrDefault();

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Create a font
                XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
                XFont font1 = new XFont("Verdana", 8, XFontStyle.Bold);
                XFont font2 = new XFont("Verdana", 7, XFontStyle.Bold);
                XFont font3 = new XFont("Arial", 32, XFontStyle.Bold);

                // Retrieve Information

                String fname = t.Firefighter_Lname + " " + t.Firefighter_MI + " " + t.Firefighter_Fname;
                String faddress = t.Firefighter_Address + " " + t.Firefighter_City + " " + st.State_Name + " " + t.Firefighter_Zip;
                String fphone = t.Firefighter_Cell_Ph;
                String fdob1 = t.Firefighter_DOB.Substring(0, 2);
                String fdob2 = t.Firefighter_DOB.Substring(3, 2);
                String fdob3 = "20" + t.Firefighter_DOB.Substring(6, 2);
                String fsex = t.Firefighter_Gender;
                String frace = t.Firefighter_Race;

                String class_name = co.Course_Name;
                String class_date = cl.Class_Date;

                String dept_fdid = de.Dept_FDID;
                String dept_name = de.Dept_Name;
                String dept_phone = de.Dept_Tel_No;
                String dept_address = de.Dept_Address + ", " + de.Dept_City + " " + de.Dept_Zip;

                // Draw the text
                gfx.DrawString(fname, font, XBrushes.Black,
                  new XRect(155, 75, page.Width, page.Height),
                  XStringFormat.TopLeft);
                gfx.DrawString(faddress, font, XBrushes.Black,
                  new XRect(57, 100, page.Width, page.Height),
                  XStringFormat.TopLeft);
                gfx.DrawString(fphone, font, XBrushes.Black,
                  new XRect(330, 95, page.Width, page.Height),
                  XStringFormat.TopLeft);
                gfx.DrawString(fdob1, font, XBrushes.Black,
                 new XRect(421, 100, page.Width, page.Height),
                 XStringFormat.TopLeft);
                gfx.DrawString(fdob2, font, XBrushes.Black,
                 new XRect(464.75, 100, page.Width, page.Height),
                 XStringFormat.TopLeft);
                gfx.DrawString(fdob3, font, XBrushes.Black,
                 new XRect(500, 100, page.Width, page.Height),
                 XStringFormat.TopLeft);
                gfx.DrawString(fsex, font, XBrushes.Black,
                 new XRect(464.75, 150, page.Width, page.Height),
                 XStringFormat.TopLeft);
                gfx.DrawString(frace, font1, XBrushes.Black,
                  new XRect(346, 166, page.Width, page.Height),
                  XStringFormat.TopLeft);
                gfx.DrawString(class_name, font, XBrushes.Black,
                  new XRect(135, 321, page.Width, page.Height),
                  XStringFormat.TopLeft);
                gfx.DrawString(class_date, font, XBrushes.Black,
                  new XRect(443, 321, page.Width, page.Height),
                  XStringFormat.TopLeft);
                gfx.DrawString(dept_fdid, font, XBrushes.Black,
                 new XRect(86, 458, page.Width, page.Height),
                 XStringFormat.TopLeft);
                gfx.DrawString(dept_name, font, XBrushes.Black,
                 new XRect(186, 458, page.Width, page.Height),
                 XStringFormat.TopLeft);
                gfx.DrawString(dept_phone, font, XBrushes.Black,
                 new XRect(436, 458, page.Width, page.Height),
                 XStringFormat.TopLeft);
                gfx.DrawString(dept_address, font1, XBrushes.Black,
                 new XRect(57, 493, page.Width, page.Height),
                 XStringFormat.TopLeft);
                // Save the document...
                filename = fname + " " + id + "ClassApplication.pdf";
            }
            else
            {
            }
            String directory = @"D:\";
            document.Save(Path.Combine(directory, filename));
            // ...and start a viewer.
            //    Process.Start(filename);
            var fileName1 = @"D:\" + filename;
            var startInfo = new ProcessStartInfo(fileName1);
            string verbToUse = "Open";
            startInfo.Verb = verbToUse;
            Process print = Process.Start(startInfo);
            EnrollmentInfo.DataBind();
        }
    }
}