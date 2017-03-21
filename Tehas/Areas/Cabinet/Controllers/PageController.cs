using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Frontend.Helpers;

namespace Tehas.Frontend.Areas.Cabinet.Controllers
{
    public class PageController : Controller
    {
        // GET: Cabinet/Page/List
        public ActionResult List()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            return View();
        }
    }
}