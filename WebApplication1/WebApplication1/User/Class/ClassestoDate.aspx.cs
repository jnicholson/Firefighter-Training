using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.User.Class
{
    public partial class ClassestoDate : System.Web.UI.Page
    {
        private List<HalonModels.Firefighter> firefighters;
        private List<HalonModels.Course> courses;
        private readonly HalonContext _db = new HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<HalonModels.Class> GetClasses()
        {
            IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = _db.Firefighters;
            string firefighter_UName = Page.User.Identity.Name;
            ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));

            IQueryable<HalonModels.Firefighter> fireFighterHolder = _db.Firefighters;
            firefighters = fireFighterHolder.ToList();

            IQueryable<HalonModels.Course> courseHolder = _db.Courses;
            courses = courseHolder.ToList();

            IQueryable<HalonModels.Enrollment> enrollmentHolder = _db.Enrollments;
            enrollmentHolder = enrollmentHolder.Where(e => e.Firefighter_ID == ffquery.FirstOrDefault().Firefighter_ID);

            IQueryable<HalonModels.Class> query = _db.Classes;
            List<HalonModels.Class> returnList = new List<HalonModels.Class>();

            List<HalonModels.Enrollment> enrollList = enrollmentHolder.ToList();
            List<HalonModels.Class> classList = query.ToList();

            for (int i = 0; i < enrollList.Count(); i++)
            {
                for (int j = 0; j < classList.Count(); j++)
                {
                    if (enrollList[i].Class_ID == classList[j].Class_ID)
                    {
                        returnList.Add(classList[j]);
                    }
                }
            }
            query = returnList.AsQueryable<HalonModels.Class>();
            query = query.OrderByDescending(c => c.Class_Date);
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
    }
}