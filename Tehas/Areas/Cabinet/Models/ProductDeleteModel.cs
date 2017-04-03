using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Frontend.Areas.Cabinet.Models
{
    public class ProductDeleteModel
    {
        public int[] ProductsId { get; set; }
        public int CategoryId { get; set; }
    }
}