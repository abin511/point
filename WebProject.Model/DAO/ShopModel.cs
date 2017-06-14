using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    [Table("Shop")]
    [Serializable]
    public class ShopModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 店名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 店铺分类 见配置
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// logo地址
        /// </summary>
        public string LogoImage { get; set; }

        /// <summary>
        /// 列表图片地址
        /// </summary>
        public string AdImage { get; set; }

        /// <summary>
        /// 店铺图片 内页
        /// </summary>
        public string BannerImage { get; set; }

        /// <summary>
        /// 店铺简介
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 店铺状态 见枚举ShopStasus
        /// </summary>
        public ShopStasus Stasus { get; set; }

        /// <summary>
        /// 店铺地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 最高抵用金额
        /// </summary>
        public decimal MaxExchange { get; set; }

        /// <summary>
        /// 活动限额人数
        /// </summary>
        public int ActivityQuota { get; set; }

        /// <summary>
        /// 已参与人数
        /// </summary>
        public int UsedQuota { get; set; }

        /// <summary>
        /// 展示排序
        /// </summary>
        public byte OrderLevel { get; set; }
        /// <summary>
        /// 商品添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 商品修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
