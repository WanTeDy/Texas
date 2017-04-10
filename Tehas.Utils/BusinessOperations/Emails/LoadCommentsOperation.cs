using System;
using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Emails;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Emails
{
    public class LoadCommentsOperation : BaseOperation
    {
        private Int32 _page { get; set; }
        private Int32 _count { get; set; }
        public List<Comment> _comments { get; set; }

        public LoadCommentsOperation(int page, int count)
        {
            _page = page;
            _count = count;
            RussianName = "Получение списка комментариев пользователей";
        }

        protected override void InTransaction()
        {
            _comments = Context.Comments.Where(x => x.IsModerated && !x.Deleted).OrderBy(x => x.Date).Skip((_page - 1) * _count).Take(_count).ToList();
        }
    }
}