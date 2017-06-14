using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Dynamic;

using WebProject.Model;
using WebProject.DAL;

namespace WebProject.BLL.Member
{
    public class MemberFeedService
    {
        public Result<dynamic> GetList(int memberId, int pageIndex)
        {
            //var feeds = MemberFeedRepository.GetMemberFeedList(memberId, pageIndex);
            //if(feeds== null || feeds.Count<=0)
            //{
            //    return new Result<dynamic>()
            //    {
            //        Code = ResultCode
            //    }
            //}
            return null;
        }
    }
}
