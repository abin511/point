using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.BLL;
using WebProject.Model;

namespace WebApi.Site.Controllers
{
    public class QuestionController : BaseApi
    {
        public JsonResult Get(int id)
        {
            var list = QuestionService.GetList(id);
            return base.GetJosn(list.Select(m => new
            {
                question_image = m.QuestionImage,
                question_type = m.QuestionType,
                question_option = m.QuestionOption
            }));
        }
        [HttpPost]
        public Result<int> AddFeedback(int news_id, string feedback)
        {
            return QuestionFeedbackService.Add(new QuestionFeedbackModel()
            {
                UserId = base.UserId,
                NewsId = news_id,
                QuestionOption = HttpUtility.UrlDecode(feedback),
                CreateTime = DateTime.Now
            });
        }
    }
}