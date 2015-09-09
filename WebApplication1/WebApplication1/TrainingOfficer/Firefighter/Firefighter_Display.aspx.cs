using System;
using System.Linq;
using WebApplication1.HalonModels;

namespace WebApplication1.TrainingOfficer.Firefighter
{
    public partial class Firefighter_Display : System.Web.UI.Page
    {
        private readonly HalonContext db = new WebApplication1.HalonModels.HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<WebApplication1.HalonModels.Firefighter> GetFirefighters()
        {
            HalonContext _db = new HalonContext();
            IQueryable<WebApplication1.HalonModels.Firefighter> firefighters = _db.Firefighters;
            IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = _db.Firefighters;
            string firefighter_UName = Page.User.Identity.Name;
            ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));
            firefighters = firefighters.Where(f => f.Dept_ID == ffquery.FirstOrDefault().Dept_ID);

            return firefighters;
        }
    }
}