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
        private int _id { get; set; }
        public PageDescription _pageDescription { get; set; }

        public LoadPagesDescOperation(string controller, string action)
        {
            _controller = controller.ToLower();
            _action = action.ToLower();
            RussianName = "Получение информации страницы";
        }
        public LoadPagesDescOperation(int id)
        {
            _id = id;
            RussianName = "Получение информации страницы";
        }

        protected override void InTransaction()
        {
            if (_id < 1)
                _pageDescription = Context.PageDescriptions.FirstOrDefault(x => x.ControllerName == _controller && x.ActionName == _action && !x.Deleted);
            else
                _pageDescription = Context.PageDescriptions.FirstOrDefault(x => x.Id == _id && !x.Deleted);
        }
    }
}