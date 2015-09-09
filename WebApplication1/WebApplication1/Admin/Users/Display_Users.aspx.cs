using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebApplication1.HalonModels;

namespace WebApplication1.Admin.Users
{
    public partial class Display_Users : System.Web.UI.Page
    {
        private readonly HalonContext _db = new HalonContext();

        public MembershipUserCollection GetUsers()
        {
            //gets list of all users and return
            MembershipUserCollection users = Membership.GetAllUsers();

            return users;
        }

        //called when add button clicked
        protected void AddUserButton_Click(object sender, EventArgs e)
        {
            //load add user page
            Response.Redirect("/Admin/Users/Add_User.aspx");
        }

        //called when edit button clicked
        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UserGrid.Rows.Count; i++)
            {
                String username = UserGrid.Rows[i].Cells[1].Text;
                CheckBox checkbox = (CheckBox)UserGrid.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    string pageUrl = "/Admin/Users/Update_User.aspx";
                    Response.Redirect(pageUrl + "?username=" + username);
                }
            }
        }

        //called when del button clicked
        protected void DeleteUserButton_Click(object sender, EventArgs e)
        {
            bool addSuccess;

            for (int i = 0; i < UserGrid.Rows.Count; i++)
            {
                String username = UserGrid.Rows[i].Cells[1].Text;
                CheckBox checkbox = (CheckBox)UserGrid.Rows[i].FindControl("editDeleteBox");
                if (checkbox.Checked)
                {
                    try
                    {
                        Membership.DeleteUser(username);
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
                        LabelAddStatus.Text = "Unable to delete user.";
                    }
                }
            }

            Response.Redirect("/Admin/Users/Display_Users.aspx");
        }

        protected void Classes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                MembershipUser user = e.Row.DataItem as MembershipUser;

                IQueryable<WebApplication1.HalonModels.Firefighter> ffquery = _db.Firefighters;
                string firefighter_UName = user.UserName;
                ffquery = ffquery.Where(f => f.Firefighter_Account_Username.Equals(firefighter_UName));

                try
                {
                    e.Row.Cells[2].Text = Roles.GetRolesForUser(user.UserName)[0];
                    e.Row.Cells[0].Text = ffquery.FirstOrDefault().Firefighter_Fname + " " + ffquery.FirstOrDefault().Firefighter_Lname;
                }
                catch (Exception exc)
                {
                }
            }
        }
    }
}