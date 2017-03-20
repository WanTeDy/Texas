using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Products
{
    public class LoadCategoriesOperation : BaseOperation
    {        
        public List<Category> _categories { get; set; }

        public LoadCategoriesOperation()
        {            
            RussianName = "Получение списка категорий";
        }

        protected override void InTransaction()
        {
            _categories = Context.Categories.Where(x => !x.Deleted).ToList();
        }
    }
}