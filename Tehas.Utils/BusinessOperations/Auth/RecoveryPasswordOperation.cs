using System;
using System.Linq;
using Tehas.Utils.Helpers;
using Tehas.Utils.DataBase.Security;

namespace Tehas.Utils.BusinessOperations.Auth
{
    public class RecoveryPasswordOperation : BaseOperation
    {
        private String _email { get; set; }
        private String _tokenHash { get; set; }
        public User _user { get; set; }

        public RecoveryPasswordOperation(string email)
        {
            _email = email;
        }

        protected override void InTransaction()
        {
            var _user = Context.Users.FirstOrDefault(x => x.Email.ToLower() == _email.ToLower() && !x.Deleted);
            if (_user == null)
                Errors.Add("Email", "Такого почтового адреса не существует!");
            else
            {
                _user.TokenHash = GenerateHash.GetSha1Hash(Guid.NewGuid() + _user.Password + Guid.NewGuid() + _user.Email);
                _tokenHash = _user.TokenHash;               
                Context.SaveChanges();
            }
        }
    }
}