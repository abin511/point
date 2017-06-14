using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    [Table("Order")]
    [Serializable]
    public class OrderModel
    {
        [Key]
        public string OrderNo { get; set; }
        public int MemberId { get; set; }
        public int OrderFee { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime NotifyTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
