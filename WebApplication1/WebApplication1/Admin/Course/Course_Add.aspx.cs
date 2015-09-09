using System;
using System.Linq;
using WebApplication1.HalonModels;
using WebApplication1.Logic;

namespace WebApplication1.Admin.Course
{
    public partial class Course_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int courseID = Convert.ToInt16(Request.QueryString["CourseID"]);
                if (!(courseID == 0))
                {
                    AddCourseHeader.Text = "Update Course:";
                    AddCourseButton.Text = "Update Course";
                    var db = new HalonContext();
                    var myCourse = (from c in db.Courses where c.Course_ID == courseID select c).FirstOrDefault();
                    AddCourseName.Text = myCourse.Course_Name.ToString();

                    if (myCourse.Course_Discontinued)
                        AddCourseDiscontinued.SelectedIndex = 1;
                    else
                        AddCourseDiscontinued.SelectedIndex = 0;

                    AddCourseCreditHours.Text = myCourse.Course_Credit_Hours.ToString();
                }
            }
        }

        protected void AddCourseButton_Click(object sender, EventArgs e)
        {
            int courseId = Convert.ToInt16(Request.QueryString["CourseId"]);

            bool discontinued = false;
            bool editSuccess;

            if (AddCourseDiscontinued.SelectedIndex == 1)
                discontinued = true;

            EditCourse edit = new EditCourse();

            if (courseId == 0)
            {
                editSuccess = edit.EditRoll(AddCourseName.Text, discontinued, AddCourseCreditHours.Text);
            }
            else
            {
                editSuccess = edit.EditRoll(courseId, AddCourseName.Text, discontinued, AddCourseCreditHours.Text);
            }

            if (editSuccess)
            {
                // Reload the page.
                Response.Redirect("/Admin/Course/Course_Display.aspx");
            }
        }
    }
}