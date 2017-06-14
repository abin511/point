using System.Collections.Generic;
using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 互动问卷信息
    /// </summary>
    public class QuestionRepository : BaseRepository<QuestionModel>
    {
        public static bool Add(QuestionModel entity)
        {
            return AddEntity(entity).Id >= 1;
        }
        public static bool Update(QuestionModel entity)
        {
            return UpdateEntity(entity);
        }
        public static QuestionModel Get(int id)
        {
            using (var context = new PointContexts())
            {
                return context.Questions.FirstOrDefault(m => m.Id == id);
            }
        }
        public static List<QuestionModel> GetList(int newsId)
        {
            using (var context = new PointContexts())
            {
                return context.Questions.Where(m => m.NewsId == newsId).ToList();
            }
        }
    }
}
