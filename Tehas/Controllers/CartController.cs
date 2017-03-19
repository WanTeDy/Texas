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
using Tehas.Utils.DataBase.Products;

namespace Tehas.Frontend.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            //var cart = SessionHelpers.Session("Cart") as List<Product>;
            //ViewBag.NoElements = true;
            //if (cart != null)
            //{
            //    var operation = new LoadCartOperation(cart);
            //    operation.ExcecuteTransaction();
            //    if (operation._adverts != null && operation._adverts.Count > 0)
            //        ViewBag.NoElements = false;
            //    var model = new LoadCartModel()
            //    {
            //        Adverts = operation._adverts,
            //    };
            //    return View(model);
            //}
            return View();
        }

        [HttpPost]
        public JsonResult Add(CartModel model)
        {
            if(model.Quantity <= 0)
                return Json(new { NoError = false });
            var cart = SessionHelpers.Session("Cart") as List<CartModel> ?? new List<CartModel>();
            var adv = cart.Find(x => x.Product.Id == model.Product.Id);
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
            var prod = cart.Find(x => x.Product.Id == model.Product.Id);
            if (prod == null && model.Quantity > 0)
            {
                cart.Add(model);
            }
            else if (prod != null && model.Quantity > 0)
            {
                prod.Quantity = model.Quantity;
            }
            else if(prod != null && model.Quantity == 0)
            {
                cart.Remove(prod);
            }
            SessionHelpers.Session("Cart", cart);
            return Json(new { NoError = true });
        }
    }
}






/*
 var context = new DbReHouse();
            List<String> list = new List<String> { "Авангард",
"Александровка",
"Ананьев",
"Арциз",
"Балта",
"Белгород-Днестровский",
"Белино",
"Беляевка",
"Березино",
"Березовка",
"Болград",
"Борщи",
"Бритовка",
"Бурлача балка",
"Великая Михайловка",
"Великодолинское",
"Визирка",
"Вилково",
"Выгода",
"Григоровка",
"Дзинилор",
"Еремеевка",
"Жеребково",
"Загнитков",
"Затишье",
"Затока",
"Ивановка",
"Измаил",
"Ильичевка",
"Исаево",
"Каролино-бугаз",
"Килия",
"Кирнички",
"Кодыма",
"Коминтерновское",
"Котовка",
"Котовск",
"Красноселка",
"Красные Окны",
"Кремидовка",
"Криничное",
"Крыжановка",
"Ланна",
"Ларжанка",
"Лиманское",
"Любашевка",
"Малодолинское",
"Маяки",
"Мизикевича",
"Молодежное",
"Нерубайское",
"Николаевка",
"Новая долина",
"Новая дофиновка",
"Новая некрасовка",
"Новоборисовка",
"Новые беляры",
"Овидиополь",
"Одесса",
"Ониськово",
"Петровка",
"Петродолинское",
"Платоново",
"Прилиманское",
"Радостное",
"Раздельная",
"Рени",
"Саврань",
"Салганы",
"Сарата",
"Сафьяны",
"Сергеевка",
"Словяносербка",
"Старая некрасовка",
"Суворово",
"Сычавка",
"Табаки",
"Таирово",
"Тарутино",
"Татарбунары",
"Теплодар",
"Усатово",
"Фонтанка",
"Фрунзовка",
"Хлебодарское",
"Холодная балка",
"Червоноармейское",
"Черноморск",
"Черноморское",
"Шабо",
"Шевченково",
"Ширяево",
"Южный"
            };
            foreach(var el in list)
            {
                context.Cities.Add(new Utils.DataBase.Geo.City
                {
                    RussianName = el,
                });
            }
            context.SaveChanges();
     */
