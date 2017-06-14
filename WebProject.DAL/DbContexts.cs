using System.Data.Entity;
using WebProject.Model;

namespace WebProject.DAL
{
    public class PointContexts : DbContext
    {
        public PointContexts(): base("conn_point")
        {
            Database.SetInitializer<PointContexts>(null);
        }
        public void FixEfProviderServicesProblem() {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        /// <summary>
        /// 通用键值对配置表
        /// </summary>
        public DbSet<SysConfigModel> SysConfigs { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public DbSet<MemberModel> Members { get; set; }
        /// <summary>
        /// 新闻信息
        /// </summary>
        public DbSet<NewsModel> News { get; set; }
        /// <summary>
        /// 咨询收藏信息
        /// </summary>
        public DbSet<MemberFavoriteModel> Favorites { get; set; }
        /// <summary>
        /// 问卷互动信息
        /// </summary>
        public DbSet<QuestionModel> Questions { get; set; }
        /// <summary>
        /// 问卷反馈信息
        /// </summary>
        public DbSet<QuestionFeedbackModel> QuestionFeedbacks { get; set; }
        /// <summary>
        /// 问卷分享信息
        /// </summary>
        public DbSet<ShareModel> Shares { get; set; }
        /// <summary>
        /// 用户申请记录
        /// </summary>
        public DbSet<MemberApplyModel> MemberApplys { get; set; }
        /// <summary>
        /// 用户账户记录
        /// </summary>
        public DbSet<MemberFundingModel> MemberFundings { get; set; }
        /// <summary>
        /// 店铺信息
        /// </summary>
        public DbSet<ShopModel> Shops { get; set; }
        /// <summary>
        /// 店铺优惠券基本信息
        /// </summary>
        public DbSet<ShopCouponInfoModel> ShopCouponInfos { get; set; }
        /// <summary>
        /// 店铺优惠券明细
        /// </summary>
        public DbSet<ShopCouponCardModel> ShopCouponCards { get; set; }

        /// <summary>
        /// 短信验证码日志
        /// </summary>
        public DbSet<SmsModel> Sms { get; set; }

        public DbSet<OrderModel> Orders { get; set; }
    }
}
