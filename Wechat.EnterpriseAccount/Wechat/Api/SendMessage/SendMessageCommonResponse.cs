using Wechat.EnterpriseAccount.Wechat.Http;

namespace Wechat.EnterpriseAccount.Wechat.Api.SendMessage
{
    public class SendMessageCommonResponse : WxBaseReponse
    {
        [Newtonsoft.Json.JsonProperty("invaliduser")]
        public string InvalIdUser { get; set; }
        [Newtonsoft.Json.JsonProperty("invalidparty")]
        public string InvalIdParty { get; set; }
        [Newtonsoft.Json.JsonProperty("invalidtag")]
        public string InvalIdTag { get; set; }

        [Newtonsoft.Json.JsonIgnore()]
        public override bool IsSuccess
        {
            get { return !string.IsNullOrEmpty(ErrCode) && ErrCode.Trim() == "0"; }
        }
    }
}
