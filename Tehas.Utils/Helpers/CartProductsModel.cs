using System;
using System.ComponentModel.DataAnnotations;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.Helpers
{
    public class CartProductsModel
    {        
        public Product Product { get; set; }        
        public int Quantity { get; set; }
    }
}