using System.Web.Mvc;
using NLog;
using PortalRepRap.Framework.NLog;

namespace PortalRepRap.Web.Controllers
{
    [HandleError]
    public partial class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Log.Logger.Error(filterContext.Exception);
        }
    }
}