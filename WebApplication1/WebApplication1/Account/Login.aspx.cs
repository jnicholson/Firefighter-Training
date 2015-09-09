using System;
using System.Web;
using System.Web.UI;

namespace WebApplication1.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void OnLoggedIn(EventArgs e) // Added by Hung, redirect to Default after a successful log-in
        {
            //Response.Redirect("~/Default.aspx");
        }
    }
}