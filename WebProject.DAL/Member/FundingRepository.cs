using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 账户明细
    /// </summary>
    public class FundingRepository : BaseRepository<MemberFundingModel>
    {
        public static bool Add(MemberFundingModel entity)
        {
            return AddEntity(entity).Id >= 1;
        }
        public static void GetList(QueryBase<MemberFundingModel> entity)
        {
            using (var context = new PointContexts())
            {
                entity.DataList = context.MemberFundings.Where(m => m.UserId == entity.UserId).OrderBy(m=>m.Id).Skip(entity.PageSize*(entity.PageIndex - 1)).Take(entity.PageSize).ToList();
            }
        }
    }
}
