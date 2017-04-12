using System;
using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Products
{
    public class LoadProductsOperation : BaseOperation
    {
        private Int32 _categoryid { get; set; }
        private Int32 _page { get; set; }
        private Int32 _count { get; set; }
        public List<Product> _products { get; set; }

        public LoadProductsOperation(int page, int count, int id)
        {
            _page = page;
            _count = count;
            _categoryid = id;
            RussianName = "Получение списка продуктов категории";
        }

        protected override void InTransaction()
        {
            if(_categoryid == -1)
            {
                _products = Context.Products.Where(x => x.IsHot && !x.Deleted).OrderBy(x => x.Id).Skip((_page - 1) * _count).Take(_count).ToList();
            }
            else
            {
                var category = Context.Categories.FirstOrDefault(x => x.Id == _categoryid && !x.Deleted);
                if (category == null)
                {
                    Errors.Add("Id", "Такой категории не существует");
                }
                else
                {
                    _products = Context.Products.Where(x => x.CategoryId == _categoryid && !x.Deleted).OrderBy(x => x.Id).Skip((_page - 1) * _count).Take(_count).ToList();
                }
            }            
        }
    }
}