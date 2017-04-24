using System;
using System.Collections.Generic;
using Tehas.Utils.DataBase.Emails;
using Tehas.Utils.DataBase.Products;
using Tehas.Utils.DataBase.Security;

namespace Tehas.Utils.DataBase.Orders
{
    public class Order : BaseObj
    {        
        /// <summary>
        /// datetime
        /// </summary> 
        public DateTime Date { get; set; }

        public virtual List<OrderGames> OrderGames { get; set; } 
        public virtual List<OrderProducts> OrderProducts { get; set; } 
        public virtual UserEmailMessage UserEmailMessage { get; set; }
    }
}