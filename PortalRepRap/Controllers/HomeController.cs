using NHibernate;
using NHibernate.Context;
using PortalRepRap.Database.Repository;
using PortalRepRap.Domain;
using PortalRepRap.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalRepRap.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
