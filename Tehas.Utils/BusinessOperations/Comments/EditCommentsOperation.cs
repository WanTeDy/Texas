using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Emails;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Comments
{
    public class EditCommentsOperation : BaseOperation
    {
        private Int32 _id { get; set; }
        private Boolean _isModerated { get; set; }

        public EditCommentsOperation(int id, bool isModerated)
        {
            _id = id;
            _isModerated = isModerated;
            RussianName = "Изменение состояния комментариев пользователей";
        }

        protected override void InTransaction()
        {
            var comment = Context.Comments.FirstOrDefault(x => x.Id == _id && !x.Deleted);
            if(comment != null)
            {
                comment.IsModerated = _isModerated;
                Context.SaveChanges();
            }
        }
    }
}