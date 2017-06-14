using System;
using System.Linq;
using System.Web.Mvc;
using WebProject.BLL;
using WebProject.Model;

namespace WebApi.Site.Controllers
{
    public class FundingController : BaseApi
    {
        public JsonResult GetList(int page_index = 1)
        {
            var ent = new QueryBase<MemberFundingModel>
            {
                UserId = base.UserId,
                PageIndex = page_index
            };
            FundingService.GetList(ent);
            return base.GetJosn(ent.DataList.Select(m => new
            {
                op_type = m.OpType,
                change_type = m.ChangeType,
                score = m.OpValue,
                remark = m.Remark,
                create_time = m.CreateTime
            }));
        }
        [HttpPost]
        public Result<int> Withdrawal(decimal amount,int userid)
        {
            return FundingService.WithdrawalApply(base.UserId, amount);
        }
    }
}