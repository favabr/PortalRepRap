using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PortalRepRap.Framework.UnitOfWork;

namespace PortalRepRap.Web
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var culture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ClientDataTypeModelValidatorProvider.ResourceClassKey = "MvcResources";
            DefaultModelBinder.ResourceClassKey = "MvcResources";

            //ModelMetadataProviders.Current = new MetadataProvider();
        }

        protected virtual void Application_BeginRequest()
        {
            if (Context.Request.RawUrl.StartsWith("/Images/"))
                return;
            UnitOfWork.Start();
        }

        protected virtual void Application_EndRequest()
        {
            if (UnitOfWork.IsStarted)
            {
                if (UnitOfWork.Current.HasPendingChanges)
                    UnitOfWork.Current.TransactionalFlush();
                UnitOfWork.Current.Dispose();
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (UnitOfWork.Current != null)
                UnitOfWork.Current.Dispose();
        }
    }
}