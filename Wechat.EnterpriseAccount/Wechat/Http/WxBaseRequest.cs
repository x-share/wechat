using System.Collections.Generic;

namespace Wechat.EnterpriseAccount.Wechat.Http
{
    public abstract class WxBaseRequest<T> : IHttpRequest where T : WxBaseReponse
    {
        public const string METHOD_GET = "GET";
        public const string METHOD_POST = "POST";

        public abstract string Method { get; }
        public virtual string GetParamters() { return null; }
        public abstract string GetUrl();

        protected string Format(string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public T Request()
        {
            return WXRequest.Request<T>(this);
        }
    }
}
