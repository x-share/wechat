
namespace Wechat.EnterpriseAccount.Wechat.Http
{
    public abstract class WxGetRequest<T> : WxBaseRequest<T>  where T : WxBaseReponse
    {
        public override string Method { get { return METHOD_GET; } }
    }

    public abstract class WxGetWithTokenRequest<T> : WxGetRequest<T> where T : WxBaseReponse
    {
        public string Token { get { return AccessToken.AccessTokenManager.GetAccessToken().Token; } }
    }
}
