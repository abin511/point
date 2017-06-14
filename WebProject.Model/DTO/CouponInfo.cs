using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebProject.Model
{
    [Serializable]
    [DataContract]
    public class ShopRequest : QueryPageBase<ShopModel>
    {
        public int Category { get; set; }
    }
}
