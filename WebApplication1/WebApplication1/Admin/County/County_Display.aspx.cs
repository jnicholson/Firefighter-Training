using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.Admin.County
{
    public partial class County_Display : System.Web.UI.Page
    {
        private readonly HalonContext db = new WebApplication1.HalonModels.HalonContext();
        private List<HalonModels.State> states;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        public IQueryable<WebApplication1.HalonModels.County> GetCounties()
        {
            states = db.States.ToList();
            IQueryable<WebApplication1.HalonModels.County> counties = db.Counties;
            return counties;
        }

        public List<WebApplication1.HalonModels.State> GetStates()
        {
            return states;
        }

        protected void Counties_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HalonModels.County county = e.Row.DataItem as HalonModels.County;
                for (int i = 0; i < states.Count(); i++)
                {
                    if (county.State_ID == states[i].State_ID)
                    {
                        e.Row.Cells[2].Text = states[i].State_Name;
                    }
                }
            }
        }

        protected void RemoveCountyButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CountyList.Rows.Count; i++)
            {
                int countyID = Convert.ToInt32(CountyList.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)CountyList.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    var myCounties = (from c in db.Counties where c.County_ID == countyID select c).FirstOrDefault();
                    if (myCounties != null)
                    {
                        //then remove the county
                        db.Counties.Remove(myCounties);
                        db.SaveChanges();

                        // Reload the page.
                        string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                        Response.Redirect(pageUrl);
                    }
                    else
                    {
                        //LabelRemoveStatus.Text = "Unable to locate Department.";
                    }
                }
            }
        }

        protected void UpdateCountyButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CountyList.Rows.Count; i++)
            {
                int countyID = Convert.ToInt32(CountyList.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)CountyList.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    var myClass = (from c in db.Counties where c.County_ID == countyID select c).FirstOrDefault();
                    if (myClass != null)
                    {
                        string pageUrl = "/Admin/County/County_Add.aspx";
                        Response.Redirect(pageUrl + "?CountyId=" + countyID.ToString());
                    }
                }
            }
        }
    }
}