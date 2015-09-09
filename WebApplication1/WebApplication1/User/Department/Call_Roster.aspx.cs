using System;
using System.Linq;
using WebApplication1.HalonModels;

namespace WebApplication1.User.Department
{
    public partial class Call_Roster : System.Web.UI.Page
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

        public IQueryable<HalonModels.Firefighter> GetFirefighters()
        {
            DeptID = Convert.ToInt32(Session["DeptID"]);
            DeptDD.SelectedIndex = DeptID;

            if (DeptID == 0)
            {
                IQueryable<HalonModels.Firefighter> firefighters = _db.Firefighters;
                FilterLabel.Text = "All Departments";
                return firefighters;
            }
            else
            {
                IQueryable<HalonModels.Firefighter> firefighters = from f in _db.Firefighters where f.Dept_ID == DeptID select f;
                FilterLabel.Text = Convert.ToString(Session["DeptName"]);
                return firefighters;
            }
        }

        /*protected string GetDeptPhone(int DeptID)
        {
            string department_phone;
            IQueryable dept_phone = from d in _db.Departments where d.Dept_ID == DeptID select d;
            department_phone = dept_phone.ToString();
            return department_phone;
        }*/

        protected void GetRoster_Click(object sender, EventArgs e)
        {
            int DeptID = DeptDD.SelectedIndex;
            //string department_phone;
            //if (DeptID != 0)
            //{
            //department_phone = Convert.ToString(GetDeptPhone(DeptID));
            //Session["DeptPhone"] = department_phone;
            //}

            Session["DeptID"] = DeptID.ToString();
            Session["DeptName"] = DeptDD.SelectedItem;
            Response.Redirect("/User/Department/Call_Roster.aspx");
        }
    }
}