using Microsoft.AspNet.FriendlyUrls;
using System.Web.Routing;

namespace WebApplication1
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();
        }
    }
}