using System.Collections.Generic;
using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 个人中心推送信息
    /// </summary>
    public class MemberFeedRepository : BaseRepository<MemberFeedModel>
    {
        public static bool Add(MemberFeedModel entity)
        {
            return AddEntity(entity).Id >= 1;
        }
        public static List<MemberFeedModel> GetMemberFeedList(int memberId, int pageIndex, int pageSize = 10)
        {
            const string sqlQuery = @"SELECT * FROM [dbo].[MemberFeed] WITH(NOLOCK) WHERE UserId = {0}";
            using (var context = new PointContexts())
            {
                var query = context.Database.SqlQuery<MemberFeedModel>(sqlQuery, memberId);
                return query.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            }
        }
    }
}
