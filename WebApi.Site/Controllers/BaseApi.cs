using System;
using System.Web.Mvc;
using WebProject.BLL;
using WebProject.Model;

namespace WebApi.Site.Controllers
{
    public class BaseApi : Controller
    {
        public int UserId => new MemberService().GetCurrentMemberId();
        /// <summary>
        /// get请求 返回jsonResult
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected JsonResult GetJosn(Object data)
        {
            return new JsonResult() { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        /// <summary>
        /// post请求 返回jsonResult
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected JsonResult PostJosn(Object data)
        {
            return new JsonResult() { Data = data, JsonRequestBehavior = JsonRequestBehavior.DenyGet };
        }
        /// <summary>
        /// 基于泛型T类型返回值的方法委托
        /// </summary>
        /// <returns></returns>
        public delegate T WrapDelegate<T>();
        /// <summary>
        /// 执行Get操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        protected Result<T> Wrap<T>(WrapDelegate<T> target)
        {
            var result = new Result<T>();
            try
            {
                T entity = target();
                result.Code = null == entity ? ResultCode.Error : ResultCode.Success;
                result.Message = result.Code == ResultCode.Success ? "" : "操作失败";
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.Code = ResultCode.Error;
                result.Message = "系统异常!" + ex.Message;

            }
            return result;
        }
    }
}