using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 用户申请记录表
    /// </summary>
    [Table("MemberApply")]
    [Serializable]
    public class MemberApplyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户申请的类型 见枚举 ApplyType
        /// </summary>
        public ApplyType ApType { get; set; }

        /// <summary>
        /// 申请的额度
        /// </summary>
        public decimal ApValue { get; set; }
        /// <summary>
        /// 操作状态 见枚举 ApplyStatus
        /// </summary>
        public ApplyStatus Status { get; set; }
        /// <summary>
        /// 申请转让时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最终操作时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
