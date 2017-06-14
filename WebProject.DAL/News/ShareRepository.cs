using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 互动问卷分享信息
    /// </summary>
    public class ShareRepository : BaseRepository<ShareModel>
    {
        public static bool Add(ShareModel entity)
        {
            return AddEntity(entity).Id >= 1;
        }
        public static ShareModel Get(int id)
        {
            using (var context = new PointContexts())
            {
                return context.Shares.FirstOrDefault(m => m.Id == id);
            }
        }
    }
}
