using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.Helpers;

namespace Tehas.Utils.BusinessOperations.Cart
{
    public class LoadCartOperation : BaseOperation
    {
        private List<CartModel> _cartModel { get; set; }
        public List<CartProductsModel> _products { get; set; }

        public LoadCartOperation(List<CartModel> cartModel)
        {
            _cartModel = cartModel;
            RussianName = "Получение списка продуктов корзины";
        }

        protected override void InTransaction()
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
    }
}