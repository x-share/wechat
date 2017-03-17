using System;

namespace Wechat.EnterpriseAccount.Cache
{
    public class CacheEx
    {

        public static readonly CacheEx Instance = new CacheEx();

        public T Get<T>(string key) where T : class
        {
            if (CacheHelper.GetCache(key) == null)
                return default(T);
            return CacheHelper.GetCache(key) as T;
        }

        public int GetInt(string key)
        {
            if (CacheHelper.GetCache(key) == null)
                return 0;
            int ou = 0;
            int.TryParse(CacheHelper.GetCache(key).ToString(), out ou);
            return ou;
        }

        public string GetString(string key)
        {
            if (CacheHelper.GetCache(key) == null)
                return "";
            return CacheHelper.GetCache(key).ToString();
        }

        public bool Add(string key, object value, bool isCover = true)
        {
            lock (this)
            {
                if (CacheHelper.GetCache(key) != null)
                {
                    if (isCover)
                        CacheHelper.RemoveCache(key);
                    else
                        return true;
                }
                else
                {
                    if (isCover)
                        CacheHelper.SetCache(key, value, DateTime.Now.AddMinutes(20), System.Web.Caching.Cache.NoSlidingExpiration);
                }
                return true;
            }
        }

        public bool Add(string key, object value, DateTime absoluteExpiration)
        {
            lock (this)
            {
                if (CacheHelper.GetCache(key) != null)
                {
                    CacheHelper.RemoveCache(key);
                }
                CacheHelper.SetCache(key, value, absoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
                return true;
            }
        }

    }
}

