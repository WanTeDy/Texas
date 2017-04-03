using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tehas.Utils.DataBase.PagesDesc;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.Helpers
{
    public class GameModel
    {        
        public int Id { get; set; }        
        public int Quantity { get; set; }        
        public DateTime Date { get; set; }
    }
}