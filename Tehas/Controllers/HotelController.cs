using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Utils.BusinessOperations.PagesDesc;

namespace Tehas.Frontend.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            var op = new LoadPagesDescOperation("hotel", "index");
            op.ExcecuteTransaction();
            return View(op._pageDescription);
        }
    }
}