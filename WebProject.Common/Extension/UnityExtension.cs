using System.Collections.Generic;

namespace WebProject.Common
{
    public static class UnityExtension
    {
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count <= 0;
        }
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
