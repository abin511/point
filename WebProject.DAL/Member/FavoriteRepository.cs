using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 我的收藏信息
    /// </summary>
    public class FavoriteRepository : BaseRepository<MemberFavoriteModel>
    {
        public static int Add(MemberFavoriteModel entity)
        {
            return AddEntity(entity).Id;
        }
        public static void GetFavoriteList(QueryBase<NewsModel> entity)
        {
            const string sqlQuery = @"SELECT A.* FROM [dbo].[News] AS A WITH(NOLOCK) JOIN [dbo].[MemberFavorite] AS B  WITH(NOLOCK) ON A.Id = B.NewsId WHERE B.UserId = {0}";
            using (var context = new PointContexts())
            {
                var query = context.Database.SqlQuery<NewsModel>(sqlQuery, entity.UserId);
                entity.DataList = query.Skip(entity.PageSize * (entity.PageIndex - 1)).Take(entity.PageSize).ToList();
            }
        }
        public static int Count(int userId)
        {
            using (var context = new PointContexts())
            {
                var query = context.Favorites.Count(m => m.UserId == userId);
                return query;
            }
        }
        public static int Count(int userId,int newId)
        {
            using (var context = new PointContexts())
            {
                var query = context.Favorites.Count(m => m.UserId == userId && m.NewsId == newId);
                return query;
            }
        }
    }
}
