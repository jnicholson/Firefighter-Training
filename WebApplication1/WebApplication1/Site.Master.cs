using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }
            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("Administrator"))
            {
                adminFFLinks.Visible = true;
                adminClassLinks.Visible = true;
                adminDeptLinks.Visible = true;
                adminCourseLinks.Visible = true;

                userFFLinks.Visible = true;
                userClassLinks.Visible = true;
                userDeptLinks.Visible = true;
            }

            if (HttpContext.Current.User.IsInRole("Chief"))
            {
                chiefFFLinks.Visible = true;
                chiefDeptLinks.Visible = true;
                chiefClassLinks.Visible = true;

                userFFLinks.Visible = true;
                userClassLinks.Visible = true;
                userDeptLinks.Visible = true;
            }
            if (HttpContext.Current.User.IsInRole("TrainingOfficer"))
            {
                trainingOfficerClassLinks.Visible = true;
                trainingOfficerFFLinks.Visible = true;
                userFFLinks.Visible = true;
                userClassLinks.Visible = true;
                userDeptLinks.Visible = true;
            }
            if (HttpContext.Current.User.IsInRole("Instructor"))
            {
                instructorClassLinks.Visible = true;

                userFFLinks.Visible = true;
                userClassLinks.Visible = true;
                userDeptLinks.Visible = true;
            }
            if (HttpContext.Current.User.IsInRole("User"))
            {
                userFFLinks.Visible = true;
                userClassLinks.Visible = true;
                userDeptLinks.Visible = true;
            }
            Page.ClientScript.RegisterClientScriptInclude("dropdown", ResolveClientUrl("~/Scripts/js/dropdown.js"));
        }
    }
}