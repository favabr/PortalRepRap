using NHibernate;
using NHibernate.Context;
using PortalRepRap.Database.Repository;
using PortalRepRap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalRepRap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var clientes = _Repository.GetAllProducts();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
