using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Model
{

    /// <summary>
    /// 短信验证码
    /// </summary>
    [Table("SMS")]
    [Serializable]
    public class SmsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string MobilePhone { get; set; }

        public byte SmsType { get; set; }

        public int SmsCode { get; set; }

        public byte SmsStatus { get; set; }

        public DateTime ExpireTime { get; set; }

        public DateTime CreateTime { get; set; }
    }
}