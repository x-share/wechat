using System.Collections.Generic;

namespace Wechat.EnterpriseAccount.Wechat.Api.SendMessage
{
    public class SendMpNewsMessageRequest : BaseSendMessageRequest
    {
        public class Article
        {
            /// <summary>
            /// 图文消息的标题，不超过128个字节，超过会自动截断
            /// </summary>
            [Newtonsoft.Json.JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// 图文消息缩略图的media_id, 可以在上传多媒体文件接口中获得。此处thumb_media_id即上传接口返回的media_id 
            /// </summary>
            [Newtonsoft.Json.JsonProperty("thumb_media_id")]
            public string ThumMediaId { get; set; }

            /// <summary>
            /// 图文消息的作者，不超过64个字节 
            /// </summary>
            [Newtonsoft.Json.JsonProperty("author")]
            public string Author { get; set; }

            /// <summary>
            /// 图文消息点击“阅读原文”之后的页面链接 
            /// </summary>
            [Newtonsoft.Json.JsonProperty("content_source_url")]
            public string ContentUrl { get; set; }

            /// <summary>
            /// 图文消息的内容，支持html标签，不超过666 K个字节 
            /// </summary>
            [Newtonsoft.Json.JsonProperty("content")]
            public string Content { get; set; }

            /// <summary>
            /// 图文消息的描述，不超过512个字节，超过会自动截断 
            /// </summary>
            [Newtonsoft.Json.JsonProperty("digest")]
            public string Digest { get; set; }

            /// <summary>
            /// 是否显示封面，1为显示，0为不显示 
            /// </summary>
            [Newtonsoft.Json.JsonProperty("show_cover_pic")]
            public string ShowCoverPic { get; set; }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="title">是  图文消息的标题，不超过128个字节，超过会自动截断</param>
            /// <param name="thumMediaId">是  图文消息缩略图的media_id, 可以在上传多媒体文件接口中获得。此处thumb_media_id即上传接口返回的media_id </param>
            /// <param name="author"> 否  图文消息的作者，不超过64个字节 </param>
            /// <param name="contentUrl"> 否  图文消息点击“阅读原文”之后的页面链接 </param>
            /// <param name="content">是 图文消息的内容，支持html标签，不超过666 K个字节 </param>
            /// <param name="digest">否 图文消息的描述，不超过512个字节，超过会自动截断 </param>
            /// <param name="showCoverPic"> 否  是否显示封面 </param>
            public Article(string title, string thumMediaId, string author, string contentUrl, string content, string digest, bool showCoverPic)
            {
                Title = title;
                ThumMediaId = thumMediaId;
                Author = author;
                ContentUrl = contentUrl;
                Content = content;
                Digest = digest;
                ShowCoverPic = (showCoverPic ? 1 : 0).ToString();
            }

        }
        public class News
        {

            [Newtonsoft.Json.JsonProperty("articles")]
            public List<Article> Articles { get; set; }
        }

        [Newtonsoft.Json.JsonProperty("msgtype")]
        public override string MesageType { get { return "mpnews"; } }

        [Newtonsoft.Json.JsonProperty("mpnews")]
        public News NewsInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("safe")]
        public int Safe { get; set; }
        public SendMpNewsMessageRequest(string[] toUsers, string[] toParties, string[] toTags, int agentId, List<Article> articles, bool isSafe)
        {
            ToUsers = string.Join("|", (toUsers ?? (new string[0])));
            ToParties = string.Join("|", (toParties ?? (new string[0])));
            ToTags = string.Join("|", (toTags ?? (new string[0])));
            AgentId = agentId;
            NewsInfo = new News { Articles = articles };
            Safe = isSafe ? 1 : 0;
        }
    }
}
