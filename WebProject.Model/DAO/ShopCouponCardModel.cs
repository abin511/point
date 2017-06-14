using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 优惠券明细表
    /// </summary>
    [Table("ShopCouponCard")]
    [Serializable]
    public class ShopCouponCardModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 优惠券ID
        /// </summary>
        public int CouponId { get; set; }

        /// <summary>
        /// 优惠券编号
        /// </summary>
        public string CouponCard { get; set; }

        /// <summary>
        /// 优惠券状态 见枚举CouponStatus
        /// </summary>
        public CouponStatus Status { get; set; }

        /// <summary>
        /// 使用人
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime? UsedTime { get; set; }

        /// <summary>
        /// 发券时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
