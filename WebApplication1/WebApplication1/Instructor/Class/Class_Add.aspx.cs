using System;
using System.Linq;
using WebApplication1.HalonModels;
using WebApplication1.Logic;

namespace WebApplication1.Instructor.Class
{
    public partial class Class_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int classId = Convert.ToInt16(Request.QueryString["ClassId"]);
                if (!(classId == 0))
                {
                    classAddTitle.InnerHtml = "<h1>Edit Class</h1>";
                    var db = new HalonContext();
                    var myClass = (from c in db.Classes where c.Class_ID == classId select c).FirstOrDefault();
                    DropDownAddCourse.SelectedValue = myClass.Course_ID.ToString();
                    AddClassDate.Text = myClass.Class_Date;
                    AddClassNote.Text = myClass.Class_ID.ToString();
                    AddClassCancel.Checked = myClass.Class_Cancelled;
                    AddClassNote.Text = myClass.Class_Note;
                }
            }
        }

        public IQueryable<HalonModels.Course> GetCourses()
        {
            var db = new WebApplication1.HalonModels.HalonContext();
            IQueryable<HalonModels.Course> query = db.Courses;
            return query;
        }

        protected void AddClassButton_Click(object sender, EventArgs e)
        {
            int classId = Convert.ToInt16(Request.QueryString["ClassId"]);
            EditClass edit = new EditClass();
            bool editSuccess;
            var db = new WebApplication1.HalonModels.HalonContext();
            IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = db.Firefighters;
            string firefighter_UName = Page.User.Identity.Name;
            ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));
            string firefighter_ID = ffquery.First().Firefighter_ID.ToString();
            if (classId == 0)
            {
                editSuccess = edit.EditClasses(AddClassCancel.Checked, firefighter_ID, DropDownAddCourse.SelectedValue.ToString(), AddClassNote.Text, AddClassDate.Text);
            }
            else
            {
                editSuccess = edit.EditClasses(classId.ToString(), AddClassCancel.Checked, firefighter_ID, DropDownAddCourse.SelectedValue.ToString(), AddClassNote.Text, AddClassDate.Text);
            }
            if (editSuccess)
            {
                // Reload the page.
                Response.Redirect("/Instructor/Class/Class_Display.aspx");
            }
        }
    }
}