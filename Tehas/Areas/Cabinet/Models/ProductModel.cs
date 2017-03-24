using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Frontend.Areas.Cabinet.Models
{
    public class ProductModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}