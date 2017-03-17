using Wechat.EnterpriseAccount.Wechat.Http;

namespace Wechat.EnterpriseAccount.Wechat.Api
{
    public class GetTokenRequest : WxGetRequest<GetTokenReponse>
    {
        public override string GetUrl()
        {
            return Format(ApiInfo.ADDR_GETTOKEN, WXCONFIG.WX_GLOBAL_CORPID, WXCONFIG.WX_GLOBAL_SUPERCORPSECRET);
        }
    }

    public class GetTokenReponse : WxBaseReponse
    {
        [Newtonsoft.Json.JsonProperty("access_token")]
        public string Access_Token { get; set; }
        [Newtonsoft.Json.JsonProperty("expires_in")]
        public int Expires_In { get; set; }
    }
}
