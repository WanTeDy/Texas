﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tehas.Frontend.Areas.Cabinet.Models;
using Tehas.Frontend.Helpers;
using Tehas.Utils.BusinessOperations.PagesDesc;
using Tehas.Utils.BusinessOperations.Products;
using Tehas.Utils.DataBase.PagesDesc;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Frontend.Areas.Cabinet.Controllers
{
    public class MenuController : Controller
    {
        // GET: Cabinet/Menu/List
        public ActionResult List()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            var operation = new LoadCategoriesOperation();
            operation.ExcecuteTransaction();
            var operation2 = new LoadAllProductsOperation(0);
            operation2.ExcecuteTransaction();
            return View(new MenuListModel { Categories = operation._categories, Products = operation2._products});
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult List(CategoryModel model)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            
            var operation = new LoadAllProductsOperation(model.Id);
            operation.ExcecuteTransaction();
            return PartialView("Partial/_listOfProductsPartial", operation._products);
        }

        // GET: Cabinet/menu/List
        public ActionResult Detail(int id)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            if (id < 1)
                return HttpNotFound();
            var operation = new LoadCategoriesOperation();
            operation.ExcecuteTransaction();

            var operation2 = new LoadProductOperation(id);
            operation2.ExcecuteTransaction();
            if(operation2._product == null)
                return HttpNotFound();

            ViewBag.IsSave = false;
            return View(new ProductModel { Categories = operation._categories, Product = operation2._product });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(Product model, HttpPostedFileBase image)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            UpdateProductOperation op = new UpdateProductOperation(model.Id, model.CategoryId, model.Description, model.Title, model.Price, model.IsHot, image);
            op.ExcecuteTransaction();
            if (op._product == null)
                return HttpNotFound();
            var operation = new LoadCategoriesOperation();
            operation.ExcecuteTransaction();
            ViewBag.IsSave = true;

            return View(new ProductModel { Categories = operation._categories, Product = op._product });
        }

        [HttpPost]
        public ActionResult Delete(ProductDeleteModel model)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");
            DeleteProductsOperation op = new DeleteProductsOperation(model.ProductsId);
            op.ExcecuteTransaction();
            
            var operation = new LoadAllProductsOperation(model.CategoryId);
            operation.ExcecuteTransaction();

            return PartialView("Partial/_listOfProductsPartial", operation._products);
        }

        public ActionResult Add()
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            ViewBag.IsSave = false;
            var operation = new LoadCategoriesOperation();
            operation.ExcecuteTransaction();
            return View(operation._categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, HttpPostedFileBase image)
        {
            if (!SessionHelpers.IsAuthentificated())
                return RedirectToAction("Login", "Authorize");

            AddProductOperation op = new AddProductOperation(model.CategoryId, model.Description, model.Title, model.Price, model.IsHot, image);
            op.ExcecuteTransaction();
            
            var operation = new LoadCategoriesOperation();
            operation.ExcecuteTransaction();

            ViewBag.IsSave = true;
            return View(operation._categories);
        }
    }
}