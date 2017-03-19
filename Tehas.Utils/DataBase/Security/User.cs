using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tehas.Utils.DataBase.Security
{
    public class User : BaseObj
    {        
        /// <summary>
        /// Email
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public String Login { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public String Password { get; set; }              
        /// <summary>
        /// TokenHash
        /// </summary>
        public String TokenHash { get; set; }            
    }
}