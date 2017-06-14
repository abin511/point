using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebProject.BLL;
using WebProject.Common;
using WebProject.Model;

namespace WebApi.Site.Controllers
{
    public class NewsController : BaseApi
    {
        public JsonResult Get(int id = 0)
        {
            var model = NewsService.Get(id);
            if (model == null) return null;

            var relationList = new List<NewsModel>();
            if (!model.RelationIds.IsNullOrEmpty())
            {
                var ids = model.RelationIds.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                relationList = NewsService.GetList(ids.Select(int.Parse).ToList());
            }
            return base.GetJosn(new
            {
                title = model.Title,
                intro = model.Intro,
                attr = model.Attr,
                relation_news = relationList.IsNullOrEmpty()? null: relationList.Select(m => new
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
                })
            });
        }
    }
}