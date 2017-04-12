using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Tehas.Utils.DataBase.PagesDesc;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Products
{
    public class AddProductOperation : BaseOperation
    {
        private int _categoryId { get; set; }
        private String _description { get; set; }
        private String _title { get; set; }
        private double _price { get; set; }
        private bool _isHot { get; set; }
        private HttpPostedFileBase _image { get; set; }

        public AddProductOperation(int categoryId, string description, string title, double price, bool isHot, HttpPostedFileBase image)
        {
            _description = description;
            _title = title;
            _price = price;
            _isHot = isHot;
            _image = image;
            _categoryId = categoryId;
            RussianName = "Добавление продукта";
        }

        protected override void InTransaction()
        {

            var category = Context.Categories.FirstOrDefault(x => x.Id == _categoryId && !x.Deleted);
            if (category == null)
            {
                Errors.Add("CategoryId", "Данная категория не найдена");
            }
            else
            {
                if (_price < 0)
                {
                    Errors.Add("Price", "Цена не может быть меньше 0");
                }
                else
                {
                    Product _product = new Product();
                    if (_image != null)
                    {
                        var url = "~/Content/images/products/";

                        var path = HttpContext.Current.Server.MapPath(url);
                        _image.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
                        int point = _image.FileName.LastIndexOf('.');
                        var ext = _image.FileName.Substring(point);
                        var filename = _image.FileName.Substring(0, point) + "_" + DateTime.Now.ToFileTime() + ext;

                        ImageBuilder.Current.Build(
                            new ImageJob(_image.InputStream,
                            path + filename,
                            new Instructions("maxwidth=1200&maxheight=1200"),
                            false,
                            false));

                        var image = new Image
                        {
                            FileName = filename,
                            Url = url,
                        };
                        Context.Images.Add(image);
                        _product.Image = image;
                    }
                    _product.CategoryId = _categoryId;
                    _product.Title = _title;
                    _product.Description = _description;
                    _product.Price = _price;
                    _product.IsHot = _isHot;
                    Context.Products.Add(_product);
                    Context.SaveChanges();
                }
            }
        }
    }
}
