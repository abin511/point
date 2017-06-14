using System.ComponentModel;

namespace WebProject.Model
{
    public enum ResultCode
    {
        /// <summary>
        /// 未知
        /// </summary>
        None = -1,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 错误
        /// </summary>
        Error = 1
    }
    public enum MemberStatus
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 无效
        /// </summary>
        Invalid = 1,
        /// <summary>
        /// 已删除
        /// </summary>
        Deleted = 2
    }
    /// <summary>
    /// 性别类型
    /// </summary>
    public enum GenderMenu : byte
    {
        /// <summary>
        /// 未输入
        /// </summary>
        None = 0,
        /// <summary>
        /// 男性
        /// </summary>
        Male = 1,
        /// <summary>
        /// 女性
        /// </summary>
        FaMale = 2
    }
    public enum NewsType
    {
        /// <summary>
        /// 资讯
        /// </summary>
        News = 1,
        /// <summary>
        /// 互动问答
        /// </summary>
        Question = 2
    }
    public enum NewsTemplateType
    {
        /// <summary>
        /// 1:1
        /// </summary>
        one_one = 1,
        /// <summary>
        /// 3:1
        /// </summary>
        three_one = 2
    }
    public enum QuestionType
    {
        /// <summary>
        /// 单选
        /// </summary>
        single = 1,
        /// <summary>
        /// 多选
        /// </summary>
        multiple = 2,
        /// <summary>
        /// 输入
        /// </summary>
        input = 3
    }
    /// <summary>
    /// 积分申请转让记录
    /// </summary>
    public enum ApplyType
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,
        /// <summary>
        /// 申请积分转让
        /// </summary>
        ScoreSell = 1,
        /// <summary>
        /// 申请提现
        /// </summary>
        Withdrawal = 2
    }
    /// <summary>
    /// 积分申请转让记录
    /// </summary>
    public enum ApplyStatus
    {
        /// <summary>
        /// 申请中
        /// </summary>
        Applying = 0,
        /// <summary>
        /// 已完成
        /// </summary>
        Completed = 1,
        /// <summary>
        /// 拒绝
        /// </summary>
        Deny = 2
    }
    /// <summary>
    /// 积分变动类型
    /// </summary>
    public enum ScoreChangeType
    {
        /// <summary>
        /// 增加分值
        /// </summary>
        Increase = 1,
        /// <summary>
        /// 减少分值
        /// </summary>
        Reduce = 2,
    }
    /// <summary>
    /// 账户操作类型
    /// </summary>
    public enum OperationType
    {
        [Description("出售积分")]
        ScoreSell = 1,
        [Description("参与互动")]
        QuestionFeedback = 2,
        [Description("分享好友")]
        NewsShare = 3,
        [Description("购买积分")]
        ScoreBuy = 4,
        [Description("微信提现")]
        FundingWithdrawal = 5,
    }
    public enum ShopStasus
    {
        /// <summary>
        /// 上架
        /// </summary>
        UnShelves = 1,
        /// <summary>
        /// 下架
        /// </summary>
        Shelves = 2
    }

    public enum CouponStatus
    {
        /// <summary>
        /// 未使用
        /// </summary>
        NotUse = 0,
        /// <summary>
        /// 已使用
        /// </summary>
        Used = 1,
        /// <summary>
        /// 无效
        /// </summary>
        Invalid = 2
    }
    public enum MemberFeedContentType
    {
        /// <summary>
        /// 资讯
        /// </summary>
        News = 1,
        /// <summary>
        /// 优惠券
        /// </summary>
        Coupon = 2
    }
}
