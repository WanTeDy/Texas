using System;
using System.Collections.Generic;
using System.Linq;
using Tehas.Utils.DataBase.Security;
using Tehas.Utils.Helpers;

namespace Tehas.Utils.BusinessOperations.Auth
{
    public class CheckSignInDataOperation : BaseOperation
    {
        private String _login { get; set; }
        private String _password { get; set; }
        private String _tokenHash { get; set; }
        public User _user { get; set; }

        public CheckSignInDataOperation(string login, string password)
        {
            _login = login;
            _password = password;
        }

        protected override void InTransaction()
        {
            var user = Context.Users.Include("Phones").FirstOrDefault(x => (x.Email.ToLower() == _login.ToLower() 
                || x.Login.ToLower() == _login.ToLower()) && x.Password == _password && !x.Deleted);
            if (user == null)
                Errors.Add("Login", "Неправильный логин или пароль");
            else
            {
                user.TokenHash = GenerateHash.GetSha1Hash(Guid.NewGuid() + user.Password + Guid.NewGuid() + user.Email);
                _tokenHash = user.TokenHash;

                _user = new User
                {
                    Email = user.Email,
                    TokenHash = user.TokenHash,
                    Id = user.Id,
                    Login = user.Login,
                };

                Context.SaveChanges();
            }
        }
    }
}