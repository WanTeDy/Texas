using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tehas.Utils.DataBase.Emails;
using Tehas.Utils.Helpers;

namespace Tehas.Utils.Models
{
    public class FullCartModel
    {       
        public UserEmailMessage Email { get; set; }
        public List<CartProductsModel> Products { get; set; }
        public List<CartGamesModel> Games { get; set; }
    }
}