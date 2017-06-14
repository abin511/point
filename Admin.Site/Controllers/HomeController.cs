using System.Web.Mvc;

namespace Admin.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Introduction()
        {
            return Content("这是后台管理系统");
        }
    }
}