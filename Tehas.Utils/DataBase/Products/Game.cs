using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehas.Utils.DataBase.Products
{
    public class Game : BaseObj
    {        
        /// <summary>
        /// Name for this game
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// Price for this game
        /// </summary>
        public Double Price { get; set; }
        /// <summary>
        /// Discription for this game
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Discription for this game
        /// </summary>
        public String ShortDescription { get; set; }
        /// <summary>
        /// Day of the week for this game tarif
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }
        /// <summary>
        /// Parrent id for this game tarif
        /// </summary>
        public Int32? ParrentId { get; set; }

        public virtual Game Parrent { get; set; }
    }
}

