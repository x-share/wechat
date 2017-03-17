using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.EnterpriseAccount.Wechat.AccessToken
{
    public interface IAccessTokenRepository
    {
        AccessToken Get();
        bool Update(AccessToken token);
    }

    public class DefaultAccessTokenRepository : IAccessTokenRepository
    {
        public AccessToken Get()
        {
            return null;
        }

        public bool Update(AccessToken token)
        {
            return true;
        }
    }
}
