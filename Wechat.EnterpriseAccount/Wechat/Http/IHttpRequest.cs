using System.Collections.Generic;

namespace Wechat.EnterpriseAccount.Wechat.Http
{
    public interface IHttpRequest
    {
        string GetUrl();
        string GetParamters();
        string Method { get; }
    }

    public interface IHttpResponse
    {
        string ReponseData { get; set; }
    }

}
