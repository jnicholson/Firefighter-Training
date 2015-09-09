using System;
using System.Linq;
using WebApplication1.HalonModels;

namespace WebApplication1.Admin.Firefighter
{
    public partial class Firefighter_Display : System.Web.UI.Page
    {
        private readonly HalonContext db = new WebApplication1.HalonModels.HalonContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<WebApplication1.HalonModels.Firefighter> GetFirefighters()
        {
            IQueryable<WebApplication1.HalonModels.Firefighter> firefighters = db.Firefighters;
            return firefighters;
        }
    }
}