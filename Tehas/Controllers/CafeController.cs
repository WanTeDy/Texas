using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Utils.BusinessOperations.PagesDesc;

namespace Tehas.Frontend.Controllers
{
    public class CafeController : Controller
    {
        // GET: Cafe
        public ActionResult Index()
        {
            var op = new LoadPagesDescOperation("cafe", "index");
            op.ExcecuteTransaction();
            return View(op._pageDescription);
        }
    }
}