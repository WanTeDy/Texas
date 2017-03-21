using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Frontend.Helpers;

namespace Tehas.Frontend.Areas.Cabinet.Controllers
{
    public class MainController : Controller
    {
        // GET: Cabinet/Main
        public ActionResult Index()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            return View();
        }
    }
}