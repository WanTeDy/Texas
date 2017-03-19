using System;
using System.Linq;
using Tehas.Utils.DataBase.Security;

namespace Tehas.Utils.BusinessOperations.Users
{
    public class LoadUserOperation : BaseOperation
    {
        private String _tokenHash { get; set; }
        private Int32 _userId { get; set; }
        public User _user { get; set; }

        public LoadUserOperation(string tokenHash, int userId)
        {
            _tokenHash = tokenHash;
            _userId = userId;
            RussianName = "Просмотр данных пользователя";
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
                var userForWatching = Context.Users.FirstOrDefault(x => x.Id == _userId && !x.Deleted);
                if (userForWatching != null)
                {
                    _user = new User
                    {
                        Id = userForWatching.Id,
                        Login = userForWatching.Login,
                        Email = userForWatching.Email,
                        //Password = userForWatching.Password,
                        Deleted = userForWatching.Deleted,
                    };
                }
            }            
        }
    }
}