using System;
using System.ComponentModel.DataAnnotations;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Frontend.Models
{
    public class CartModel
    {        
        public Product Product { get; set; }        
        public double Quantity { get; set; }
    }
}