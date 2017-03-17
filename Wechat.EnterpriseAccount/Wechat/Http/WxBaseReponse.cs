
namespace Wechat.EnterpriseAccount.Wechat.Http
{
    public class WxBaseReponse : IHttpResponse
    {
        [Newtonsoft.Json.JsonProperty("errcode")]
        public string ErrCode { get; set; }
        [Newtonsoft.Json.JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [Newtonsoft.Json.JsonIgnore()]
        public string ReponseData { get; set; }

        [Newtonsoft.Json.JsonIgnore()]
        public virtual bool IsSuccess
        {
            get { return string.IsNullOrEmpty(ErrCode); }
        }
    }
}
