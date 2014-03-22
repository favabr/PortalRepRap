using System.Web.Mvc;
using PortalRepRap.Web.Models;

namespace PortalRepRap.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new HeaderModel();
            model.Populate();
            return View(model);
        }

        public ActionResult Header(HeaderModel model)
        {
            return View("_Header", model);
        }
    }
}
