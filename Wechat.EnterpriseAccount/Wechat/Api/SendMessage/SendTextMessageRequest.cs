namespace Wechat.EnterpriseAccount.Wechat.Api.SendMessage
{
    public class SendTextMessageRequest : BaseSendMessageRequest
    {
        public class Message
        {
            [Newtonsoft.Json.JsonProperty("content")]
            public string Content { get; set; }
        }

        [Newtonsoft.Json.JsonProperty("msgtype")]
        public override string MesageType { get { return "text"; } }

        [Newtonsoft.Json.JsonProperty("text")]
        public Message Text { get; set; }

        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("safe")]
        public int Safe { get; set; }

        public SendTextMessageRequest(string[] toUsers, string[] toParties, string[] toTags, int agentId, string content, bool isSafe)
        {
            ToUsers = string.Join("|", (toUsers ?? (new string[0])));
            ToParties = string.Join("|", (toParties ?? (new string[0])));
            ToTags = string.Join("|", (toTags ?? (new string[0])));
            AgentId = agentId;
            Text = new Message { Content = content };
            Safe = isSafe ? 1 : 0;
        }
    }

}
