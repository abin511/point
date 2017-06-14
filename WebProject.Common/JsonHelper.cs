using System;
using Newtonsoft.Json;

namespace WebProject.Common
{
    public static class JsonHelper
    {
        public static T JsonDeserialize<T>(this string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString)) return default(T);
            try
            {
                if ((typeof(T)).Name.ToLower() == "string")
                {
                    return (T)Convert.ChangeType(jsonString, typeof(T));
                }
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
