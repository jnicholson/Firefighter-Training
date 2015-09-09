using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.User.Class
{
    public partial class UpcomingClasses : System.Web.UI.Page
    {
        private List<HalonModels.Class> classes;
        private List<HalonModels.Firefighter> firefighters;
        private List<HalonModels.Course> courses;
        private readonly HalonContext _db = new HalonContext();
        private List<HalonModels.Enrollment> enrollments;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<HalonModels.Class> GetClasses()
        {
            IQueryable<HalonModels.Firefighter> fireFighterHolder = _db.Firefighters;
            firefighters = fireFighterHolder.ToList();

            IQueryable<HalonModels.Course> courseHolder = _db.Courses;
            courses = courseHolder.ToList();

            IQueryable<HalonModels.Class> query = _db.Classes;
            classes = query.ToList();

            List<HalonModels.Class> upcomingClasses = new List<HalonModels.Class>();

            for (int i = 0; i < classes.Count; i++)
            {
                DateTime dt = DateTime.Parse(classes.ElementAt(i).Class_Date);
                DateTime now = DateTime.Now;
                if (dt.CompareTo(now) > 0)
                {
                    upcomingClasses.Add(classes.ElementAt(i));
                }
            }

            List<HalonModels.Class> returnClasses = new List<HalonModels.Class>();

            IQueryable<HalonModels.Enrollment> enroll = _db.Enrollments;
            IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = _db.Firefighters;
            string firefighter_UName = Page.User.Identity.Name;
            ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));
            enroll = enroll.Where(e => e.Firefighter_ID == ffquery.FirstOrDefault().Firefighter_ID);
            enrollments = enroll.ToList();

            for (int i = 0; i < upcomingClasses.Count; i++)
            {
                bool alreadyEnrolled = false;
                for (int j = 0; j < enrollments.Count; j++)
                {
                    if (enrollments[j].Class_ID == upcomingClasses[i].Class_ID)
                    {
                        alreadyEnrolled = true;
                    }
                }
                if (!alreadyEnrolled)
                {
                    returnClasses.Add(upcomingClasses[i]);
                }
            }

            return returnClasses;
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
                        e.Row.Cells[1].Text = firefighters[i].Firefighter_Lname + ", " + firefighters[i].Firefighter_Fname;
                    }
                }
                for (int i = 0; i < courses.Count; i++)
                {
                    if (cls.Course_ID == courses[i].Course_ID)
                    {
                        e.Row.Cells[3].Text = courses[i].Course_Name;
                    }
                }
            }
        }

        protected void EnrollButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ClassInfo.Rows.Count; i++)
            {
                int classID = Convert.ToInt32(ClassInfo.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)ClassInfo.Rows[i].FindControl("enrollBox");
                if (checkbox.Checked)
                {
                    IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = _db.Firefighters;
                    string firefighter_UName = Page.User.Identity.Name;
                    ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));

                    Enrollment enroll = new Enrollment();
                    enroll.Class_ID = classID;
                    enroll.Firefighter_ID = ffquery.FirstOrDefault().Firefighter_ID;
                    _db.Enrollments.Add(enroll);
                    _db.SaveChanges();
                    Response.Redirect("~/User/Class/ClassestoDate.aspx");
                }
            }
        }
    }
}