using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Frontend.Models;
using Tehas.Utils;
using Tehas.Utils.BusinessOperations.PagesDesc;
using Tehas.Utils.BusinessOperations.Products;
using Tehas.Utils.DataBase;
using Newtonsoft.Json;

namespace Tehas.Frontend.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            var op = new LoadPagesDescOperation("menu", "index");
            op.ExcecuteTransaction();
            var op2 = new LoadCategoriesOperation();
            op2.ExcecuteTransaction();
            var op3 = new LoadHotProductsOperation(1, ConstV.ItemsPerPage);
            op3.ExcecuteTransaction();
            var model = new MenuModel
            {
                PageDescription = op._pageDescription,
                Categories = op2._categories,
                Products = op3._products,
            };
            ViewBag.Main = true;
            return View(model);
        }

        public ActionResult Products(int id)
        {
            if (id < 1)
                return HttpNotFound();
            var op = new LoadProductsOperation(1, ConstV.ItemsPerPage, id);
            op.ExcecuteTransaction();
            if (!op.Success)
                return HttpNotFound();

            var op2 = new LoadPagesDescOperation("menu", "index");
            op2.ExcecuteTransaction();
            var op3 = new LoadCategoriesOperation();
            op3.ExcecuteTransaction();
            var model = new MenuModel
            {
                PageDescription = op2._pageDescription,
                Categories = op3._categories,
                Products = op._products,
            };
            ViewBag.Main = false;
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Load(PageModel model)
        {
            if (model.PageNumber < 1)
                return Json(new { noElements = true });
            var operation = new LoadProductsOperation(model.PageNumber, ConstV.ItemsPerPage, model.CategoryId);
            operation.ExcecuteTransaction();
            if (operation._products == null || operation._products.Count == 0)
                return Json(new { noElements = true });
            return PartialView("Menu/_listOfProducts", operation._products);
        }
    }
}