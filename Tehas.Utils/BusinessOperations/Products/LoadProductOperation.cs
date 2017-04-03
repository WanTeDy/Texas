using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Products
{
    public class LoadProductOperation : BaseOperation
    {
        private Int32 _Id { get; set; }
        public Product _product { get; set; }

        public LoadProductOperation(int id)
        {            
            _Id = id;
            RussianName = "Получение продукта";
        }

        protected override void InTransaction()
        {
            _product = Context.Products.FirstOrDefault(x => x.Id == _Id && !x.Deleted);
            if (_product == null)
            {
                Errors.Add("Id", "Такого продукта не существует");
            }
        }
    }
}