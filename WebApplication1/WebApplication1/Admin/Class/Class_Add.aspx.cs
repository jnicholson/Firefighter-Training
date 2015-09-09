using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using WebApplication1.HalonModels;
using WebApplication1.Logic;

namespace WebApplication1.Admin.Class
{
    public partial class Class_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTeachers();
                int classId = Convert.ToInt16(Request.QueryString["ClassId"]);
                if (!(classId == 0))
                {
                    classAddTitle.InnerHtml = "<h1>Edit Class</h1>";
                    var db = new HalonContext();
                    var myClass = (from c in db.Classes where c.Class_ID == classId select c).FirstOrDefault();
                    DropDownAddCourse.SelectedValue = myClass.Course_ID.ToString();
                    AddClassDate.Text = myClass.Class_Date;
                    AddClassNote.Text = myClass.Class_ID.ToString();
                    DropDownAddTeacher.SelectedValue = myClass.Firefighter_ID.ToString();
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

        public void GetTeachers()
        {
            var _db = new WebApplication1.HalonModels.HalonContext();

            IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = _db.Firefighters;
            string firefighter_UName = Page.User.Identity.Name;
            ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));

            IQueryable<WebApplication1.HalonModels.Firefighter> ffighters = _db.Firefighters;
            ffighters = ffighters.Where(f => f.Firefighter_Account_Username != null);

            List<HalonModels.Firefighter> returnList = new List<HalonModels.Firefighter>();
            foreach (HalonModels.Firefighter f in ffighters)
            {
                if (Roles.GetRolesForUser(f.Firefighter_Account_Username)[0] != "User")
                {
                    returnList.Add(f);
                }
            }

            IQueryable<HalonModels.Firefighter> query = _db.Firefighters;

            query = returnList.AsQueryable<HalonModels.Firefighter>();

            List<HalonModels.Firefighter> list = query.ToList();

            DropDownAddTeacher.DataSource = list;
            DropDownAddTeacher.DataValueField = "Firefighter_ID";

            DropDownAddTeacher.DataBind();

            for (int i = 0; i < list.Count; i++)
            {
                DropDownAddTeacher.Items[i].Text = list[i].Firefighter_Fname + " " + list[i].Firefighter_Lname;
            }
        }

        protected void AddClassButton_Click(object sender, EventArgs e)
        {
            int classId = Convert.ToInt16(Request.QueryString["ClassId"]);
            EditClass edit = new EditClass();
            bool editSuccess;
            if (classId == 0)
            {
                editSuccess = edit.EditClasses(AddClassCancel.Checked, DropDownAddTeacher.SelectedValue, DropDownAddCourse.SelectedValue.ToString(), AddClassNote.Text, AddClassDate.Text);
            }
            else
            {
                editSuccess = edit.EditClasses(classId.ToString(), AddClassCancel.Checked, DropDownAddTeacher.SelectedValue, DropDownAddCourse.SelectedValue.ToString(), AddClassNote.Text, AddClassDate.Text);
            }
            if (editSuccess)
            {
                // Reload the page.
                Response.Redirect("/Admin/Class/Class_Display.aspx");
            }
        }
    }
}