using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Frontend.Helpers;
using Tehas.Utils.BusinessOperations.PagesDesc;
using Tehas.Utils.DataBase;
using Tehas.Utils.DataBase.PagesDesc;

namespace Tehas.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var op = new LoadPagesDescOperation("home", "index");
            op.ExcecuteTransaction();
            
            return View(op._pageDescription);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(PageDescription model, HttpPostedFileBase[] images)
        {
            AddPagesDescOperation op = new AddPagesDescOperation(model.ControllerName, model.ActionName, model.Description, model.Title, model.VideoURL, images);
            op.ExcecuteTransaction();
            if (!op.Success)
                ErrorHelpers.AddModelErrors(ModelState, op.Errors);
            return View(model);
        }
    }
}