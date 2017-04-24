using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.BusinessOperations.Cart;
using Tehas.Utils.DataBase.Emails;
using Tehas.Utils.DataBase.Orders;
using Tehas.Utils.Helpers;
using Tehas.Utils.Models;

namespace Tehas.Utils.BusinessOperations.Orders
{
    public class CreateOrderOperation : BaseOperation
    {
        private List<CartModel> _cartModel { get; set; }
        private List<GameModel> _gameModel { get; set; }
        private string _name { get; set; }
        private string _phone { get; set; }
        private string _message { get; set; }
        private string _type { get; set; }

        public CreateOrderOperation(List<CartModel> cartModel, List<GameModel> gameModel, string name, string phone, string message, string type)
        {
            _cartModel = cartModel;
            _gameModel = gameModel;
            _name = name;
            _phone = phone;
            _message = message;
            _type = type;
            RussianName = "Создание заказа";
        }

        protected override void InTransaction()
        {
            if (_cartModel == null && _gameModel == null)
            {
                Errors.Add("Name", "Корзина пуста");
            }
            else
            {
                UserEmailMessage mail = new UserEmailMessage
                {
                    Date = DateTime.Now,
                    Phone = _phone,
                    Message = _message,
                    Username = _name,
                    Type = _type
                };
                Context.Emails.Add(mail);
                Order order = new Order
                {
                    Date = DateTime.Now,
                    UserEmailMessage = mail,
                    OrderGames = new List<OrderGames>(),
                    OrderProducts = new List<OrderProducts>(),
                };
                if (_cartModel != null)
                {
                    foreach (var item in _cartModel)
                    {
                        var el = Context.Products.FirstOrDefault(x => !x.Deleted && x.Id == item.Id);
                        if (el != null)
                        {
                            var prod = new OrderProducts()
                            {
                                Product = el,
                                Quantity = item.Quantity,
                                Order = order,
                            };
                            Context.OrderProducts.Add(prod);
                        }
                    }
                }
                if (_gameModel != null)
                {
                    foreach (var item in _gameModel)
                    {
                        var el = Context.Games.FirstOrDefault(x => !x.Deleted && x.ParrentId == item.Id && x.DayOfWeek == item.Date.DayOfWeek);
                        if (el != null)
                        {
                            var prod = new OrderGames()
                            {
                                Game = el,
                                Quantity = item.Quantity,
                                Date = item.Date,
                            };
                            Context.OrderGames.Add(prod);
                        }
                    }
                }
                Context.Orders.Add(order);
                Context.SaveChanges();

                Send();
            }
        }

        private void Send()
        {
            SmtpEmailSender mailSender = new SmtpEmailSender("mail.texac.od.ua", "admin@texac.od.ua", "tehas21032017!");//Properties.Settings.Default.SmtpServer, Properties.Settings.Default.EmailFrom, Properties.Settings.Default.EmailPassword);
            var op = new LoadCartOperation(_cartModel, _gameModel);
            op.ExcecuteTransaction();
            FullCartModel model = new FullCartModel
            {
                Games = op._games,
                Products = op._products,
                Email = new UserEmailMessage
                {
                    Date = DateTime.Now,
                    Message = _message,
                    Phone = _phone,
                    Username = _name,
                    Type = _type,
                },
            };

            var body = SmtpEmailSender.GetHtmlRazor(model, SmtpEmailSender.FormatUrl("OrderMailView"));


            mailSender.Send("pronina-a@mail.ru", "Новый заказ", body);
        }
    }
}