using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Products
{
    public class LoadHotProductsOperation : BaseOperation
    {
        private Int32 _page { get; set; }
        private Int32 _count { get; set; }
        public List<Product> _products { get; set; }

        public LoadHotProductsOperation(int page, int count)
        {
            _page = page;
            _count = count;
            RussianName = "Получение списка горячих продуктов категории";
        }

        protected override void InTransaction()
        {
            _products = Context.Products.Where(x => x.IsHot && !x.Deleted).OrderBy(x => x.Id).Skip((_page - 1) * _count).Take(_count).ToList();
        }
    }
}