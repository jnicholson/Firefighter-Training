using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplication1.HalonModels;

namespace WebApplication1.User.Department
{
    public partial class Dept_Info : System.Web.UI.Page
    {
        // Get DB context.
        private HalonContext _db = new HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = _db.Firefighters;
                    string firefighter_UName = Page.User.Identity.Name;
                    ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));
                    int dept_id = Convert.ToInt32(ffquery.First().Dept_ID);
                    List<HalonModels.Department> query = _db.Departments.Where(p => p.Dept_ID == dept_id).ToList();

                    HalonModels.Department editdepartment = query.FirstOrDefault();
                    if (editdepartment != null)
                    {
                        Dept_Info_FDID.Text = editdepartment.Dept_FDID;
                        Dept_Info_Name.Text = editdepartment.Dept_Name;
                        Dept_Info_Address.Text = editdepartment.Dept_Address;
                        Dept_Info_City.Text = editdepartment.Dept_City;
                        Dept_Info_Tel_No.Text = editdepartment.Dept_Tel_No;
                        Dept_Info_Zip.Text = editdepartment.Dept_Zip;
                        Dept_Info_Firefighter_ID.Text = editdepartment.Firefighter_ID.ToString();
                        Dept_Info_Count_ID.Text = editdepartment.County_ID.ToString();
                        Dept_Info_Callsign.Text = editdepartment.Dept_Callsign;
                    }
                }
                catch (IOException ex)
                {
                    // LabelAddStatus.Text = ex.Message;
                }
            }
        }
    }
}