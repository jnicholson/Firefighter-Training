using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication1.Printouts
{
    public partial class FireFighterCourses : System.Web.UI.Page
    {
        private WebApplication1.HalonModels.HalonContext _db = new WebApplication1.HalonModels.HalonContext();
        private int firefighterId;
        private IQueryable<WebApplication1.HalonModels.Firefighter> query;

        protected void Page_Load(object sender, EventArgs e)
        {
            firefighterId = Convert.ToInt32(Request.QueryString["Firefighter_ID"]);

            query = _db.Firefighters;
            if (firefighterId != null && firefighterId > 0)
            {
                query = query.Where(f => f.Firefighter_ID == firefighterId);
            }
            else
            {
                query = null;
            }

            litHeader.Text = query.FirstOrDefault().Firefighter_Fname.ToString()
                + " " + query.FirstOrDefault().Firefighter_Lname + "'s Completed Courses";
            if (!IsPostBack)
            {
                displayCourses();
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public void displayCourses()
        {
            // Find all enrollments this Firefighter has made
            IQueryable<WebApplication1.HalonModels.Enrollment> enroll = _db.Enrollments.Where(f => f.Firefighter_ID == firefighterId);
            List<WebApplication1.HalonModels.Course> courses = new List<WebApplication1.HalonModels.Course>();
            List<WebApplication1.HalonModels.Class> allclass = _db.Classes.ToList();
            List<WebApplication1.HalonModels.Course> allcourse = _db.Courses.ToList();

            if (enroll.Count() > 0)
            {
                int temp = 0;
                WebApplication1.HalonModels.Class cl = new WebApplication1.HalonModels.Class();
                int totalhours = 0;
                foreach (var enrol in enroll) // And for each of his enrollment
                {
                    temp = Convert.ToInt32(enrol.Class_ID.ToString());
                    // Look for the class described in this enrollment
                    cl = allclass.Where(c => c.Class_ID == temp).FirstOrDefault();
                    int temp1 = Convert.ToInt32(cl.Course_ID.ToString()); // Get its Course_ID

                    // Look for the course related to above class
                    WebApplication1.HalonModels.Course co = allcourse.Where(d => d.Course_ID == temp1).FirstOrDefault();

                    totalhours += Convert.ToInt32(co.Course_Credit_Hours.ToString());
                    // Add the course to the display list
                    courses.Add(co);
                }

                IQueryable<WebApplication1.HalonModels.Course> list = courses.AsQueryable();
                Classes.DataSource = list;
                Classes.DataBind();

                for (int i = 0; i < Classes.Rows.Count; i++)
                {
                    Label classid = (Label)Classes.Rows[i].Cells[0].FindControl("Class_ID");
                    classid.Text = temp.ToString(); // Assign class ID to each record

                    Label classdate = (Label)Classes.Rows[i].Cells[0].FindControl("Class_Date");
                    classdate.Text = cl.Class_Date.ToString(); // Assign class date to each record
                }

                hours.Text += "Total Hours: " + totalhours.ToString();
            }
            else
            {
                litHeader.Text = query.FirstOrDefault().Firefighter_Fname.ToString()
                + " " + query.FirstOrDefault().Firefighter_Lname + " has not completed any courses";
            }
            //return list;
        }
    }
}