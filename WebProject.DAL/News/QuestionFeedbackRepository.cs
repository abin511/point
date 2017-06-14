using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 互动问卷反馈信息
    /// </summary>
    public class QuestionFeedbackRepository : BaseRepository<QuestionFeedbackModel>
    {
        public static int Add(QuestionFeedbackModel entity)
        {
            return AddEntity(entity).Id;
        }
        public static bool Exists(int newsId,int userId)
        {
            using (var context = new PointContexts())
            {
                return context.QuestionFeedbacks.Any(m => m.NewsId ==newsId && m.UserId == userId);
            }
        }
    }
}
