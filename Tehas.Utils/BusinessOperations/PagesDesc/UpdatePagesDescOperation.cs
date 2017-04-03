using ImageResizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tehas.Utils.DataBase.PagesDesc;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.PagesDesc
{
    public class UpdatePagesDescOperation : BaseOperation
    {
        private String _controller { get; set; }
        private String _action { get; set; }
        private int _id { get; set; }
        private String _description { get; set; }
        private String _title { get; set; }
        private String _videoUrl { get; set; }
        private IEnumerable<HttpPostedFileBase> _images { get; set; }
        public PageDescription _pageDescription { get; set; }

        public UpdatePagesDescOperation(string controller, string action, string description, string title, string videoUrl, IEnumerable<HttpPostedFileBase> images)
        {
            _controller = controller.ToLower();
            _action = action.ToLower();
            _description = description;
            _title = title;
            _videoUrl = videoUrl;
            _images = images;
            RussianName = "Редактирование информации страницы";
        }
        public UpdatePagesDescOperation(int id, string description, string title, string videoUrl, IEnumerable<HttpPostedFileBase> images)
        {
            _description = description;
            _title = title;
            _videoUrl = videoUrl;
            _images = images;
            _id = id;
            RussianName = "Редактирование информации страницы";
        }

        protected override void InTransaction()
        {
            if (_id < 1)
                _pageDescription = Context.PageDescriptions.FirstOrDefault(x => x.ControllerName == _controller && x.ActionName == _action && !x.Deleted);
            else
                _pageDescription = Context.PageDescriptions.FirstOrDefault(x => x.Id == _id && !x.Deleted);
            if (_pageDescription != null)
            {
                if (_images != null)
                {
                    foreach (var imageFile in _images)
                    {
                        if (imageFile != null)
                        {
                            var url = String.Format("~/Content/images/pages/{0}/{1}/", _pageDescription.ControllerName, _pageDescription.ActionName);

                            var path = HttpContext.Current.Server.MapPath(url);
                            imageFile.InputStream.Seek(0, System.IO.SeekOrigin.Begin);
                            int point = imageFile.FileName.LastIndexOf('.');
                            var ext = imageFile.FileName.Substring(point);
                            var filename = imageFile.FileName.Substring(0, point) + "_" + DateTime.Now.ToFileTime() + ext;

                            ImageBuilder.Current.Build(
                                new ImageJob(imageFile.InputStream,
                                path + filename,
                                new Instructions("maxwidth=1600&maxheight=1200"),
                                false,
                                false));

                            var image = new Image
                            {
                                FileName = filename,
                                Url = url,
                            };
                            Context.Images.Add(image);
                            _pageDescription.Images.Add(image);
                        }
                    }
                }
                _pageDescription.Title = _title;
                _pageDescription.Description = _description;
                _pageDescription.VideoURL = _videoUrl;
                Context.SaveChanges();
            }
        }
    }
}
