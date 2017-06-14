using System.Web.Mvc;
using WebProject.BLL;
using WebProject.Model;

namespace WebApi.Site.Controllers
{
    public class ScoreController : BaseApi
    {
        [HttpPost]
        public Result<decimal> Sell(decimal score)
        {
            return ScoreService.ScoreSellApply(base.UserId, score);
        }
    }
}