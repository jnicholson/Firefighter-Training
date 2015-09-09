using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.Printouts
{
    public partial class DepartmentStatus : System.Web.UI.Page
    {
        private List<HalonModels.Firefighter> firefighters;
        private List<HalonModels.Course> courses;
        private List<HalonModels.Enrollment> enrollments;
        private List<HalonModels.Class> classes;
        private readonly HalonContext _db = new HalonContext();
        private int year = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetFirefighters();
            loadDynamicGrid();
            colorGrid();
            totalDeptHours();
            getYears();
        }

        private void loadDynamicGrid()
        {
            year = Convert.ToInt32(Request.QueryString["year"]);
            if (year == 0)
            {
                DateTime now = DateTime.Now;
                year = now.Year;
            }
            DataTable table = new DataTable();
            table.Columns.Add("Firefighter", typeof(string));
            for (int i = 0; i < courses.Count; i++)
            {
                string columnTitle = courses.ElementAt(i).Course_Name;
                table.Columns.Add(columnTitle, typeof(string));
            }
            table.Columns.Add("Hours", typeof(string));
            table.Columns.Add(" ", typeof(string));

            for (int j = 0; j < firefighters.Count; j++)
            {
                string[] enrollDates = new string[courses.Count + 3];
                string[] enrollHours = new string[courses.Count + 3];
                enrollHours[0] = (firefighters.ElementAt(j).Firefighter_Fname + " " + firefighters.ElementAt(j).Firefighter_Lname);
                enrollDates[0] = firefighters.ElementAt(j).Firefighter_Rank;
                int yrToDate = 0, allTime = 0;
                yrToDate = getYrToDate(firefighters.ElementAt(j).Firefighter_ID);
                allTime = getAllTime(firefighters.ElementAt(j).Firefighter_ID);
                getDateRows(firefighters.ElementAt(j).Firefighter_ID, enrollDates);
                getHourRows(firefighters.ElementAt(j).Firefighter_ID, enrollHours);
                enrollDates[enrollDates.Length - 2] = yrToDate.ToString();
                enrollDates[enrollDates.Length - 1] = "YTD";
                enrollHours[enrollHours.Length - 2] = allTime.ToString();
                enrollHours[enrollHours.Length - 1] = "Total";
                table.Rows.Add(enrollHours);
                table.Rows.Add(enrollDates);
            }

            foreach (DataColumn col in table.Columns)
            {
                BoundField bField = new BoundField();
                bField.DataField = col.ColumnName;
                bField.HeaderText = col.ColumnName;
                StatusInfo.Columns.Add(bField);
            }

            StatusInfo.DataSource = table;
            StatusInfo.DataBind();
        }

        public void GetFirefighters()
        {
            int departmentId;
            departmentId = Convert.ToInt32(Request.QueryString["departmentId"]);
            if (departmentId == 0)
            {
                // Response.Redirect("/Admin/Department/Dept_Display.aspx");
            }

            IQueryable<HalonModels.Firefighter> fireFighterHolder = _db.Firefighters;
            fireFighterHolder = fireFighterHolder.Where(f => f.Dept_ID == departmentId);
            firefighters = fireFighterHolder.ToList();
            firefighterCount.Text = firefighters.Count().ToString();

            IQueryable<HalonModels.Course> courseHolder = _db.Courses;
            courseHolder = courseHolder.Where(c => c.Course_Discontinued == false);
            courses = courseHolder.ToList();

            IQueryable<HalonModels.Class> classHolder = _db.Classes;
            classHolder = classHolder.Where(c => c.Class_Cancelled == false);

            List<HalonModels.Class> classList = classHolder.ToList();
            for (int i = 0; i < classList.Count; i++)
            {
                if (year < DateTime.Parse(classList[i].Class_Date).Year)
                {
                    classList.Remove(classList[i]);
                }
            }
            classes = classList;

            IQueryable<HalonModels.Enrollment> enrollHolder = _db.Enrollments;
            enrollments = enrollHolder.ToList();
        }

        private void getDateRows(int firefighter_ID, string[] enrollArray)
        {
            IQueryable<HalonModels.Enrollment> enrollHolder = enrollments.AsQueryable();
            enrollHolder = enrollHolder.Where(e => e.Firefighter_ID == firefighter_ID);
            for (int j = 0; j < courses.Count; j++)
            {
                int[] validClasses = new int[enrollHolder.Count()];
                IQueryable<HalonModels.Class> classHolder = getCourse(j);
                string output = "";
                if (!(classHolder.Count() == 0))
                {
                    output = classHolder.Last().Class_Date;
                }
                for (int k = 0; k < enrollHolder.Count(); k++)
                {
                    if (!(classHolder.Count() == 0))
                    {
                        if (classHolder.Last().Class_ID == enrollHolder.ElementAt(k).Class_ID)
                        {
                            enrollArray[j + 1] = output;
                        }
                        else
                            enrollArray[j + 1] = "";
                    }
                    else
                        enrollArray[j + 1] = "";
                }
            }
        }

        private IQueryable<HalonModels.Class> getCourse(int j)
        {
            IQueryable<HalonModels.Class> classHolder = classes.AsQueryable();
            classHolder = classHolder.Where(c => c.Course_ID == courses.ElementAt(j).Course_ID);
            return classHolder;
        }

        private void getHourRows(int firefighter_ID, string[] enrollArray)
        {
            IQueryable<HalonModels.Enrollment> enrollHolder = enrollments.AsQueryable();
            enrollHolder = enrollHolder.Where(e => e.Firefighter_ID == firefighter_ID);
            for (int j = 0; j < courses.Count; j++)
            {
                int[] validClasses = new int[enrollHolder.Count()];
                IQueryable<HalonModels.Class> classHolder = getCourse(j);
                string output = "";
                if (!(classHolder.Count() == 0))
                {
                    output = classHolder.Last().Course.Course_Credit_Hours;
                }
                for (int k = 0; k < enrollHolder.Count(); k++)
                {
                    if (!(classHolder.Count() == 0))
                    {
                        if (classHolder.Last().Class_ID == enrollHolder.ElementAt(k).Class_ID && enrollHolder.ElementAt(k).Class.Course_ID != 30)
                        {
                            enrollArray[j + 1] = output;
                        }
                        else if (classHolder.Last().Class_ID == enrollHolder.ElementAt(k).Class_ID && enrollHolder.ElementAt(k).Class.Course_ID == 30)
                        {
                            enrollArray[j + 1] = inHouseTotal(firefighter_ID).ToString();
                        }
                        else
                            enrollArray[j + 1] = "";
                    }
                    else
                        enrollArray[j + 1] = "";
                }
            }
        }

        private int getYrToDate(int firefighter_ID)
        {
            int total = 0;
            IQueryable<HalonModels.Enrollment> enrollHolder = enrollments.AsQueryable();
            enrollHolder = enrollHolder.Where(e => e.Firefighter_ID == firefighter_ID);
            int currentCourse = 0;
            for (int i = 0; i < enrollHolder.Count(); i++)
            {
                if (thisYear(enrollHolder.ElementAt(i).Class.Class_Date))
                {
                    if (thisYear(enrollHolder.ElementAt(i).Class.Class_Date) && enrollHolder.ElementAt(i).Class.Course_ID != 30 && enrollHolder.ElementAt(i).Class.Course_ID != currentCourse)
                    {
                        currentCourse = (int)enrollHolder.ElementAt(i).Class.Course_ID;
                        total += Convert.ToInt32(enrollHolder.ElementAt(i).Class.Course.Course_Credit_Hours);
                    }
                    else if (thisYear(enrollHolder.ElementAt(i).Class.Class_Date) && enrollHolder.ElementAt(i).Class.Course_ID == 30 && enrollHolder.ElementAt(i).Class.Course_ID != currentCourse)
                    {
                        currentCourse = (int)enrollHolder.ElementAt(i).Class.Course_ID;
                        total += inHouseTotal(firefighter_ID);
                    }
                }
            }
            return total;
        }

        private int getAllTime(int firefighter_ID)
        {
            int total = 0;
            IQueryable<HalonModels.Enrollment> enrollHolder = enrollments.AsQueryable();
            enrollHolder = enrollHolder.Where(e => e.Firefighter_ID == firefighter_ID);
            for (int i = 0; i < enrollHolder.Count(); i++)
            {
                if (thisYearOrLess(enrollHolder.ElementAt(i).Class.Class_Date))
                {
                    total += Convert.ToInt32(enrollHolder.ElementAt(i).Class.Course.Course_Credit_Hours);
                }
            }
            return total;
        }

        private bool thisYear(string dateString)
        {
            bool thisYear = false;
            DateTime dt = DateTime.Parse(dateString);
            DateTime now = DateTime.Now;
            if (dt.Year == year)
            {
                thisYear = true;
            }
            return thisYear;
        }

        private bool thisYearOrLess(string dateString)
        {
            bool thisYear = false;
            DateTime dt = DateTime.Parse(dateString);
            DateTime now = DateTime.Now;
            if (dt.Year <= year)
            {
                thisYear = true;
            }
            return thisYear;
        }

        private void colorGrid()
        {
            int completedFirefighters = 0;
            for (int i = 2; i < StatusInfo.Rows.Count; i += 2)
            {
                int cellCount = StatusInfo.Rows[i].Cells.Count;
                if (Convert.ToInt32(StatusInfo.Rows[i].Cells[cellCount - 2].Text) >= 16)
                {
                    completedFirefighters += 1;
                    StatusInfo.Rows[i].Cells[0].BackColor = System.Drawing.Color.LightGreen;
                    StatusInfo.Rows[i + 1].Cells[0].BackColor = System.Drawing.Color.LightGreen;
                }
            }
            if (Convert.ToDouble(firefighterCount.Text) != 0)
            {
                int completedPercent = (int)((Convert.ToDouble(completedFirefighters) / Convert.ToDouble(firefighterCount.Text)) * 100);
                percentLabel.Text = completedPercent.ToString() + "%";
            }
        }

        private void getYears()
        {
            DateTime now = DateTime.Now;
            for (int i = now.Year; i >= 2010; i--)
            {
                ListItem item = new ListItem(i.ToString());
                yearDrop.Items.Add(item);
            }
            DepartmentListTitle.InnerHtml = "<h1>Department Status in " + year.ToString() + ":</h1>";
        }

        protected void StatusInfo_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                e.Row.Cells[0].CssClass = "locked";
            }
        }

        private int inHouseTotal(int firefighter_ID)
        {
            int total = 0;
            IQueryable<HalonModels.Enrollment> enrollHolder = enrollments.AsQueryable();
            enrollHolder = enrollHolder.Where(e => e.Firefighter_ID == firefighter_ID);
            enrollHolder = enrollHolder.Where(e => e.Class.Course_ID == 30);
            for (int i = 0; i < enrollHolder.Count(); i++)
            {
                if (thisYear(enrollHolder.ElementAt(i).Class.Class_Date) && enrollHolder.ElementAt(i).Class.Course_ID == 30)
                {
                    total += 1;
                }
            }
            return total;
        }

        public void totalDeptHours()
        {
            int total = 0;
            for (int i = 0; i < StatusInfo.Rows.Count; i += 2)
            {
                total += Convert.ToInt32(StatusInfo.Rows[i].Cells[StatusInfo.Rows[i].Cells.Count - 2].Text);
            }
            totalLabel.Text = total.ToString();
        }

        protected void Change_Year_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Printouts/DepartmentStatus?departmentId=" + Request.QueryString["departmentId"] + "&year=" + yearDrop.SelectedItem.Text);
        }
    }
}