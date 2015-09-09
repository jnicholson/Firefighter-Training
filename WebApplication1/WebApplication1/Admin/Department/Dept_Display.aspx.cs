using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.Admin.Department
{
    public partial class Dept_Display : System.Web.UI.Page
    {
        private readonly HalonContext db = new WebApplication1.HalonModels.HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string departmentAction = Request.QueryString["DepartmentAction"];
            if (departmentAction == "remove")
            {
                LabelRemoveStatus.Text = "Department removed!";
            }
            if (departmentAction == "add")
            {
                LabelEditStatus.Text = "Department added!";
            }
            if (departmentAction == "update")
            {
                LabelEditStatus.Text = "Department updated!";
            }

            if (!IsPostBack)
            {
                DeptList.DataBind();
            }
        }

        public IQueryable<WebApplication1.HalonModels.Department> GetDepartments()
        {
            IQueryable<WebApplication1.HalonModels.Department> depts = db.Departments;
            return depts;
        }

        /// <summary>
        /// Remove the user being chosen
        /// by the user drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RemoveDepartmentButton_Click(object sender, EventArgs e)
        {
            HalonModels.Department[] removeList = new HalonModels.Department[DeptList.Rows.Count];

            for (int i = 0; i < DeptList.Rows.Count; i++)
            {
                IOrderedDictionary rowValues = new OrderedDictionary();
                rowValues = GetValues(DeptList.Rows[i]);
                int tempID = Convert.ToInt32(rowValues["Dept_ID"]);

                CheckBox cbRemove = new CheckBox();
                cbRemove = (CheckBox)DeptList.Rows[i].FindControl("RemoveDept");
                if (cbRemove.Checked)
                {
                    var myItem = (from c in db.Departments where c.Dept_ID == tempID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        //Remove all related items to this department first

                        //then remove the department
                        db.Departments.Remove(myItem);
                        db.SaveChanges();

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl + "?DepartmentAction=remove");
                    }
                    else
                    {
                        LabelRemoveStatus.Text = "Unable to locate Department.";
                    }
                }
            }
        }

        /// <summary>
        /// Update the department being chosen
        /// by the user drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateDepartmentButton_Click(object sender, EventArgs e)
        {
            HalonModels.Department[] removeList = new HalonModels.Department[DeptList.Rows.Count];

            for (int i = 0; i < DeptList.Rows.Count; i++)
            {
                IOrderedDictionary rowValues = new OrderedDictionary();
                rowValues = GetValues(DeptList.Rows[i]);
                int tempID = Convert.ToInt32(rowValues["Dept_ID"]);

                CheckBox cbRemove = new CheckBox();
                cbRemove = (CheckBox)DeptList.Rows[i].FindControl("RemoveDept");
                if (cbRemove.Checked)
                {
                    var myItem = (from c in db.Departments where c.Dept_ID == tempID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        Session["dept_id"] = tempID;
                        // Load Update page.
                        Response.Redirect("/Admin/Department/Dept_Add.aspx");
                    }
                    else
                    {
                        LabelRemoveStatus.Text = "Unable to locate Department.";
                    }
                }
            }
        }

        /// <summary>
        /// Extract a cell within a row in the gridview
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }
    }
}