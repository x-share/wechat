
namespace Wechat.EnterpriseAccount.Wechat.Http
{
    public abstract class WxPostRequest<T> : WxBaseRequest<T> where T : WxBaseReponse
    {
        [Newtonsoft.Json.JsonIgnore()]
        public override string Method { get { return METHOD_POST; } }
    }

    public abstract class WxPostWithTokenRequest<T> : WxPostRequest<T> where T : WxBaseReponse
    {
        [Newtonsoft.Json.JsonIgnore()]
        public string Token { get { return AccessToken.AccessTokenManager.GetAccessToken().Token; } }
    }
}
