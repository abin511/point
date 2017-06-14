using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 问卷表
    /// </summary>
    [Table("Question")]
    [Serializable]
    public class QuestionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int NewsId { get; set; }

        /// <summary>
        /// 问答图片地址
        /// </summary>
        public string QuestionImage { get; set; }

        /// <summary>
        /// 问题类型 见枚举QuestionType
        /// </summary>
        public QuestionType QuestionType { get; set; }

        /// <summary>
        /// 问卷选项
        /// </summary>
        public string QuestionOption { get; set; }
        /// <summary>
        /// 问卷的分值（抵用金）
        /// </summary>
        public decimal QuestionScore { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 问卷发布时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 问卷修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
