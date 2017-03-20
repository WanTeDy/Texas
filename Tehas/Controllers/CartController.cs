#define CASH

using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Tehas.Utils.BusinessOperations.Cart;
using Tehas.Frontend.Helpers;
using Tehas.Frontend.Models;
using Tehas.Utils.Helpers;

namespace Tehas.Frontend.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            var cart = SessionHelpers.Session("Cart") as List<CartModel>;
            ViewBag.NoElements = true;
            if (cart != null)
            {
                var operation = new LoadCartOperation(cart);
                operation.ExcecuteTransaction();
                if (operation._products != null && operation._products.Count > 0)
                    ViewBag.NoElements = false;
                ViewBag.Products = operation._products;               
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

        [HttpPost]
        public JsonResult Add(CartModel model)
        {
            if (model.Quantity <= 0)
                return Json(new { NoError = false });
            var cart = SessionHelpers.Session("Cart") as List<CartModel> ?? new List<CartModel>();
            var adv = cart.Find(x => x.Id == model.Id);
            if (adv == null)
            {
                cart.Add(model);
            }
            else if (adv != null)
            {
                adv.Quantity += model.Quantity;
            }
            SessionHelpers.Session("Cart", cart);
            return Json(new { NoError = true });
        }

        [HttpPost]
        public JsonResult ChangeQuantity(CartModel model)
        {
            if (model.Quantity < 0)
                return Json(new { NoError = false });
            var cart = SessionHelpers.Session("Cart") as List<CartModel> ?? new List<CartModel>();
            var prod = cart.Find(x => x.Id == model.Id);
            if (prod == null && model.Quantity > 0)
            {
                cart.Add(model);
            }
            else if (prod != null && model.Quantity > 0)
            {
                prod.Quantity = model.Quantity;
            }
            else if (prod != null && model.Quantity == 0)
            {
                cart.Remove(prod);
            }
            SessionHelpers.Session("Cart", cart);
            return Json(new { NoError = true });
        }
    }
}