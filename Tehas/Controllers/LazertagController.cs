using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Utils.BusinessOperations.PagesDesc;
using Tehas.Utils.DataBase.PagesDesc;

namespace Tehas.Frontend.Controllers
{
    public class LazertagController : Controller
    {
        // GET: Lazertag
        public ActionResult Index()
        {
            var op = new LoadPagesDescOperation("lazertag", "index");
            op.ExcecuteTransaction();
            var op2 = new LoadPagesDescOperation("shtab", "index");
            op2.ExcecuteTransaction();
            return View(new PageDescription[] { op._pageDescription, op2._pageDescription });
        }
    }
}