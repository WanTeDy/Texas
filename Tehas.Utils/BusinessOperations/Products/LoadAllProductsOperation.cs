using System;
using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Products
{
    public class LoadAllProductsOperation : BaseOperation
    {
        private Int32 _categoryid { get; set; }        
        public List<Product> _products { get; set; }

        public LoadAllProductsOperation(int id)
        {            
            _categoryid = id;
            RussianName = "Получение списка всех продуктов категории";
        }

        protected override void InTransaction()
        {
            var category = Context.Categories.FirstOrDefault(x => x.Id == _categoryid && !x.Deleted);
            if (category != null)
            {            
                _products = Context.Products.Where(x => x.CategoryId == _categoryid && !x.Deleted).OrderBy(x => x.Id).ToList();
            }
            else if(_categoryid == 0)
            {
                _products = Context.Products.Where(x => !x.Deleted).OrderBy(x => x.Id).ToList();
            }
        }
    }
}