using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Frontend.Helpers;
using Tehas.Utils.BusinessOperations.PagesDesc;
using Tehas.Utils.DataBase.PagesDesc;

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

        // GET: Cabinet/Page/List
        public ActionResult Detail(int id)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            if (id < 1)
                return HttpNotFound();
            var operation = new LoadPagesDescOperation(id);
            operation.ExcecuteTransaction();
            if(operation._pageDescription == null)
                return HttpNotFound();

            return View(operation._pageDescription);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(PageDescription model, HttpPostedFileBase[] images)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            UpdatePagesDescOperation op = new UpdatePagesDescOperation(model.Id, model.Description, model.Title, model.VideoURL, images);
            op.ExcecuteTransaction();
            if (op._pageDescription == null)
                return HttpNotFound();

            return PartialView("Partial/_pagePartial", model);
        }
    }
}