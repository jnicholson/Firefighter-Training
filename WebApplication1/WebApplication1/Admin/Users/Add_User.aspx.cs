using System;
using System.Web.Security;

namespace WebApplication1.Admin.Users
{
    public partial class Add_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //called when add button clicked
        protected void AddUserButton_Click(object sender, EventArgs e)
        {
            //get user credentials
            String username = AddUsername.Text.Trim();
            String password = AddUserPassword.Text;
            String email = AddUserEmail.Text.Trim();

            //validates add
            bool addSuccess;

            //create user
            try
            {
                MembershipUser newUser = Membership.CreateUser(username, password, email);
                Membership.UpdateUser(newUser);
                Roles.AddUserToRole(newUser.UserName, "User");
                Membership.UpdateUser(newUser);

                LabelAddStatus.Text = Roles.GetRolesForUser(username)[0];

                addSuccess = true;
            }
            catch (MembershipCreateUserException)
            {
                addSuccess = false;
            }

            if (addSuccess)
            {
                Response.Redirect("/Admin/Users/Display_Users.aspx");
            }
            else
            {
                LabelAddStatus.Text = "Unable to add new user.";
            }
        }
    }
}