using System;
using System.Linq;
using WebApplication1.HalonModels;

namespace WebApplication1.Admin.County
{
    public partial class County_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int county = Convert.ToInt16(Request.QueryString["CountyId"]);
                if (!(county == 0))
                {
                    countyAddTitle.InnerHtml = "<h1>Edit County</h1>";
                    AddCountyButton.Text = "Edit County";
                    var db = new HalonContext();
                    var myCounty = (from c in db.Counties where c.County_ID == county select c).FirstOrDefault();
                    StateDD.SelectedValue = myCounty.State_ID.ToString();
                    AddCounty_Name.Text = myCounty.County_Name;
                }
            }
        }

        public IQueryable<HalonModels.State> GetStates()
        {
            var db = new WebApplication1.HalonModels.HalonContext();
            IQueryable<HalonModels.State> query = db.States;
            return query;
        }

        protected void AddCounty_Click(object sender, EventArgs e)
        {
            int countyId = Convert.ToInt16(Request.QueryString["CountyId"]);
            bool editSuccess;
            if (countyId == 0)
            {
                editSuccess = AddCounty(AddCounty_Name.Text, StateDD.SelectedValue);
            }
            else
            {
                editSuccess = EditCounty(countyId.ToString(), AddCounty_Name.Text, StateDD.SelectedValue);
            }
            if (editSuccess)
            {
                // Reload the page.
                Response.Redirect("/Admin/County/County_Display.aspx");
            }
        }

        private bool AddCounty(string name, string stateID)
        {
            var _db = new WebApplication1.HalonModels.HalonContext();
            HalonModels.County myCounty = new HalonModels.County();
            myCounty.County_Name = name;
            myCounty.State_ID = Convert.ToInt32(stateID);

            // Add product to DB.
            _db.Counties.Add(myCounty);
            _db.SaveChanges();

            // Success.
            return true;
        }

        private bool EditCounty(string countyId, string name, string stateID)
        {
            var _db = new WebApplication1.HalonModels.HalonContext();
            int county_ID = Convert.ToInt32(countyId);
            var myCounty = (from c in _db.Counties where c.County_ID == county_ID select c).FirstOrDefault();
            myCounty.County_Name = name;
            myCounty.State_ID = Convert.ToInt32(stateID);

            // Add product to DB.
            _db.SaveChanges();

            // Success.
            return true;
        }
    }
}