using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Tehas.Utils;
using Tehas.Utils.BusinessOperations.Comments;
using Tehas.Utils.DataBase;
using Tehas.Utils.DataBase.Emails;

namespace Tehas.Frontend.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult Index()
        {            
            var op = new LoadCommentsOperation(1, ConstV.ItemsPerPage);
            op.ExcecuteTransaction();
            ViewBag.Comments = op._comments;
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(Comment model)
        {
            var op = new AddCommentOperation(model.Username, model.Message);
            op.ExcecuteTransaction();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Load(int page)
        {
            if (page < 1)
                return Json(new { noElements = true });
            var operation = new LoadCommentsOperation(page, ConstV.ItemsPerPage);
            operation.ExcecuteTransaction();
            if (operation._comments == null || operation._comments.Count == 0)
                return Json(new { noElements = true });
            return PartialView("Comments/_listOfComments", operation._comments);
        }
    }
}