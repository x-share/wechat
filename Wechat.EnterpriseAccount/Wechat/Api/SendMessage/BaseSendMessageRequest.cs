using Wechat.EnterpriseAccount.Wechat.Http;

namespace Wechat.EnterpriseAccount.Wechat.Api.SendMessage
{
    public abstract class BaseSendMessageRequest : WxPostWithTokenRequest<SendMessageCommonResponse>
    {
        [Newtonsoft.Json.JsonProperty("touser")]
        public string ToUsers { get; set; }
        [Newtonsoft.Json.JsonProperty("toparty")]
        public string ToParties { get; set; }
        [Newtonsoft.Json.JsonProperty("totag")]
        public string ToTags { get; set; }
        [Newtonsoft.Json.JsonProperty("msgtype")]
        public virtual string MesageType { get; }
        [Newtonsoft.Json.JsonProperty("agentid")]
        public virtual int AgentId { get; set; }

        public override string GetUrl()
        {
            return Format(ApiInfo.ADDR_SEND_MESSAGE, Token);
        }
        public override string GetParamters()
        {
            return  Newtonsoft.Json.JsonConvert.SerializeObject(this); 
        }
    }
}
