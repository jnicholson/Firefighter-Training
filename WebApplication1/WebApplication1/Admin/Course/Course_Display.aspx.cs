using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.Admin.Course
{
    public partial class Course_Display : System.Web.UI.Page
    {
        private List<HalonModels.Course> courses;
        private readonly HalonContext _db = new HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<HalonModels.Course> GetCourses()
        {
            IQueryable<HalonModels.Course> courseHolder = _db.Courses;
            courses = courseHolder.ToList();

            return courseHolder;
        }

        //********************************************************************

        protected void EditCourseButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CourseInfo.Rows.Count; i++)
            {
                int courseID = Convert.ToInt32(CourseInfo.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)CourseInfo.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    var myCourse = (from c in _db.Courses where c.Course_ID == courseID select c).FirstOrDefault();
                    if (myCourse != null)
                    {
                        string pageUrl = "/Admin/Course/Course_Add.aspx";
                        Response.Redirect(pageUrl + "?CourseId=" + courseID.ToString());
                    }
                }
            }
        }

        protected void DeleteCourseButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CourseInfo.Rows.Count; i++)
            {
                int courseID = Convert.ToInt32(CourseInfo.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)CourseInfo.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    var myCourse = (from c in _db.Courses where c.Course_ID == courseID select c).FirstOrDefault();
                    if (myCourse != null)
                    {
                        //cascade the course removal

                        //then remove the course
                        _db.Courses.Remove(myCourse);
                        _db.SaveChanges();

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl);
                    }
                    else
                    {
                        //LabelRemoveStatus.Text = "Unable to locate Course.";
                    }
                }
            }
        }
    }
}