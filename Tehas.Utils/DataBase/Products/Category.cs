using System;
using System.Collections.Generic;

namespace Tehas.Utils.DataBase.Products
{
    public class Category : BaseObj
    {
        /// <summary>
        /// Parent's category id if present
        /// </summary>
        public Int32? ParentId { get; set; }
        /// <summary>
        /// Category's name in Russian
        /// </summary>     
        public String RussianName { get; set; }        

        public virtual Category Parent { get; set; }
        public virtual List<Product> Adverts { get; set; }  
    }
}