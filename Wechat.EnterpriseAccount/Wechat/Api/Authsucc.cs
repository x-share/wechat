using Wechat.EnterpriseAccount.Wechat.Http;

namespace Wechat.EnterpriseAccount.Wechat.Api
{
    public class AuthsuccRequest : WxGetWithTokenRequest<AuthsuccResponse>
    {
        public string UserId { get; set; }

        public AuthsuccRequest(string userId)
        {
            UserId = userId;
        }

        public override string GetUrl()
        {
            return Format(ApiInfo.ADDR_USER_AUTHSUCC, Token, UserId);
        }
    }

    public class AuthsuccResponse : WxBaseReponse
    {
        public override bool IsSuccess
        {
            get
            {
                if (string.IsNullOrEmpty(ErrCode)) return true;
                if (ErrCode != null && ErrCode.Trim() == "0") return true;
                return false;
            }
        }

        /// <summary>
        /// 是否已经认证
        /// </summary>
        public bool HasVali
        {
            get
            {
                return !string.IsNullOrEmpty(ErrCode) && ErrCode.Trim() == "50004";
            }
        }
    }
}
