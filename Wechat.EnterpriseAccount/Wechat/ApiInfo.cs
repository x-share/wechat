namespace Wechat.EnterpriseAccount.Wechat
{
    public class ApiInfo
    {

        public const string ADDR_GETTOKEN = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}";
        public const string ADDR_USER_AUTHSUCC = "https://qyapi.weixin.qq.com/cgi-bin/user/authsucc?access_token={0}&userid={1}";
        public const string ADDR_USER_GETUSERINFO = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}";
        public const string ADDR_OAUTH2_AUTHORIZE = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}{5}";
        public const string ADDR_SEND_MESSAGE = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}";



    }
}
