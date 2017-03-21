using System;
using Tehas.Utils.DataBase.Security;
using System.Collections.Generic;

namespace Tehas.Frontend.Models
{
    public class SessionModel
    {
        public User User { get; set; }
        public String TokenHash { get; set; }
    }
}