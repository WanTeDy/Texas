using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Security;
using Tehas.Utils.Helpers;

namespace Tehas.Utils.BusinessOperations.Users
{
    public class AddUserOperation : BaseOperation
    {
        private String _login { get; set; }
        private String _email { get; set; }
        private String _password { get; set; }
        private String _tokenHash { get; set; }
        public User _user { get; set; }

        public AddUserOperation(string login, string email, string password)
        {
            _login = login;
            _email = email;
            _password = password;
            RussianName = "Добавление нового пользователя";
        }

        protected override void InTransaction()
        {
            var userLogin = Context.Users.FirstOrDefault(x => !x.Deleted && x.Login.ToLower() == _login.ToLower());
            if (userLogin != null)
                Errors.Add("Name", "Пользователь с таким логином уже существует!");
            else
            {
                var userEmail = Context.Users.FirstOrDefault(x => !x.Deleted && x.Email.ToLower() == _email.ToLower());
                if (userEmail != null)
                    Errors.Add("Email", "Такой электронный адрес уже используется!");
                else
                {
                    _user = new User
                    {
                        Password = _password,
                        Email = _email,
                        Login = _login,
                        Deleted = false,
                    };
                    _user.TokenHash = GenerateHash.GetSha1Hash(Guid.NewGuid() + _user.Password + Guid.NewGuid() + _user.Email + Guid.NewGuid());
                    _tokenHash = _user.TokenHash;
                    Context.Users.Add(_user);
                    Context.SaveChanges();
                }
            }
        }
    }
}