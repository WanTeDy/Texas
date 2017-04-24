using System;
using System.Collections.Generic;
using Tehas.Utils.DataBase.Products;
using Tehas.Utils.DataBase.Security;

namespace Tehas.Utils.DataBase.Orders
{
    public class OrderProducts : BaseObj
    {
        public Int32 Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}