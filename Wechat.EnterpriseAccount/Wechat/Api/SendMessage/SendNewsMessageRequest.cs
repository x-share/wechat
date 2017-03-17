using System.Collections.Generic;

namespace Wechat.EnterpriseAccount.Wechat.Api.SendMessage
{
    public class SendNewsMessageRequest : BaseSendMessageRequest
    {
        public class Article
        {

            [Newtonsoft.Json.JsonProperty("title")]
            public string Title { get; set; }
            [Newtonsoft.Json.JsonProperty("description")]
            public string Description { get; set; }
            [Newtonsoft.Json.JsonProperty("url")]
            public string Url { get; set; }
            [Newtonsoft.Json.JsonProperty("picurl")]
            public string Picurl { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="title">否  标题，不超过128个字节，超过会自动截断 </param>
            /// <param name="description">否  描述，不超过512个字节，超过会自动截断 </param>
            /// <param name="url">否  点击后跳转的链接。 </param>
            /// <param name="picurl">否  图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80。如不填，在客户端不显示图片  </param>
            public Article(string title, string description, string url, string picurl)
            {
                Title = title;
                Description = description;
                Url = url;
                Picurl = picurl;
            }
        }
        public class News
        {

            [Newtonsoft.Json.JsonProperty("articles")]
            public List<Article> Articles { get; set; }
        }

        [Newtonsoft.Json.JsonProperty("msgtype")]
        public override string MesageType { get { return "news"; } }

        [Newtonsoft.Json.JsonProperty("news")]
        public News NewsInfo { get; set; }

        public SendNewsMessageRequest(string[] toUsers, string[] toParties, string[] toTags, int agentId, List<Article> articles)
        {
            ToUsers = string.Join("|", (toUsers ?? (new string[0])));
            ToParties = string.Join("|", (toParties ?? (new string[0])));
            ToTags = string.Join("|", (toTags ?? (new string[0])));
            AgentId = agentId;
            NewsInfo = new News {  Articles= articles };
        }
    }
}

