using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tehas.Utils.DataBase.Products;
using Tehas.Utils.Helpers;

namespace Tehas.Frontend.Models
{
    public class FullCartModel
    {       
        public List<CartProductsModel> Products { get; set; }
        public List<CartGamesModel> Games { get; set; }
    }
}