using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.PagesDesc;
using Tehas.Utils.DataBase.Products;
using ImageResizer;

namespace Tehas.Utils.BusinessOperations.PagesDesc
{
    public class AddPagesDescOperation : BaseOperation
    {
        private String _controller { get; set; }
        private String _action { get; set; }
        private String _description { get; set; }
        private String _title { get; set; }
        private String _videoUrl { get; set; }
        private List<HttpPostedFileBase> _images { get; set; }
        public PageDescription _pageDescription { get; set; }

        public AddPagesDescOperation(string controller, string action, string description, string title, string videoUrl, List<HttpPostedFileBase> images)
        {
            _controller = controller;
            _action = action;
            _description = action;
            _title = action;
            _videoUrl = action;
            _images = images;
            RussianName = "Добавление информации о новой странице";
        }

        protected override void InTransaction()
        {
            if (_images != null && _images.Count > 0)
            {
                List<Image> images = new List<Image>();
                foreach (var imageFile in _images)
                {
                    if (imageFile != null)
                    {
                        var url = String.Format("~/Content/images/pages/{0}/{1}/", _controller, _action);

                        var path = HttpContext.Current.Server.MapPath(url);
                        imageFile.InputStream.Seek(0, System.IO.SeekOrigin.Begin);

                        var filename = imageFile.FileName + "_" + DateTime.Now;

                        ImageBuilder.Current.Build(
                            new ImageJob(imageFile.InputStream,
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
                        images.Add(image);
                    }
                }
                PageDescription page = new PageDescription
                {
                    ActionName = _action,
                    ControllerName = _controller,
                    Description = _description,
                    Title = _title,
                    VideoURL = _videoUrl,
                    Images = images,
                };
                _pageDescription = Context.PageDescriptions.FirstOrDefault(x => x.ControllerName == _controller && x.ActionName == _action && !x.Deleted);
            }
        }
    }
}