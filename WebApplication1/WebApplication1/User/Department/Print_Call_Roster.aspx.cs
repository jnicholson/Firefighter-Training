using System;
using System.Linq;
using WebApplication1.HalonModels;

namespace WebApplication1.User.Department
{
    public partial class Print_Call_Roster : System.Web.UI.Page
    {
        protected int DeptID;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private HalonContext _db = new HalonContext();

        public IQueryable<HalonModels.Department> GetDepartments()
        {
            IQueryable<HalonModels.Department> departments = _db.Departments;
            return departments;
        }

        public IQueryable<WebApplication1.HalonModels.Firefighter> GetFirefighters()
        {
            DeptID = Convert.ToInt32(Session["DeptID"]);

            if (DeptID == 0)
            {
                IQueryable<WebApplication1.HalonModels.Firefighter> firefighters = _db.Firefighters;
                FilterLabel.Text = "All Departments";
                return firefighters;
            }
            else
            {
                IQueryable<WebApplication1.HalonModels.Firefighter> firefighters = from f in _db.Firefighters where f.Dept_ID == DeptID select f;
                FilterLabel.Text = Convert.ToString(Session["DeptName"]);
                return firefighters;
            }
        }
    }
}