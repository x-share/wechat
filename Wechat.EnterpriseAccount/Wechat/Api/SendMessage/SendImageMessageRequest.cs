namespace Wechat.EnterpriseAccount.Wechat.Api.SendMessage
{
    public class SendImageMessageRequest : BaseSendMessageRequest
    {
        public class Image
        {
            [Newtonsoft.Json.JsonProperty("media_id")]
            public string MediaId { get; set; }
        }

        [Newtonsoft.Json.JsonProperty("msgtype")]
        public override string MesageType { get { return "image"; } }

        [Newtonsoft.Json.JsonProperty("image")]
        public Image ImageInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("safe")]
        public int Safe { get; set; }

        public SendImageMessageRequest(string[] toUsers, string[] toParties, string[] toTags, int agentId, string imageId, bool isSafe)
        {
            ToUsers = string.Join("|", (toUsers ?? (new string[0])));
            ToParties = string.Join("|", (toParties ?? (new string[0])));
            ToTags = string.Join("|", (toTags ?? (new string[0])));
            AgentId = agentId;
            ImageInfo = new Image { MediaId = imageId };
            Safe = isSafe ? 1 : 0;
        }
    }
}
