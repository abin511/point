using System.Web.Mvc;
using WebProject.BLL;
using WebProject.Model;

namespace Admin.Site.Controllers
{
    public class SysConfigController : BaseController
    {
        private static readonly object AsyncLock = new object();

        public ActionResult List(SysConfigList model)
        {
            if (!string.IsNullOrEmpty(model.Search))
            {
                model.Id = -1;
                model.Search = Server.UrlDecode(model.Search.Trim());
            }
            model.Id = string.IsNullOrEmpty(model.Search) && model.Id == -1 ? 0 : model.Id;
            model.PageSize = 20;
            SysConfigService.GetList(model);
            return View(model);
        }
        public ActionResult Create(int id = 0)
        {
            return View(new SysConfigModel() { TypeId = id });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SysConfigModel model)
        {
            model.LastOpUserId = base.AdminUserId;
            lock (AsyncLock)
            {
                var result = SysConfigService.Add(model);
                if (result.Code == ResultCode.Success)
                {
                    return RedirectToAction("List", new { id = model.TypeId });
                }
                else
                {
                    ViewData["Message"] = "创建失败！" + result.Message;
                    return View(model);
                }
            }
        }
        public ActionResult Update(string keyName)
        {
            var result = SysConfigService.GetByKeyName(keyName, false);
            if (result == null)
                return RedirectToAction("Create");
            return View(result);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(SysConfigModel model)
        {
            model.LastOpUserId = base.AdminUserId;
            var result = SysConfigService.Update(model);
            if (result.Code == ResultCode.Success)
            {
                return RedirectToAction("List", new { id = model.TypeId });
            }
            else
            {
                ViewData["Message"] = "修改失败！" + result.Message;
                return View(model);
            }
        }
	}
}