using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.Helpers;

namespace Tehas.Utils.BusinessOperations.Cart
{
    public class LoadCartOperation : BaseOperation
    {
        private List<CartModel> _cartModel { get; set; }
        private List<GameModel> _gameModel { get; set; }
        public List<CartProductsModel> _products { get; set; }
        public List<CartGamesModel> _games { get; set; }

        public LoadCartOperation(List<CartModel> cartModel, List<GameModel> gameModel)
        {
            _cartModel = cartModel;
            _gameModel = gameModel;
            RussianName = "Получение списка продуктов корзины";
        }

        protected override void InTransaction()
        {
            if (_cartModel != null)
            {
                _products = new List<CartProductsModel>();
                foreach (var item in _cartModel)
                {
                    var el = Context.Products.FirstOrDefault(x => !x.Deleted && x.Id == item.Id);
                    if (el != null)
                    {
                        var prod = new CartProductsModel()
                        {
                            Product = el,
                            Quantity = item.Quantity,
                        };
                        _products.Add(prod);
                    }
                }
            }
            if (_gameModel != null)
            {
                _games = new List<CartGamesModel>();
                foreach (var item in _gameModel)
                {
                    var el = Context.Games.FirstOrDefault(x => !x.Deleted && x.ParrentId == item.Id && x.DayOfWeek == item.Date.DayOfWeek);
                    if (el != null)
                    {
                        var prod = new CartGamesModel()
                        {
                            Game = el,
                            Quantity = item.Quantity,
                            Date = item.Date,
                        };
                        _games.Add(prod);
                    }
                }
            }
        }
    }
}