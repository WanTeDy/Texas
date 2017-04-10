using System;
using System.Collections.Generic;
using Tehas.Utils.DataBase.Security;

namespace Tehas.Utils.DataBase.Emails
{
    public class Comment : BaseObj
    {
        /// <summary>
        /// user's name
        /// </summary>       
        public String Username { get; set; }        
        /// <summary>
        /// Message
        /// </summary> 
        public String Message { get; set; }
        /// <summary>
        /// datetime
        /// </summary> 
        public DateTime Date { get; set; }
        /// <summary>
        /// Is comment past moderation
        /// </summary> 
        public Boolean IsModerated { get; set; }
    }
}