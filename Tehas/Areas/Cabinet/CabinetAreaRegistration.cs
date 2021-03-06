﻿using System.Web.Mvc;

namespace Tehas.Frontend.Areas.Cabinet
{
    public class CabinetAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Cabinet";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Cabinet_default",
                "Cabinet/{controller}/{action}/{id}",
                new { controller = "main", action = "index", id = UrlParameter.Optional },
                new[] { "Tehas.Frontend.Areas.Cabinet.Controllers" }

            );
        }
    }
}