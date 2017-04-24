using System;
using System.Collections.Generic;
using Tehas.Utils.DataBase.Orders;
using Tehas.Utils.DataBase.Security;
using Tehas.Utils.Helpers;

namespace Tehas.Utils.DataBase.Products
{
    public class Product : BaseObj
    {        
        /// <summary>
        /// Category's id for this product
        /// </summary>
        public Int32 CategoryId { get; set; }
        /// <summary>
        /// Title's name for this product
        /// </summary>
        public String Title { get; set; }        
        /// <summary>
        /// Price for this product
        /// </summary>
        public Double Price { get; set; }
        /// <summary>
        /// Discription for this product
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Discription for this product
        /// </summary>
        public String ShortDescription { get; set; }
        /// <summary>
        /// Image's id
        /// </summary>
        public Int32 ImageId { get; set; }
        /// <summary>
        /// IsHot - show in top menu
        /// </summary>
        public bool IsHot { get; set; }

        public virtual Category Category { get; set; }        
        public virtual Image Image { get; set; }
        public virtual List<OrderProducts> OrderProducts { get; set; }
    }
}