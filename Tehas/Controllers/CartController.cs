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
            var game = SessionHelpers.Session("Game") as List<GameModel>;
            ViewBag.NoProducts = true;
            ViewBag.NoGames = true;
            if (cart != null || game != null)
            {
                var operation = new LoadCartOperation(cart, game);
                operation.ExcecuteTransaction();
                if (operation._products != null && operation._products.Count > 0)
                    ViewBag.NoProducts = false;
                ViewBag.Products = operation._products;
                if (operation._games != null && operation._games.Count > 0)
                    ViewBag.NoGames = false;
                ViewBag.Games = operation._games;
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult ChangeQuantity(CartModel model)
        {
            if (model.Quantity < 0)
                return Json(new { NoError = false });
            var cart = SessionHelpers.Session("Cart") as List<CartModel> ?? new List<CartModel>();
            var game = SessionHelpers.Session("Game") as List<GameModel> ?? new List<GameModel>();
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

            var operation = new LoadCartOperation(cart, game);
            operation.ExcecuteTransaction();
            if (operation._products != null && operation._products.Count > 0)
                ViewBag.NoProducts = false;
            if (operation._games != null && operation._games.Count > 0)
                ViewBag.NoGames = false;

            return PartialView("Partial/_cartList", new FullCartModel { Products = operation._products, Games = operation._games });
        }
        [HttpPost]
        public JsonResult AddGame(GameModel model)
        {
            if (model.Quantity <= 0 || model.Date < DateTime.Now.Date)
                return Json(new { NoError = false });
            var game = SessionHelpers.Session("Game") as List<GameModel> ?? new List<GameModel>();
            var adv = game.Find(x => x.Id == model.Id && x.Date == model.Date);
            if (adv == null)
            {
                game.Add(model);
            }
            else if (adv != null)
            {
                adv.Quantity += model.Quantity;
            }
            SessionHelpers.Session("Game", game);
            return Json(new { NoError = true });
        }

        [HttpPost]
        public ActionResult ChangeGameQuantity(GameModel model)
        {
            if (model.Quantity < 0 || model.Date < DateTime.Now.Date)
                return Json(new { NoError = false });
            var cart = SessionHelpers.Session("Cart") as List<CartModel> ?? new List<CartModel>();
            var game = SessionHelpers.Session("Game") as List<GameModel> ?? new List<GameModel>();
            var prod = game.Find(x => x.Id == model.Id && x.Date == model.Date);
            if (prod == null && model.Quantity > 0)
            {
                game.Add(model);
            }
            else if (prod != null && model.Quantity > 0)
            {
                prod.Quantity = model.Quantity;
            }
            else if (prod != null && model.Quantity == 0)
            {
                game.Remove(prod);
            }
            SessionHelpers.Session("Game", game);
            var operation = new LoadCartOperation(cart, game);
            operation.ExcecuteTransaction();
            if (operation._products != null && operation._products.Count > 0)
                ViewBag.NoProducts = false;
            if (operation._games != null && operation._games.Count > 0)
                ViewBag.NoGames = false;

            return PartialView("Partial/_cartList", new FullCartModel { Products = operation._products, Games = operation._games });
        }
    }
}