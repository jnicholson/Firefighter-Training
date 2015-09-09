using System;
using System.Data.Entity;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebApplication1.HalonModels;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Add Administrator. // Added by Hung
            /*if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }
            if (!Roles.RoleExists("Chief"))
            {
                Roles.CreateRole("Chief");
            }
            if (!Roles.RoleExists("TrainingOfficer"))
            {
                Roles.CreateRole("TrainingOfficer");
            }
            if (!Roles.RoleExists("Instructor"))
            {
                Roles.CreateRole("Instructor");
            }
            if (!Roles.RoleExists("User"))
            {
                Roles.CreateRole("User");
            }
            if (Membership.GetUser("Admin") == null)
            {
                Membership.CreateUser("Admin", "Pa$$word", "Admin@Halon.com");
                Roles.AddUserToRole("Admin", "Administrator");
            }
            createAccounts();*/
            // Initialize the product database
            Database.SetInitializer(new HalonDatabaseInitializer());
            // Added by Hung
        }

        private void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        private void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        private static void createRoles()
        {
        }

        private static void createAccounts()
        {
            if (Membership.GetUser("User") == null)
            {
                Membership.CreateUser("User", "Pa$$word", "User@Halon.com");
                Roles.AddUserToRole("User", "User");
            }
            if (Membership.GetUser("Instructor") == null)
            {
                Membership.CreateUser("Instructor", "Pa$$word", "Instructor@Halon.com");
                Roles.AddUserToRole("Instructor", "Instructor");
            }
            if (Membership.GetUser("TrainingOfficer") == null)
            {
                Membership.CreateUser("TrainingOfficer", "Pa$$word", "TrainingOfficer@Halon.com");
                Roles.AddUserToRole("TrainingOfficer", "TrainingOfficer");
            }
            if (Membership.GetUser("Chief") == null)
            {
                Membership.CreateUser("Chief", "Pa$$word", "Chief@Halon.com");
                Roles.AddUserToRole("Chief", "Chief");
            }
        }
    }
}