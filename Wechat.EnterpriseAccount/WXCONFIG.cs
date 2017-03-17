namespace Wechat.EnterpriseAccount
{


    /// <summary>
    /// 配置
    /// </summary>
    public static class WXCONFIG
    {

        public static string WX_GLOBAL_CORPID = GET("WX.GLOBAL.CORPID"); //企业Id
        public static string WX_GLOBAL_SUPERCORPSECRET = GET("WX.GLOBAL.SUPERCORPSECRET"); //超管（管理所有应用）管理组的凭证密钥

        public static int WX_APP_ASSISTANT_ID = GETINT("WX.APP.ASSISTANT.ID"); //个人助手
        public static int WX_APP_CRM_ID = GETINT("WX.APP.CRM.ID"); //财务
        

        public static string WXDB_ACCESSTOKEN = "WX.ACCESSTOKEN"; //token
        public static string WX_WEBSITE_DOMAIN = GET("WX.WEBSITE.DOMAIN");


        #region  METHOD
        public static int GETINT(string key)
        {
            string v = GET(key) ?? "0"; int vi = 0;
            int.TryParse(v, out vi);
            return vi;
        }
        public static string GET(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
        #endregion

    }
}
