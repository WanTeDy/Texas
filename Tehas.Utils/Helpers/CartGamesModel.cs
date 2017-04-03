using System;
using System.ComponentModel.DataAnnotations;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.Helpers
{
    public class CartGamesModel
    {        
        public Game Game { get; set; }        
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}