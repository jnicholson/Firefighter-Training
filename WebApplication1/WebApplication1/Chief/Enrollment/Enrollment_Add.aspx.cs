using System;
using System.Linq;
using WebApplication1.HalonModels;
using WebApplication1.Logic;

namespace WebApplication1.Chief.Enrollment
{
    public partial class Enrollment_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int enrollmentId = Convert.ToInt16(Request.QueryString["EnrollmentId"]);
                AddEnrollmentButton.Text = "Add Enrollment";
                if (!(enrollmentId == 0))
                {
                    enrollmentAddTitle.InnerHtml = "<h1>Edit Enrollment</h1>";
                    AddEnrollmentButton.Text = "Edit Enrollment";
                    var db = new HalonContext();
                    var myEnrollment = (from c in db.Enrollments where c.Enrollment_ID == enrollmentId select c).FirstOrDefault();
                    AddFirefighterID.Text = myEnrollment.Firefighter_ID.ToString();
                    AddClassID.Text = myEnrollment.Class_ID.ToString();
                }
            }
        }

        public IQueryable<HalonModels.Class> GetClasses()
        {
            var db = new WebApplication1.HalonModels.HalonContext();
            IQueryable<HalonModels.Class> query = db.Classes;
            return query;
        }

        protected void AddEnrollmentButton_Click(object sender, EventArgs e)
        {
            int enrollmentId = Convert.ToInt16(Request.QueryString["EnrollmentId"]);
            EditEnrollment edit = new EditEnrollment();
            bool editSuccess;
            if (enrollmentId == 0)
            {
                editSuccess = edit.EditRoll(AddClassID.Text, AddFirefighterID.Text);
            }
            else
            {
                editSuccess = edit.EditRoll(enrollmentId, AddClassID.Text, AddFirefighterID.Text);
            }
            if (editSuccess)
            {
                // Reload the page.
                Response.Redirect("Enrollment_Display.aspx");
            }
        }
    }
}