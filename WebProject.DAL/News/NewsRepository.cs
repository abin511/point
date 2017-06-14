using System.Collections.Generic;
using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 新闻信息
    /// </summary>
    public class NewsRepository : BaseRepository<NewsModel>
    {
        public static bool Add(NewsModel entity)
        {
            return AddEntity(entity).Id >= 1;
        }
        public static bool Update(NewsModel entity)
        {
            return UpdateEntity(entity);
        }
        public static NewsModel Get(int id)
        {
            using (var context = new PointContexts())
            {
                return context.News.FirstOrDefault(m => m.Id == id);
            }
        }
        public static List<NewsModel> GetList(List<int> ids)
        {
            using (var context = new PointContexts())
            {
                return context.News.Where(m => ids.Contains(m.Id)).ToList();
            }
        }
        public static void GetHomeFeedList(QueryBase<NewsModel> entity)
        {
            const string sqlQuery = @"SELECT A.* FROM [dbo].[News] AS A WITH(NOLOCK) JOIN [dbo].[HomeFeed] AS B  WITH(NOLOCK) ON A.Id = B.NewsId WHERE B.UserId = {0} ";
            using (var context = new PointContexts())
            {
                var query = context.Database.SqlQuery<NewsModel>(sqlQuery, entity.UserId);
                entity.DataList = query.Skip(entity.PageSize * (entity.PageIndex - 1)).Take(entity.PageSize).ToList();
            }
        }
    }
}
