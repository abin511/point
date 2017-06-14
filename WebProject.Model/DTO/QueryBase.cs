using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebProject.Model
{
    [Serializable]
    [DataContract]
    public class QueryPageBase<T>
    {
        public QueryPageBase()
        {
            PageIndex = 1;
            PageSize = 10;
            DataList = new List<T>();
        }

        private int _pageCount = 0;

        [DataMember]
        public int PageIndex { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public int PageCount
        {
            get
            {
                if (_pageCount == 0 && Count > 0)
                {
                    _pageCount = Count / PageSize;
                    if (Count % PageSize > 0)
                    {
                        _pageCount += 1;
                    }
                }
                return _pageCount;

            }
            set { _pageCount = value; }
        }
        [DataMember]
        public List<T> DataList { get; set; }
    }

    public class QueryBase<T>: QueryPageBase<T>
    {
        public int UserId { get; set; }
        //public string Token { get; set; }
    }
}
