using Wechat.EnterpriseAccount.Wechat.Http;

namespace Wechat.EnterpriseAccount.Wechat.Api
{
    public class GetUserInfoRequest : WxGetWithTokenRequest<GetUserInfoReponse>
    {
        public string Code { get; set; }
        public GetUserInfoRequest(string code)
        {
            Code = code;
        }
        public override string GetUrl()
        {
            return Format(ApiInfo.ADDR_USER_GETUSERINFO, Token, Code);
        }
    }

    public class GetUserInfoReponse : WxBaseReponse
    {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string OpenId { get; set; }

        [Newtonsoft.Json.JsonIgnore()]
        public bool Related
        {
            get { return !string.IsNullOrEmpty(UserId); }
        }
    }
}
