using LicensesOrganizer.Filters;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace LicensesOrganizer
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new BasicAuthenticationFilter());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}
