using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Emails;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Comments
{
    public class LoadCommentsOperation : BaseOperation
    {
        private Int32 _page { get; set; }
        private Int32 _count { get; set; }
        private Boolean _admin { get; set; }
        public List<Comment> _comments { get; set; }

        public LoadCommentsOperation(int page, int count, bool admin = false)
        {
            _page = page;
            _count = count;
            _admin = admin;
            RussianName = "Получение списка комментариев пользователей";
        }

        protected override void InTransaction()
        {
            if(_admin)
            {
                _comments = Context.Comments.Where(x => !x.Deleted).OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                _comments = Context.Comments.Where(x => x.IsModerated && !x.Deleted).OrderByDescending(x => x.Date).Skip((_page - 1) * _count).Take(_count).ToList();
            }
        }
    }
}