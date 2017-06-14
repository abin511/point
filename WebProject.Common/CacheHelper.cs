using System;
using System.Web;
using System.Web.Caching;

namespace WebProject.Common
{
    public class CacheHelper
    {
        private const string Prefix = "WebProject.Local.";

        public static void Set(string key, object entry, TimeSpan utcExpiry)
        {
            Cache objCache = HttpRuntime.Cache;
            //弹性过期时间
            objCache.Insert(Prefix + key, entry, null, Cache.NoAbsoluteExpiration, utcExpiry);
        }
        public static object Get(string key)
        {
            Cache objCache = HttpRuntime.Cache;
            return objCache[Prefix + key];
        }
        public static T Get<T>(string key)
        {
            Cache objCache = HttpRuntime.Cache;
            var value = objCache[Prefix + key];
            if (value == null) return default(T);
            return (T)value;
        }
        public static T Get<T>(string key, Func<T> func, TimeSpan utcExpiry) where T : new()
        {
            Cache objCache = HttpRuntime.Cache;
            var value = objCache[Prefix + key];
            if (value != null)
            {
                return value.ToString().JsonDeserialize<T>();
            }
            if (func == null)
            {
                return default(T);
            }
            value = func();
            if (value != null)
            {
                Set(key, value, utcExpiry);
                return value.ToString().JsonDeserialize<T>();
            }
            return default(T);
        }
        public static void Remove(string key)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Remove(Prefix + key);
        }
    }
}
