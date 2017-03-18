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
![d1 icon](https://github.com/x-share/wechat/blob/master/Design/wx.png?raw=true)
