using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wechat.EnterpriseAccount.Wechat.Api.SendMessage;
using System.Diagnostics;

namespace Wechat.EnterpriseAccount.Test
{

    public static class DebugEx
    {
        public static void Write(object obj)
        {
            if (obj == null)
                Debug.WriteLine("null");
            else
                Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
    }


    [TestClass]
    public class UnitTest1
    {
        //static string[] toUser = new string[] { "lbl66888", "yang_mysky" };
        //static string[] toUser = new string[] { "@ALL" };
        static string[] toUser = new string[] { "lbl66888", "liuaywei" };//, "yang_mysky", "liuaywei"

        //static string[] toParties = new string[] { "IT中心", "借款中心" };
        static string[] toParties = null;

        //static string[] toTags = new string[] { "33", "得瑟的人" };
        static string[] toTags = null;


        static int agentId = 0;


        [TestMethod]
        public void 发送文本消息()
        {
            var mess = new SendTextMessageRequest(toUser, toParties, toTags, agentId, "just a test22", false
                );

            var res = mess.Request();
            DebugEx.Write(res);
        }



        [TestMethod]
        public void 发送图片消息()
        {
            var mess = new SendImageMessageRequest(toUser, toParties, toTags, agentId,
                "2sObRdSuWBgxOWU1fuFl_pogJOh1Np2czfNNnV6VfjcVzsomDamtdrsdLcKcfzt0W", false
                );

            var res = mess.Request();
            DebugEx.Write(res);
        }


        [TestMethod]


        public void 发送News消息()
        {
            for (int i = 1; i <= 5; i++)
            {
                var mess = new SendNewsMessageRequest(toUser, toParties, toTags, agentId,
                         new System.Collections.Generic.List<SendNewsMessageRequest.Article>()
                         {
                            // new SendNewsMessageRequest.Article("News测试一","News描述一","http://www.baidu.com","http://image54.360doc.com/DownloadImg/2012/09/0321/26597175_4.jpg"),
                            //new SendNewsMessageRequest.Article("News测试二","News描述二","http://www.baidu.com","http://image.tianjimedia.com/uploadImages/2014/338/52/G33ZSFCIIYXW.jpg"),
                            //new SendNewsMessageRequest.Article(
                            //    "News测试三",
                            //    "News描述三",
                            //   "",// "http://www.baidu.com",
                            //   ""// "http://news.xinhuanet.com/tech/2014-07/01/126691336_14041124204181n.jpg"
                            //    )

                             new SendNewsMessageRequest.Article(
                                "成功绑定PMS系统",
                                "注意：\n 1.一个PMS账户只能绑定一个微信帐号；\n 2.如需更换微信帐号，请联系IT部门；\n\n>>如有疑问请联系IT部门",
                               "",// "http://www.baidu.com",
                               "http://wx1.365datong.com:8002/Images/bind/"+i.ToString()+".jpg?v=good"
                                )
                         });

                var res = mess.Request();
                DebugEx.Write(res);

                System.Threading.Thread.Sleep(3000);

            }


        }

        [TestMethod]
        public void 发送mpNews消息()
        {
            var mess = new SendMpNewsMessageRequest(toUser, toParties, toTags, agentId,
                new System.Collections.Generic.List<SendMpNewsMessageRequest.Article>()
                {
                    //new SendMpNewsMessageRequest.Article("NPNews测试一","2v4DAMGM383FQuBLtjeUlX7cOMYLqO7ddpDL9yE7UtqL4yDg0xdBwLzcKUithv5vc","LIU","http://it.sohu.com/20160801/n462086489.shtml","不管围绕它有多少争议，必须承认，小米的产品能力都是数一数二的，MIUI 就是最好的例子。作为一个手机操作系统，它有很多让人眼前一亮的功能：拨号界面，只需要点击联系人首字母拼音对应的按键，就能快速找到他（比如“蒋鸿昌”，我只用点 542）；它会折叠各种乱七八糟的验证码短信；设置闹钟时，它有一个“工作日”选项，根本不用你去从周一点到周五；对了，MIUI 还支持电话录音，经常要电话采访的我简直太怀念了。 ","图文描述",true),
                    //new SendMpNewsMessageRequest.Article("NPNews测试二","2v4DAMGM383FQuBLtjeUlX7cOMYLqO7ddpDL9yE7UtqL4yDg0xdBwLzcKUithv5vc","LIU","http://it.sohu.com/20160801/n462086489.shtml","这些贴心的功能背后，是小米产品经理对数据和人性的精准洞悉，并在此基础上预设用户可能遇到的“场景”。把用户当“小白”，替他们做“正确的决定”是产品经理的重要方法论，产品经理们甚至恨不得让用户一键实现所有功能，小米就是个中高手。 ","图文描述",true),
                    new SendMpNewsMessageRequest.Article("NPNews测试三","2v4DAMGM383FQuBLtjeUlX7cOMYLqO7ddpDL9yE7UtqL4yDg0xdBwLzcKUithv5vc","LIU","http://it.sohu.com/20160801/n462086489.shtml","　但是，帮别人做决定总是有风险的，一不小心就会把毒药当成蜜糖送出去。小米旗下的米家血压计就遭遇了这样的尴尬： ","图文描述",true)
                }, false
                );

            var res = mess.Request();
            DebugEx.Write(res);
        }
    }
}
