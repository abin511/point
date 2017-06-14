using System.Web.Mvc;

using WebProject.BLL;
using WebProject.Model;

namespace WebApi.Site.Controllers
{
    public class SmsController : BaseApi
    {
        [HttpPost]
        public JsonResult Send(string mobile, byte type)
        {
            if (string.IsNullOrWhiteSpace(mobile))
            {
                return PostJosn(new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "手机号不能为空"
                });
            }
            if (type != 1 && type != 2)
            {
                return PostJosn(new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "短信渠道不存在"
                });
            }
            return PostJosn(new SmsService().Send(mobile, type));
        }
    }
}