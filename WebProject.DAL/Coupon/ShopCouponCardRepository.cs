using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 优惠券详细信息
    /// </summary>
    public class ShopCouponCardRepository : BaseRepository<ShopCouponCardModel>
    {
        public static bool Add(ShopCouponCardModel entity)
        {
            return AddEntity(entity).Id >= 1;
        }
        public static bool Update(ShopCouponCardModel entity)
        {
            return UpdateEntity(entity);
        }
        public static ShopCouponCardModel Get(int id)
        {
            using (var pointContext = new PointContexts())
            {
                return pointContext.ShopCouponCards.FirstOrDefault(m => m.Id == id);
            }
        }
    }
}
