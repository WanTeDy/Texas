using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Tehas.Utils.DataBase.PagesDesc;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Games
{
    public class UpdateGameOperation : BaseOperation
    {
        private int _id { get; set; }
        private String _description { get; set; }
        private String _name { get; set; }
        private double _price { get; set; }
        public Game _game { get; set; }

        public UpdateGameOperation(int id, string name, double price, string description = null)
        {
            _id = id;
            _description = description;
            _name = name;
            _price = price;
            RussianName = "Редактирование информации игрового тарифа";
        }

        protected override void InTransaction()
        {
            _game = Context.Games.FirstOrDefault(x => x.Id == _id && !x.Deleted);
            if (_game == null)
                Errors.Add("Id", "Данный тариф не найден");
            else
            {
                if (_price < 0)
                {
                    Errors.Add("Price", "Цена не может быть меньше 0");
                }
                else
                {
                    _game.Name = _name;
                    _game.Description = _description;
                    _game.Price = _price;
                    Context.SaveChanges();
                }
            }
        }
    }
}
