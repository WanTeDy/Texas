using System;
using System.ComponentModel.DataAnnotations;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.Helpers
{
    public class CartModel
    {        
        public int Id { get; set; }        
        public int Quantity { get; set; }
    }
}