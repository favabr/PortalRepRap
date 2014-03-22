using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PortalRepRap.Core.DAL;

namespace PortalRepRap
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
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
