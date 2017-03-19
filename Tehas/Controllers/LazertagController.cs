using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Utils.BusinessOperations.PagesDesc;

namespace Tehas.Frontend.Controllers
{
    public class LazertagController : Controller
    {
        // GET: Lazertag
        public ActionResult Index()
        {
            var op = new LoadPagesDescOperation("lazertag", "index");
            op.ExcecuteTransaction();
            return View(op._pageDescription);
        }
    }
}