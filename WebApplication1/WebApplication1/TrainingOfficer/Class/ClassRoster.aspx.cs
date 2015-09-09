using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.TrainingOfficer.Class
{
    public partial class ClassRoster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private HalonContext _db = new HalonContext();

        public IQueryable<HalonModels.Class> GetClasses()
        {
            IQueryable<HalonModels.Class> classes = _db.Classes;
            return classes;
        }

        public IQueryable<HalonModels.Enrollment> GetEnrollments()
        {
            int ClassID = Convert.ToInt32(Session["ClassID"]);
            ClassDD.SelectedIndex = ClassID;

            if (ClassID == 0)
            {
                IQueryable<HalonModels.Enrollment> enroll = _db.Enrollments;
                FilterLabel.Text = "All Enrollments";
                return enroll;
            }
            else
            {
                IQueryable<HalonModels.Enrollment> enroll = from f in _db.Enrollments where f.Class_ID == ClassID select f;
                FilterLabel.Text = Convert.ToString(Session["ClassName"]);
                return enroll;
            }
        }

        protected void GetRoster_Click(object sender, EventArgs e)
        {
            int ClassID = ClassDD.SelectedIndex;

            Session["ClassID"] = ClassID.ToString();
            Session["ClassName"] = ClassDD.SelectedItem;
            Response.Redirect("/TrainingOfficer/Class/ClassRoster.aspx");
        }

        protected void DeleteEnrollmentButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FFRoster.Rows.Count; i++)
            {
                int enrollmentID = Convert.ToInt32(FFRoster.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)FFRoster.Rows[i].FindControl("editDeleteBox");
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
    }
}