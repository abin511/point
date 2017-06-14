using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebProject.Model;

namespace Admin.Site.Utlity
{
    public static class ListHelper
    {
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count <= 0;
        }
        public static List<SelectListItem> KeyValueToSelectListItem(this List<KeyValue<int, string>> list)
        {
            return list.Select(item => new SelectListItem { Text = item.Value, Value = item.Key.ToString() }).ToList();
        }

        public static List<SelectListItem> DictionaryToSelectListItem(this Dictionary<int, string> dic, SelectListItem dftValue = null)
        {
            var items = dic.Select(item => new SelectListItem { Text = item.Value, Value = item.Key.ToString() }).ToList();
            if (dftValue != null)
                items.Insert(0, dftValue);
            return items;
        }
    }
}
