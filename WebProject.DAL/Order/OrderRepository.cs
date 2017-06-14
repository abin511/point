using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    public class OrderRepository : BaseRepository<OrderModel>
    {
        public static OrderModel Add(OrderModel entity)
        {
            return AddEntity(entity);
        }

        public static bool Update(OrderModel entity)
        {
            return UpdateEntity(entity);
        }

        public static OrderModel Get(string orderNo)
        {
            using (var pointContext = new PointContexts())
            {
                return pointContext.Orders.FirstOrDefault(m => m.OrderNo == orderNo);
            }
        }
    }
}