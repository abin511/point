using System;
using System.Web.Mvc;
using WebProject.BLL;
using WebProject.Model;

namespace WebApi.Site.Controllers
{
    public class MemberController : BaseApi
    {
        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="gender"></param>
        /// <param name="birthday"></param>
        /// <param name="locationArea"></param>
        /// <param name="mobile"></param>
        /// <param name="smscode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Register(string displayName, byte gender, DateTime birthday, string locationArea, string mobile, int smscode, string password)
        {
            var json = new JsonResult();
            if (string.IsNullOrWhiteSpace(displayName))
            {
                json.Data = new Result<bool>()
                {
                    Code = ResultCode.Error,
                    Message = "昵称不能为空",
                    Data = false
                };
                return json;
            }
            if (string.IsNullOrWhiteSpace(locationArea))
            {
                json.Data = new Result<bool>()
                {
                    Code = ResultCode.Error,
                    Message = "地区不能为空",
                    Data = false
                };
                return json;
            }
            if (string.IsNullOrWhiteSpace(mobile))
            {
                json.Data = new Result<bool>()
                {
                    Code = ResultCode.Error,
                    Message = "手机号不能为空",
                    Data = false
                };
                return json;
            }
            if (smscode <= 0)
            {
                json.Data = new Result<bool>()
                {
                    Code = ResultCode.Error,
                    Message = "短信验证码不能为空",
                    Data = false
                };
                return json;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                json.Data = new Result<bool>()
                {
                    Code = ResultCode.Error,
                    Message = "密码不能为空",
                    Data = false
                };
                return json;
            }
            GenderMenu memberGender;
            switch (gender)
            {
                case 1: memberGender = GenderMenu.Male; break;
                case 2: memberGender = GenderMenu.FaMale; break;
                default: memberGender = GenderMenu.None; break;
            }
            var memberService = new MemberService();
            json.Data = memberService.Register(new MemberRegisterRequest()
            {
                display_name = displayName,
                gender = memberGender,
                birthday = birthday,
                location_area = locationArea,
                mobile_phone = mobile,
                mobile_code = smscode,
                pass_word = password
            });
            return json;
        }

        /*
         * 会员登录
         */
        public JsonResult Login(string mobile, string password)
        {
            var json = new JsonResult();
            if (string.IsNullOrWhiteSpace(mobile))
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Success,
                    Message = "手机号不能为空"
                };
                return json;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Success,
                    Message = "密码不能为空"
                };
                return json;
            }
            var memberService = new MemberService();
            json.Data = memberService.Login(mobile, password);
            return json;
        }

        /*
         * 获取会员信息
         */
        public JsonResult GetMember()
        {
            var json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var memberService = new MemberService();
            var member = memberService.GetCurrentMember();
            if (member == null)
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "获取用户信息失败"
                };
                return json;
            }
            json.Data = new Result<dynamic>()
            {
                Code = ResultCode.Success,
                Message = "获取用户信息成功",
                Data = member
            };
            return json;
        }

        /*
         * 找回密码
         */
        public JsonResult ForgotPassword(string mobile, int smscode, string password)
        {
            var json = new JsonResult();
            if (string.IsNullOrWhiteSpace(mobile))
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "手机号不能为空"
                };
            }
            if (smscode < 1000 && smscode > 9999)
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "验证码不能为空"
                };
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "密码不能为空"
                };
            }
            var member = new MemberService();
            json.Data = member.ForgotPassword(mobile, smscode, password);
            return json;
        }

        public JsonResult Modify(string displayName, byte gender, DateTime birthday, string portrait, string locationArea)
        {
            var json = new JsonResult();
            if (string.IsNullOrWhiteSpace(displayName))
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "请填写昵称"
                };
                return json;
            }
            if (gender != 1 && gender != 2)
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "请选择性别"
                };
                return json;
            }
            if (string.IsNullOrWhiteSpace(portrait))
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "请上传头像"
                };
                return json;
            }
            if (string.IsNullOrWhiteSpace(portrait))
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "请填写所在地"
                };
                return json;
            }
            GenderMenu memberGender;
            switch (gender)
            {
                case 1: memberGender = GenderMenu.Male; break;
                case 2: memberGender = GenderMenu.FaMale; break;
                default: memberGender = GenderMenu.None; break;
            }
            var member = new MemberService();
            json.Data = member.Modify(new MemberModifyRequest()
            {
                display_name = displayName,
                gender = memberGender,
                portrait = portrait,
                birthday = birthday,
                location_area = locationArea
            });
            return json;
        }

        public JsonResult ModifyDisplayName(string displayName)
        {
            var json = new JsonResult();
            if (string.IsNullOrWhiteSpace(displayName))
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "请填写用户昵称"
                };
                return json;
            }
            var member = new MemberService();
            json.Data = member.ModifyDisplayName(displayName);
            return json;
        }

        /*
         * 获取给用户推送的Feeds
         */
        public object GetMemberFeeds(int pageIndex)
        {
            return new { code = 0, msg = "", data = new Array[0] };
        }
    }
}