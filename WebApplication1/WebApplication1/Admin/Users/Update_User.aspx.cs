using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin.Users
{
    public partial class Update_User : System.Web.UI.Page
    {
        private MembershipUser user;
        private String username;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];

            if (username != null)
            {
                user = Membership.GetUser(username);
            }
            else
                Response.Redirect("/Admin/Users/Display_Users.aspx");

            if (!IsPostBack)
            {
                GetFirefighters();
            }
        }

        public void GetRoles()
        {
            LabelUsername.Text = user.UserName;

            UpdateUserEmail.Text = user.Email;

            try
            {
                DropDownUpdateRole.SelectedValue = Roles.GetRolesForUser(user.UserName)[0];
            }
            catch (Exception exc)
            {
                DropDownUpdateRole.SelectedIndex = 0;
            }

            DropDownUpdateRole.Items.Add(new ListItem(Roles.GetAllRoles()[0], Roles.GetAllRoles()[0]));
            DropDownUpdateRole.Items.Add(new ListItem(Roles.GetAllRoles()[1], Roles.GetAllRoles()[1]));
            DropDownUpdateRole.Items.Add(new ListItem(Roles.GetAllRoles()[3], Roles.GetAllRoles()[3]));
            DropDownUpdateRole.Items.Add(new ListItem(Roles.GetAllRoles()[2], Roles.GetAllRoles()[2]));
            DropDownUpdateRole.Items.Add(new ListItem(Roles.GetAllRoles()[4], Roles.GetAllRoles()[4]));
        }

        public void GetFirefighters()
        {
            var db = new WebApplication1.HalonModels.HalonContext();
            IQueryable<HalonModels.Firefighter> query = db.Firefighters;
            query = query.Where(f => f.Firefighter_Account_Username.Equals(username) || f.Firefighter_Account_Username == null);
            List<HalonModels.Firefighter> list = query.ToList();
            DropDownUpdateFireFighter.DataSource = list;
            DropDownUpdateFireFighter.DataValueField = "Firefighter_ID";

            DropDownUpdateFireFighter.DataBind();

            for (int i = 0; i < list.Count; i++)
            {
                DropDownUpdateFireFighter.Items[i].Text = list[i].Firefighter_Fname + " " + list[i].Firefighter_Lname;
            }

            DropDownUpdateFireFighter.Items.Add(new ListItem("none"));

            query = query.Where(f => f.Firefighter_Account_Username.Equals(username));

            try
            {
                int firefighterID = query.FirstOrDefault().Firefighter_ID;
                DropDownUpdateFireFighter.SelectedValue = firefighterID.ToString();
            }
            catch (Exception exc)
            {
                DropDownUpdateFireFighter.SelectedValue = "none";
            }
        }

        //called when update button clicked
        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {
            bool updateSuccess;

            try
            {
                user.Email = UpdateUserEmail.Text.Trim();
                Membership.UpdateUser(user);

                if (Roles.GetRolesForUser(user.UserName).Length > 0)
                    Roles.RemoveUserFromRoles(user.UserName, Roles.GetRolesForUser(user.UserName));

                Roles.AddUserToRole(user.UserName, DropDownUpdateRole.SelectedValue);
                Membership.UpdateUser(user);

                if (DropDownUpdateFireFighter.SelectedValue != "none")
                {
                    var db = new WebApplication1.HalonModels.HalonContext();
                    IQueryable<HalonModels.Firefighter> query = db.Firefighters;

                    int selectedID = Convert.ToInt32(DropDownUpdateFireFighter.SelectedValue);
                    query = query.Where(f => f.Firefighter_ID == selectedID);

                    query.FirstOrDefault().Firefighter_Account_Username = username;
                    db.SaveChanges();
                }
                else
                {
                    var db = new WebApplication1.HalonModels.HalonContext();
                    IQueryable<HalonModels.Firefighter> query = db.Firefighters;

                    query = query.Where(f => f.Firefighter_Account_Username == username);

                    query.FirstOrDefault().Firefighter_Account_Username = null;
                    db.SaveChanges();
                }

                updateSuccess = true;
            }
            catch (Exception exc)
            {
                updateSuccess = false;
                LabelUpdateStatus.Text = exc.ToString();
            }

            //reload with status
            if (updateSuccess)
            {
                Response.Redirect("/Admin/Users/Display_Users.aspx");
            }
            else
            {
                //LabelUpdateStatus.Text = "Unable to update user.";
            }
        }
    }
}