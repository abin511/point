using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 分享信息表
    /// </summary>
    [Table("Share")]
    [Serializable]
    public class ShareModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        /// <summary>
        /// 新闻ID
        /// </summary>
        public int NewsId { get; set; }
        /// <summary>
        /// 分享人ID
        /// </summary>
        public int ShareUserId { get; set; }
        /// <summary>
        /// 阅读人ID
        /// </summary>
        public int ReaderUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
