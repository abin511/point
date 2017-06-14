using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 问卷反馈表
    /// </summary>
    [Table("QuestionFeedback")]
    [Serializable]
    public class QuestionFeedbackModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 互动新闻的ID
        /// </summary>
        public int NewsId { get; set; }
        /// <summary>
        /// 问卷ID
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// 回答问题的内容
        /// </summary>
        public string QuestionOption { get; set; }

        /// <summary>
        /// 推送时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
