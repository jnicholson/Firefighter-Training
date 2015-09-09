using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplication1.HalonModels;

namespace WebApplication1.Chief.Department
{
    public partial class Dept_Add : System.Web.UI.Page
    {
        // Get DB context.
        private HalonContext _db = new HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["dept_id"] != null)
                    {
                        deptAddTitle.InnerHtml = "<h1>Edit Department</h1>";
                        AddDeptButton.Enabled = false;
                        AddDeptButton.Visible = false;
                        int id = Convert.ToInt32(Session["dept_id"].ToString());
                        List<HalonModels.Department> query = _db.Departments.Where(p => p.Dept_ID == id).ToList();

                        HalonModels.Department editdepartment = query.FirstOrDefault();
                        if (editdepartment != null)
                        {
                            AddDept_FDID.Text = editdepartment.Dept_FDID;
                            AddDept_Name.Text = editdepartment.Dept_Name;
                            AddDept_Address.Text = editdepartment.Dept_Address;
                            AddDept_City.Text = editdepartment.Dept_City;
                            AddDept_Tel_No.Text = editdepartment.Dept_Tel_No;
                            AddDept_Zip.Text = editdepartment.Dept_Zip;
                            AddDept_Firefighter_ID.Text = editdepartment.Firefighter_ID.ToString();
                            AddDept_Count_ID.Text = editdepartment.County_ID.ToString();
                            AddDept_Callsign.Text = editdepartment.Dept_Callsign;
                        }
                    }
                    else
                    {
                        UpdateDeptButton.Enabled = false;
                        UpdateDeptButton.Visible = false;
                    }
                }
                catch (IOException ex)
                {
                    // LabelAddStatus.Text = ex.Message;
                }
            }
        }

        /// <summary>
        /// Before adding the new product to the database,
        /// check to see if the image is acceptable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddDept_Click(object sender, EventArgs e)
        {
            // Add product data to DB.
            bool addSuccess = AddDept(AddDept_FDID.Text, AddDept_Name.Text,
                AddDept_Address.Text, AddDept_City.Text, AddDept_Tel_No.Text,
                AddDept_Zip.Text, Convert.ToInt32(AddDept_Firefighter_ID.Text),
                Convert.ToInt32(AddDept_Count_ID.Text), AddDept_Callsign.Text);
            if (addSuccess)
            {
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                //Response.Redirect(pageUrl + "?DepartmentAction=add");
                Response.Redirect("/Chief/Department/Dept_Display.aspx" + "?DepartmentAction=add");
            }
            else
            {
                //LabelAddStatus.Text = "Unable to add new Department to database.";
            }
        }

        /// <summary>
        /// Before adding the new product to the database,
        /// check to see if the image is acceptable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateDept_Click(object sender, EventArgs e)
        {
            bool addSuccess = UpdateDepartment(AddDept_FDID.Text, AddDept_Name.Text,
                       AddDept_Address.Text, AddDept_City.Text, AddDept_Tel_No.Text,
                       AddDept_Zip.Text, Convert.ToInt32(AddDept_Firefighter_ID.Text),
                       Convert.ToInt32(AddDept_Count_ID.Text), AddDept_Callsign.Text);
            if (addSuccess)
            {
                // Reload the page.
                Response.Redirect("/Chief/Department/Dept_Display.aspx" + "?DepartmentAction=update");
            }
            else
            {
                //LabelAddStatus.Text = "Unable to update Department.";
            }
        }

        /// <summary>
        /// Plug information into their right column,
        /// and add the new product to the database.
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="ProductDesc"></param>
        /// <param name="ProductPrice"></param>
        /// <param name="ProductCategory"></param>
        /// <param name="ProductImagePath"></param>
        /// <returns></returns>
        public bool AddDept(string Dept_FDID, string Dept_Name, string Dept_Address, string Dept_City,
            string Dept_Tel_No, string Dept_Zip, int Firefighter_ID, int County_ID, string Dept_Callsign)
        {
            var myDepartment = new HalonModels.Department();
            myDepartment.Dept_FDID = Dept_FDID;
            myDepartment.Dept_Name = Dept_Name;
            myDepartment.Dept_Address = Dept_Address;
            myDepartment.Dept_City = Dept_City;
            myDepartment.Dept_Tel_No = Dept_Tel_No;
            myDepartment.Dept_Zip = Dept_Zip;
            myDepartment.Firefighter_ID = Firefighter_ID;
            myDepartment.County_ID = County_ID;
            myDepartment.Dept_Callsign = Dept_Callsign;

            // Add product to DB.
            _db.Departments.Add(myDepartment);
            _db.SaveChanges();

            // Success.
            return true;
        }

        /// <summary>
        /// Update products based on the given information
        /// </summary>
        /// <param name="ProductID"></param>
        /// <param name="ProductName"></param>
        /// <param name="ProductDesc"></param>
        /// <param name="ProductPrice"></param>
        /// <param name="ProductCategory"></param>
        /// <param name="ProductImagePath"></param>
        /// <param name="ProductQuantity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool UpdateDepartment(string Dept_FDID, string Dept_Name, string Dept_Address, string Dept_City,
            string Dept_Tel_No, string Dept_Zip, int Firefighter_ID, int County_ID, string Dept_Callsign)
        {
            int id = Convert.ToInt32(Session["dept_id"].ToString()); ;
            using (_db)
            {
                try
                {
                    var myItem = (from p in _db.Departments where p.Dept_ID == id select p).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Dept_FDID = Dept_FDID;
                        myItem.Dept_Name = Dept_Name;
                        myItem.Dept_Address = Dept_Address;
                        myItem.Dept_City = Dept_City;
                        myItem.Dept_Tel_No = Dept_Tel_No;
                        myItem.Dept_Zip = Dept_Zip;
                        myItem.Firefighter_ID = Firefighter_ID;
                        myItem.County_ID = County_ID;
                        myItem.Dept_Callsign = Dept_Callsign;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    return false;
                    throw new Exception("ERROR: Unable to Update Department - " + exp.Message.ToString(), exp);
                }
            }
            // Success.
            return true;
        }
    }
}