using System;
using System.Linq;
using Tehas.Utils.Except;
using Tehas.Utils.DataBase.Security;

namespace Tehas.Utils.BusinessOperations.Auth
{
    public class SetPasswordOperation : BaseOperation
    {
        private String _password { get; set; }
        private String _tokenHash { get; set; }
        public User _user { get; set; }        

        public SetPasswordOperation(string password, string tokenHash)
        {
            _password = password;
            _tokenHash = tokenHash;
        }

        protected override void InTransaction()
        {
            var user = Context.Users.FirstOrDefault(x => x.TokenHash == _tokenHash && !x.Deleted);
            if (user == null)
                throw new ActionNotAllowedException("Данный " + _tokenHash + " не найден");
            user.Password = _password;
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