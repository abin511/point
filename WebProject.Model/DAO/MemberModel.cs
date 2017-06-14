using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 会员信息表
    /// </summary>
    [Table("Member")]
    [Serializable]
    public class MemberModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string Portrait { get; set; }

        public string EncryptedPwd { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 性别(0:NONE, 1:MALE, 2:FAMALE) 见枚举GenderMenu
        /// </summary>
        public GenderMenu Gender { get; set; }

        /// <summary>
        /// 所在地区
        /// </summary>
        public string LocationArea { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal AccountBalance { get; set; }

        /// <summary>
        /// 账户总额度
        /// </summary>
        public decimal AmountTotal { get; set; }

        /// <summary>
        /// 已提现金额
        /// </summary>
        public decimal AmountWithdrawn { get; set; }

        /// <summary>
        /// 总抵用金
        /// </summary>
        public decimal TotalScore { get; set; }

        /// <summary>
        /// 申请提现抵用金
        /// </summary>
        public decimal TotalWithdrawScore { get; set; }

        public string JpushId { get; set; }

        public string OpenidWxOpen { get; set; }

        /// <summary>
        /// 微信公众号
        /// </summary>
        public string OpenidWxMp { get; set; }

        /// <summary>
        /// 数据状态 见枚举RecordStatus
        /// </summary>
        public MemberStatus Status { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
