using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.PagesDesc;

namespace Tehas.Utils.BusinessOperations.PagesDesc
{
    public class LoadPagesDescOperation : BaseOperation
    {
        private String _controller { get; set; }
        private String _action { get; set; }
        public PageDescription _pageDescription { get; set; }

        public LoadPagesDescOperation(string controller, string action)
        {
            _controller = controller;
            _action = action;
            RussianName = "Получение информации страницы";
        }

        protected override void InTransaction()
        {
            _pageDescription = Context.PageDescriptions.FirstOrDefault(x => x.ControllerName == _controller && x.ActionName == _action && !x.Deleted);
        }
    }
}