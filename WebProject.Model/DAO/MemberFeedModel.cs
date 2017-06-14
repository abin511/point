using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 个人中心推送表
    /// </summary>
    [Table("MemberFeed")]
    [Serializable]
    public class MemberFeedModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 内容ID
        /// </summary>
        public int ContentId { get; set; }
        /// <summary>
        /// 内容的类型 见枚举MemberFeedContentType
        /// </summary>
        public MemberFeedContentType ContentType { get; set; }
        /// <summary>
        /// 推送时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
