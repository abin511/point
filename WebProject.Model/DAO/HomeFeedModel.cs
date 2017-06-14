using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 首页新闻推送表
    /// </summary>
    [Table("HomeFeed")]
    [Serializable]
    public class HomeFeedModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 新闻ID
        /// </summary>
        public int NewsId { get; set; }
        /// <summary>
        /// 推送时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
