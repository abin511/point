using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class ShopRepository : BaseRepository<ShopModel>
    {
        public static bool Add(ShopModel entity)
        {
            return AddEntity(entity).Id >= 1;
        }
        public static bool Update(ShopModel entity)
        {
            return UpdateEntity(entity);
        }
        public static ShopModel Get(int id)
        {
            using (var context = new PointContexts())
            {
                return context.Shops.FirstOrDefault(m => m.Id == id);
            }
        }
        public static void GetShopList(ShopRequest entity)
        {
            using (var context = new PointContexts())
            {
                var query = context.Shops.Where(m => m.Category == entity.Category);
                entity.DataList = query.Skip(entity.PageSize * (entity.PageIndex - 1)).Take(entity.PageSize).ToList();
            }
        }
    }
}
