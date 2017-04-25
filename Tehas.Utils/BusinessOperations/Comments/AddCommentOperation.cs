using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Emails;
using Tehas.Utils.DataBase.Products;

namespace Tehas.Utils.BusinessOperations.Comments
{
    public class AddCommentOperation : BaseOperation
    {
        private String _username { get; set; }
        private String _message { get; set; }
        public List<Comment> _comments { get; set; }

        public AddCommentOperation(string username, string message)
        {
            _username = username;
            _message = message;
            RussianName = "Добавление комментария пользователей";
        }

        protected override void InTransaction()
        {
            Comment comment = new Comment
            {
                Username = _username,
                Message = _message,
                Date = DateTime.Now
            };
            Context.Comments.Add(comment);
            Context.SaveChanges();
        }
    }
}