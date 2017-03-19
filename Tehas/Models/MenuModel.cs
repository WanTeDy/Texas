using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tehas.Utils.DataBase.PagesDesc;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Frontend.Models
{
    public class MenuModel
    {        
        public List<Category> Categories { get; set; }        
        public PageDescription PageDescription { get; set; }
    }
}