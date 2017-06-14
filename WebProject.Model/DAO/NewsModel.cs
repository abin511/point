using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 资讯表
    /// </summary>
    [Table("News")]
    [Serializable]
    public class NewsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 新闻图片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 新闻摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 新闻简介
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// link_url：news_type = 1 的时候是新闻资讯 这里的link_url地址是外链地址，news_type = 2 的时候是互动反馈，这里的link_url地址是产品官网地址
        /// </summary>
        public string LinkUrl { get; set; }

        /// <summary>
        /// 模板类型 见枚举NewsTemplateType
        /// </summary>
        public NewsTemplateType TemplateType { get; set; }

        /// <summary>
        /// 新闻类型 见枚举NewsType  1 外链新闻  2 互动广告
        /// </summary>
        public NewsType NewsType { get; set; }

        /// <summary>
        /// 新闻标签 自定义输入
        /// </summary>
        public string NewsTag { get; set; }
        /// <summary>
        /// 新闻的扩展属性
        /// </summary>
        public string Attr { get; set; }

        /// <summary>
        /// 关联的新闻ID列表 英文逗号分割[2,345,456,778]
        /// </summary>
        public string RelationIds { get; set; }

        /// <summary>
        /// 发布人ID
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
