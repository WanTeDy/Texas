﻿using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.Helpers;

namespace Tehas.Utils.BusinessOperations.Cart
{
    public class LoadCartOperation : BaseOperation
    {
        //private List<CartModel> _cartModel { get; set; }
        //public List<CartAdvertModel> _adverts { get; set; }

        //public LoadCartOperation(List<CartModel> cartModel)
        //{
        //    _cartModel = cartModel;
        //    RussianName = "Получение избранных объявлений";
        //}

        protected override void InTransaction()
        {
            //_adverts = new List<CartAdvertModel>();
            //foreach (var item in _cartModel)
            //{
            //    CartAdvertModel adv = null;
            //    if (item.Type == AdvertsType.NewBuilding)
            //    {
            //        var el = Context.NewBuildings.FirstOrDefault(x => !x.Deleted && x.Id == item.AdvertId);
            //        if (el != null)
            //        {
            //            adv = new CartAdvertModel()
            //            {
            //                Id = item.AdvertId,
            //                Price = el.Price,
            //                Adress = el.Adress,
            //                Type = item.Type,
            //                Description = el.ExpluatationDate.Name,
            //                Name = el.Name,
            //                Image = el.Images.FirstOrDefault(x => !x.Deleted),
            //                IsHot = false,
            //            };
            //        }
            //    }
            //    else
            //    {
            //        var el = Context.Adverts.FirstOrDefault(x => !x.Deleted && x.Id == item.AdvertId);
            //        if (el != null)
            //        {
            //            adv = new CartAdvertModel()
            //            {
            //                Id = item.AdvertId,
            //                Price = el.Price,
            //                Adress = el.Street,
            //                Type = item.Type,
            //                Description = el.Description,
            //                Name = el.Title.RussianName,
            //                Image = el.Images.FirstOrDefault(x => !x.Deleted),
            //                IsHot = el.IsHot,
            //            };
            //        }
            //    }
            //_adverts.Add(adv);
            //}
        }
    }
}