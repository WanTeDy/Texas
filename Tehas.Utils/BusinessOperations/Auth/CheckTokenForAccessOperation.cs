using System;
using System.Linq;

namespace Tehas.Utils.BusinessOperations.Auth
{
    public class CheckTokenForAccessOperation : BaseOperation
    {
        public String _tokenHash { get; set; }
        public Boolean _access { get; set; }

        public CheckTokenForAccessOperation(string tokenHash)
        {
            _access = false;
            _tokenHash = tokenHash;
        }

        protected override void InTransaction()
        {
            var user = Context.Users.FirstOrDefault(x => x.TokenHash == _tokenHash && !x.Deleted);
            if (user != null)
            {
                _access = true;                
            }
        }
    }
}