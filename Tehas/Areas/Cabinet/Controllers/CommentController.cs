using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Frontend.Areas.Cabinet.Models;
using Tehas.Frontend.Helpers;
using Tehas.Utils.BusinessOperations.PagesDesc;
using Tehas.Utils.BusinessOperations.Products;
using Tehas.Utils.BusinessOperations.Comments;
using Tehas.Utils.DataBase.Products;
using Tehas.Utils;

namespace Tehas.Frontend.Areas.Cabinet.Controllers
{
    public class CommentController : Controller
    {
        // GET: Cabinet/Menu/List
        public ActionResult List()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            var operation = new LoadCommentsOperation(1, ConstV.ItemsPerPageAdmin, true);
            operation.ExcecuteTransaction();
            ViewBag.Comments = operation._comments;
            return View();
        }
       
        [HttpPost]
        public ActionResult Delete(ProductDeleteModel model)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            var op = new DeleteCommentsOperation(model.ProductsId);
            op.ExcecuteTransaction();

            var operation = new LoadCommentsOperation(1, ConstV.ItemsPerPageAdmin, true);
            operation.ExcecuteTransaction();

            return PartialView("Partial/_listOfCommentsPartial", operation._comments);
        }                

        [HttpPost]
        public ActionResult ChangeState(int Id, bool IsModerated)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            var op = new EditCommentsOperation(Id, IsModerated);
            op.ExcecuteTransaction();

            return Json("success");
        }
    }
}