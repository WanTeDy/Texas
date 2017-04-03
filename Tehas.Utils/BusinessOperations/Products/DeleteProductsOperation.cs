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
    public class DeleteProductsOperation : BaseOperation
    {
        private int[] _ids { get; set; }        

        public DeleteProductsOperation(int[] ids)
        {
            _ids = ids;
            RussianName = "Удаление продукта";
        }

        protected override void InTransaction()
        {
            foreach (var id in _ids)
            {
                var _product = Context.Products.FirstOrDefault(x => x.Id == id && !x.Deleted);
                if (_product != null)
                {
                    if (_product.Image != null)
                    {
                        var path = HttpContext.Current.Server.MapPath(_product.Image.Url);
                        FileInfo fileInf = new FileInfo(path + _product.Image.FileName);
                        if (fileInf.Exists)
                        {
                            fileInf.Delete();
                        }
                        Context.Images.Remove(_product.Image);
                    }
                    Context.Products.Remove(_product);
                    Context.SaveChanges();
                }
            }
        }
    }
}
