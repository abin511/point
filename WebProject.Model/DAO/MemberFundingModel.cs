using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 资金变动明细
    /// </summary>
    [Table("MemberFunding")]
    [Serializable]
    public class MemberFundingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 账户操作类型
        /// </summary>
        public OperationType OpType { get; set; } 
        /// <summary>
        /// 变动的额度
        /// </summary>
        public decimal OpValue { get; set; }
        /// <summary>
        /// 变动类型
        /// </summary>
        public ScoreChangeType ChangeType { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 变更时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
