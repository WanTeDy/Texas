using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Frontend.Areas.Cabinet.Models;
using Tehas.Frontend.Helpers;
using Tehas.Utils.BusinessOperations.Images;

namespace Tehas.Frontend.Areas.Cabinet.Controllers
{
    public class ImageController : Controller
    {
        [HttpPost]
        public ActionResult Delete(ImageDeleteModel image)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            if (image.Id < 1)
                return HttpNotFound();
            var operation = new DeleteImageOperation(image.Id);
            operation.ExcecuteTransaction();
            return Json(new { IsSuccess = operation.Success });
        }
    }
}