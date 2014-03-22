using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PortalRepRap.Core.DAL;

namespace PortalRepRap
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected virtual void Application_BeginRequest()
        {
            HttpContext.Current.Items["_EntityContext"] = new EntityContext();
        }

        protected virtual void Application_EndRequest()
        {
            var entityContext = HttpContext.Current.Items["_EntityContext"] as EntityContext;
            if (entityContext != null)
                entityContext.Dispose();
        }
    }
}
