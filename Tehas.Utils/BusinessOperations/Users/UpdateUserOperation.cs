using System;
using System.Linq;
using System.Collections.Generic;
using Tehas.Utils.DataBase.Security;
using Tehas.Utils.Except;

namespace Tehas.Utils.BusinessOperations.Users
{
    public class UpdateUserOperation : BaseOperation
    {
        private String _tokenHash { get; set; }
        public User _user { get; set; }

        public UpdateUserOperation(User user, string tokenHash)
        {
            _user = user;
            _tokenHash = tokenHash;
            RussianName = "Изменение данных пользователя";
        }

        protected override void InTransaction()
        {
            var user = Context.Users.FirstOrDefault(x => x.TokenHash == _tokenHash && !x.Deleted);
            if (user == null)
            {
                Errors.Add("Id", "Неверный Token");
            }
            else
            {
                var userForUpdating = Context.Users.Include("Role").Include("Phones").FirstOrDefault(x => x.Id == _user.Id && !x.Deleted);
                if (userForUpdating != null)
                {
                    SetFields(userForUpdating);
                    if (Success)
                    {
                        Context.SaveChanges();
                    }
                }
                else
                    Errors.Add("Id", "Пользователя с ID=" + _user.Id + " не найден");
            }
        }

        private void SetFields(User user)
        {
            if (user.Email.ToLower() != _user.Email.ToLower())
            {
                var otherEmail = Context.Users.FirstOrDefault(x => x.Email == _user.Email);
                if (otherEmail == null)
                    user.Email = _user.Email;
                else
                    Errors.Add("Email", "Такой email уже сужествует.");
            }            
        }
    }
}