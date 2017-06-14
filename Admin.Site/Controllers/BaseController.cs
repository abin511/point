using System.Web.Mvc;

namespace Admin.Site.Controllers
{
    public class BaseController : Controller
    {
        private int _adminUserId = 0;

        /// <summary>
        /// 获取当前管理员的UserId
        /// </summary>
        /// <returns></returns>
        public int AdminUserId
        {
            get
            {
                if (_adminUserId == 0)
                {
                    _adminUserId = 511;
                }
                return _adminUserId;
            }

        }
    }
}