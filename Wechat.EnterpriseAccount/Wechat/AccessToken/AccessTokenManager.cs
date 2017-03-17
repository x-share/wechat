using Wechat.EnterpriseAccount.Cache;
using Wechat.EnterpriseAccount.Wechat.Api;
using System;

namespace Wechat.EnterpriseAccount.Wechat.AccessToken
{

    public class AccessTokenManager
    {

        private static IAccessTokenRepository iAccessTokenRepository = null;


        static object lockObj = new object();

        public static AccessToken GetAccessToken(bool isQueryAgin = false)
        {
            string cacheKey = GetAccessTokenCacheKey();
            AccessToken token = CacheEx.Instance.Get<AccessToken>(cacheKey);
            if (!isQueryAgin && token != null && !token.IsExpired)
            {
                return token;
            }
            token = GetTokenByWx(cacheKey, isQueryAgin);
            return token;
        }

        private static AccessToken GetTokenByWx(string cacheKey, bool isQueryAgin = false)
        {
            lock (lockObj)
            {

                AccessToken token = CacheEx.Instance.Get<AccessToken>(cacheKey);
                if (!isQueryAgin && token != null && !token.IsExpired)
                {
                    return token;
                }

                var accessTokenRepository = GetAccessTokenRepository();
                token = accessTokenRepository.Get();
    
                if (token == null || (token != null && token.IsExpired))
                {
                    var res = new GetTokenRequest().Request();
                    if (res.IsSuccess)
                    {
                        token = new AccessToken(res);
                        CacheEx.Instance.Add(cacheKey, token, token.ExpireTime);
                        accessTokenRepository.Update(token);
                    }
                }
                else
                {
                    CacheEx.Instance.Add(cacheKey, token, token.ExpireTime);
                }

                return token;
            }
        }

        private static string GetAccessTokenCacheKey()
        {
            return string.Format("CACHEKEY>>{0}>>{1}", WXCONFIG.WX_GLOBAL_CORPID, WXCONFIG.WX_GLOBAL_SUPERCORPSECRET);
        }

        private static IAccessTokenRepository GetAccessTokenRepository()
        {
            return iAccessTokenRepository ?? new DefaultAccessTokenRepository();
        }
        public static void SetAccessTokenRepository(IAccessTokenRepository iAccessTokenRepository)
        {
            AccessTokenManager.iAccessTokenRepository = iAccessTokenRepository;
        }

    }
}
