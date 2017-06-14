using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 优惠券基本信息
    /// </summary>
    public class ShopCouponInfoRepository : BaseRepository<ShopCouponInfoModel>
    {
        public static bool Add(ShopCouponInfoModel entity)
        {
            return AddEntity(entity).Id >= 1;
        }
        public static bool Update(ShopCouponInfoModel entity)
        {
            return UpdateEntity(entity);
        }
        public static ShopCouponInfoModel Get(int id)
        {
            using (var pointContext = new PointContexts())
            {
                return pointContext.ShopCouponInfos.FirstOrDefault(m => m.Id == id);
            }
        }
    }
}
