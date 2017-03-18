![wechat icon](https://mp.weixin.qq.com/wiki/static/assets/dc5de672083b2ec495408b00b96c9aab.png)

## 简介

>这是用.net封装的的微信公众号通讯协议，最初的需求只是满足于企业号开发，但后来发现服务号开发也是可以用的。

## 细节

### 1、先看调用
``` csharp
//发个消息
var mess = new SendTextMessageRequest(toUser, toParties, toTags, agentId, "hell boy", false); 
var res = mess.Request();
```
>是不是很方便

### 2、再看设计
![d1 icon](https://github.com/x-share/wechat/blob/master/Design/wx2.png)
![d2 icon](https://github.com/x-share/wechat/blob/master/Design/wx.png)

> 不多解释 

### 3、再看扩展能力如何
> #### GET 请求，继承`WxGetWithTokenRequest`或`GetTokenRequest`
``` csharp
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
```
> #### POST请求，继承`WxPostRequest`或`WxPostWithTokenRequest`
``` csharp
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
```

### 4、适合服务号开发吗
> #### 通过看[公共平台开发文档](https://mp.weixin.qq.com/wiki/14/9f9c82c1af308e3b14ba9b973f99a8ba.html),你会发现获取Token协议和企业号一样，发送消息是一样的,所以是适合微信所有公共平台开发；

但是有心的朋友会发现,例如`接收文本消息`协议：
``` xml
 <xml>
 <ToUserName><![CDATA[toUser]]></ToUserName>
 <FromUserName><![CDATA[fromUser]]></FromUserName> 
 <CreateTime>1348831860</CreateTime>
 <MsgType><![CDATA[text]]></MsgType>
 <Content><![CDATA[this is a test]]></Content>
 <MsgId>1234567890123456</MsgId>
 </xml>
```
>对此只是数据格式的问题，既然可以用JSON传递当然也可用其它的格式，就是一个简单的格式或者序列化问题；

## 平台化
* 单纯从局部设计上来讲，有其优势；
* 至于平台化或作为平台的一部分，有想法的朋友可以聊聊。 

## Author
* QQ：1919305111

