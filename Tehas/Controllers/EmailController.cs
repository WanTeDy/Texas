using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Tehas.Frontend.Models;
using Tehas.Frontend.Helpers;
using Tehas.Utils.BusinessOperations.Orders;
using Tehas.Utils.Helpers;

namespace Tehas.Frontend.Controllers
{
    public class EmailController : Controller
    {
        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult Send(EmailModel mail)
        {
            var cart = SessionHelpers.Session("Cart") as List<CartModel>;
            var game = SessionHelpers.Session("Game") as List<GameModel>;
            var operation = new CreateOrderOperation(cart, game, mail.Name, mail.Phone, mail.Message, mail.Type);
            operation.ExcecuteTransaction();
            SessionHelpers.Session("Cart", null);
            SessionHelpers.Session("Game", null);

            return Json("Отправлено");
        }
    }
}