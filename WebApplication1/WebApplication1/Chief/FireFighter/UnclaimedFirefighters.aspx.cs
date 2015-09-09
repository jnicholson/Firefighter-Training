using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.Chief.FireFighter
{
    public partial class UnclaimedFirefighters : System.Web.UI.Page
    {
        private readonly HalonContext db = new WebApplication1.HalonModels.HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<WebApplication1.HalonModels.Firefighter> GetFirefighters()
        {
            IQueryable<HalonModels.Firefighter> query = db.Firefighters;
            query = query.Where(f => f.Dept_ID == null);

            return query;
        }

        protected void ClaimFirefighter(object sender, EventArgs e)
        {
            IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = db.Firefighters;
            string firefighter_UName = Page.User.Identity.Name;
            ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));
            var dept = ffquery.FirstOrDefault().Dept_ID;

            for (int i = 0; i < FirefighterList.Rows.Count; i++)
            {
                int firefighter_ID = Convert.ToInt32(FirefighterList.Rows[i].Cells[0].Text);
                CheckBox checkbox = (CheckBox)FirefighterList.Rows[i].FindControl("ClaimBox");
                if (checkbox.Checked)
                {
                    IQueryable<WebApplication1.HalonModels.Firefighter> firefighters = db.Firefighters;
                    firefighters = firefighters.Where(f => f.Firefighter_ID == firefighter_ID);
                    HalonModels.Firefighter ff = firefighters.FirstOrDefault();
                    ff.Dept_ID = dept;
                    db.SaveChanges();
                }
                Response.Redirect("/Chief/Firefighter/UnclaimedFIrefighters.aspx");
            }
        }
    }
}