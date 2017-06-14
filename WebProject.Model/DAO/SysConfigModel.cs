using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{
    /// <summary>
    /// 通用键值对配置表
    /// </summary>
    [Table("DictionaryConfig")]
    [Serializable]
    public class SysConfigModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 组名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 键名称
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// 键值对的值数据
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 键值对描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// 配置分类ID
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 配置所有者
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public int LastOpUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool IsActive { get; set; }
    }

    public class SysConfigMenu
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int Sort { get; set; }
    }
}
