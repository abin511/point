using System;
using System.Linq;
using System.Web.Mvc;
using WebProject.BLL;
using WebProject.Model;

namespace WebApi.Site.Controllers
{
    public class HomeController : BaseApi
    {
        //[Route("demo/get")]
        //[HttpGet]
        public JsonResult GetList(int page_index = 1)
        {
            var ent = new QueryBase<NewsModel>
            {
                UserId = base.UserId,
                PageIndex = page_index
            };
            NewsService.GetHomeFeedList(ent);
            return base.GetJosn(ent.DataList.Select(m => new
            {
                id = m.Id,
                image = m.Image,
                title = m.Title,
                summary = m.Summary,
                link_url = m.LinkUrl,
                attr = m.Attr,
                news_type = m.NewsType,
                news_tag = m.NewsTag,
                template_type = m.TemplateType
            }));
        }
    }
}