using System;
using System.Web.Security;
using System.Web.UI;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.User.Identity.Name.Equals("")))
            {
                if (Roles.GetRolesForUser(Page.User.Identity.Name).Length == 0)
                {
                    MembershipUser user = Membership.GetUser(Page.User.Identity.Name);
                    Roles.AddUserToRole(user.UserName, "User");
                    Membership.UpdateUser(user);
                    Response.Redirect("/User/Firefighter/Firefighter_Adjust.aspx");
                }
            }
        }
    }
}