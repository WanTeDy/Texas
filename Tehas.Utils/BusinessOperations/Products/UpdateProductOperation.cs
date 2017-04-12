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
    public class UpdateProductOperation : BaseOperation
    {
        private int _id { get; set; }
        private int _categoryId { get; set; }
        private String _description { get; set; }
        private String _title { get; set; }
        private double _price { get; set; }
        private bool _isHot { get; set; }
        private HttpPostedFileBase _image { get; set; }
        public Product _product { get; set; }

        public UpdateProductOperation(int id, int categoryId, string description, string title, double price, bool isHot, HttpPostedFileBase image)
        {
            _id = id;
            _description = description;
            _title = title;
            _price = price;
            _isHot = isHot;
            _image = image;
            _categoryId = categoryId;
            RussianName = "Редактирование информации продукта";
        }

        protected override void InTransaction()
        {
            _product = Context.Products.FirstOrDefault(x => x.Id == _id && !x.Deleted);
            if (_product == null)
                Errors.Add("Id", "Данный продукт не найден");
            else
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
                            var deleteImg = _product.Image;
                            FileInfo fileInf = new FileInfo(path + deleteImg.FileName);
                            if (fileInf.Exists)
                            {
                                fileInf.Delete();
                            }
                            Context.Images.Add(image);
                            _product.Image = image;
                            Context.Images.Remove(deleteImg);
                        }
                        _product.CategoryId = _categoryId;
                        _product.Title = _title;
                        _product.Description = _description;
                        _product.Price = _price;
                        _product.IsHot = _isHot;
                        Context.SaveChanges();
                    }
                }
            }
        }
    }
}
