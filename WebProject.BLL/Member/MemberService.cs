using System;
using WebProject.Common;
using WebProject.DAL;
using WebProject.Model;

namespace WebProject.BLL
{
    public class MemberService
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public Result<dynamic> Register(MemberRegisterRequest ent)
        {
            #region 数据验证
            var result = new Result<dynamic>();
            if (ent.mobile_phone.IsNullOrEmpty())
            {
                result.Message = "用户手机号码不能为空";
                return result;
            }
            if (ent.display_name.IsNullOrEmpty())
            {
                result.Message = "用户昵称不能为空";
                return result;
            }
            var exists = MemberRepository.Exists(ent.mobile_phone);
            if (exists.HasValue)
            {
                if (exists.Value)
                {
                    result.Message = "存在相同的手机号码";
                }
            }
            else
            {
                result.Message = "查询数据库异常";
            }
            if (!string.IsNullOrEmpty(result.Message))
            {
                result.Code = ResultCode.Error;
                return result;
            }

            var smsService = new SmsService();
            var sms = smsService.VerifySmsCode(ent.mobile_phone, 1, ent.mobile_code);
            if (sms.Code != ResultCode.Success)
            {
                return sms;
            }

            #endregion

            MemberModel entity = new MemberModel()
            {
                MobilePhone = ent.mobile_phone,
                Portrait = string.Empty,
                EncryptedPwd = SecurityHelper.Encrypt(ent.pass_word),
                DisplayName = ent.display_name,
                Gender = ent.gender,
                LocationArea = ent.location_area,
                Birthday = ent.birthday,
                AccountBalance = 0,
                AmountTotal = 0,
                AmountWithdrawn = 0,
                TotalScore = 0,
                TotalWithdrawScore = 0,
                JpushId = string.Empty,
                OpenidWxMp = string.Empty,
                OpenidWxOpen = string.Empty,
                Status = 0,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            var member = MemberRepository.Add(entity);
            if (member.Id > 0)
            {
                string token = Guid.NewGuid().ToString().Replace("-", "").ToLower();
                var cache = new RedisCacheHelper<Model.Member>();
                cache.Set(token, new Model.Member() { id = entity.Id, display_name = entity.DisplayName }, TimeSpan.FromDays(5));

                result.Message = "注册成功";
                result.Code = ResultCode.Success;
                result.Data = new MemberLoginResponse
                {
                    id = member.Id,
                    mobile = member.MobilePhone,
                    portrait = member.Portrait,
                    display_name = member.DisplayName,
                    gender = member.Gender,
                    location_area = member.LocationArea,
                    birthday = member.Birthday,
                    account_balance = member.AccountBalance,
                    amount_total = member.AmountTotal,
                    amount_withdrawn = member.AmountWithdrawn,
                    total_score = member.TotalScore,
                    total_withdraw_score = member.TotalWithdrawScore,
                    token = token
                };
            }
            else
            {
                result.Code = ResultCode.Error;
                result.Message = "数据库操作异常";
            }
            return result;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public Result<dynamic> Login(string mobile, string password)
        {
            #region 数据验证
            var result = new Result<dynamic>();
            if (mobile.IsNullOrEmpty())
            {
                result.Code = ResultCode.Error;
                result.Message = "登录账号不能为空";
                return result;
            }
            if (password.IsNullOrEmpty())
            {
                result.Code = ResultCode.Error;
                result.Message = "登录密码不能为空";
                return result;
            }
            #endregion

            var encryptedPwd = SecurityHelper.Encrypt(password);

            var member = MemberRepository.Get(mobile);
            if (member != null)
            {
                if (member.EncryptedPwd != encryptedPwd)
                {
                    result.Code = ResultCode.Error;
                    result.Message = "账号或者密码错误";
                }
                string token = Guid.NewGuid().ToString().Replace("-", "").ToLower();
                var cache = new RedisCacheHelper<Model.Member>();
                cache.Set(token, new Model.Member() { id = member.Id, display_name = member.DisplayName }, TimeSpan.FromDays(5));

                result.Code = ResultCode.Success;
                result.Message = "登录成功";
                result.Data = new MemberLoginResponse
                {
                    id = member.Id,
                    mobile = member.MobilePhone,
                    portrait = member.Portrait,
                    display_name = member.DisplayName,
                    gender = member.Gender,
                    location_area = member.LocationArea,
                    birthday = member.Birthday,
                    account_balance = member.AccountBalance,
                    amount_total = member.AmountTotal,
                    amount_withdrawn = member.AmountWithdrawn,
                    total_score = member.TotalScore,
                    total_withdraw_score = member.TotalWithdrawScore,
                    token = token
                };
            }
            else
            {
                result.Code = ResultCode.Error;
                result.Message = "数据库操作异常";
            }
            return result;
        }
        /// <summary>
        /// 修改用户昵称
        /// </summary>
        /// <returns></returns>
        public Result<dynamic> Modify(MemberModifyRequest model)
        {
            var result = new Result<dynamic>();

            var member = this.GetCurrentMember();
            if (member == null || member.id <= 0)
            {
                result.Code = ResultCode.Error;
                result.Message = "用户未登录";
                return result;
            }
            #region 数据验证

            var ent = MemberRepository.Get(member.id);
            if (ent == null)
            {
                result.Code = ResultCode.Error;
                result.Message = "获取用户信息失败";
                return result;
            }
            #endregion

            #region 用户信息赋值
            if (!model.portrait.IsNullOrEmpty())
            {
                ent.Portrait = model.portrait;
            }
            if (!model.display_name.IsNullOrEmpty())
            {
                ent.DisplayName = model.display_name;
            }
            if (model.gender != GenderMenu.None)
            {
                ent.Gender = model.gender;
            }
            if (!model.location_area.IsNullOrEmpty())
            {
                ent.LocationArea = model.location_area;
            }
            if (model.birthday != null)
            {
                ent.Birthday = model.birthday;
            }
            #endregion

            var dbResult = MemberRepository.Update(ent);
            if (dbResult)
            {
                result.Code = ResultCode.Success;
                result.Message = "修改个人信息成功";
            }
            else
            {
                result.Code = ResultCode.Error;
                result.Message = "数据库操作异常";
            }
            return result;
        }

        public Result<dynamic> ModifyDisplayName(string displayName)
        {
            var result = new Result<dynamic>();
            var member = this.GetCurrentMember();
            if (member == null || member.id <= 0)
            {
                result.Code = ResultCode.Error;
                result.Message = "用户未登录";
                return result;
            }
            var ent = MemberRepository.Get(member.id);
            if (ent == null)
            {
                result.Code = ResultCode.Error;
                result.Message = "获取用户信息失败";
                return result;
            }
            ent.DisplayName = displayName;

            var dbResult = MemberRepository.Update(ent);
            if (dbResult)
            {
                result.Code = ResultCode.Success;
                result.Message = "修改昵称成功";
            }
            else
            {
                result.Code = ResultCode.Error;
                result.Message = "数据库操作异常";
            }
            return result;
        }

        public Result<dynamic> ForgotPassword(string mobile, int smscode, string password)
        {
            var member = MemberRepository.Get(mobile);
            if (member == null)
            {
                return new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "手机号不存在"
                };
            }
            var smsService = new SmsService();
            var sms = smsService.VerifySmsCode(mobile, 2, smscode);
            if (sms.Code != ResultCode.Success)
            {
                return sms;
            }
            member.EncryptedPwd = SecurityHelper.Encrypt(password);
            if (MemberRepository.Update(member))
            {
                return new Result<dynamic>()
                {
                    Code = ResultCode.Success,
                    Message = "密码找回成功"
                };
            }
            return new Result<dynamic>()
            {
                Code = ResultCode.Error,
                Message = "密码找回失败"
            };
        }

        public bool UpdateUserBalance(int memberId, int totalFee)
        {
            var member = MemberRepository.Get(memberId);
            if (member == null)
            {
                return false;
            }
            member.AccountBalance = member.AccountBalance + totalFee / 100M;
            return MemberRepository.Update(member);
        }

        public bool IsAuthenticated()
        {
            var member = this.GetCurrentMember();
            if (member == null)
            {
                return false;
            }
            return true;
        }
        public int GetCurrentMemberId()
        {
            string token = System.Web.HttpContext.Current.Request.Headers["token"];
            if (string.IsNullOrWhiteSpace(token))
            {
                return 0;
            }
            var client = new RedisCacheHelper<Model.Member>();
            var cache = client.Get(token);
            return cache == null || cache.id <= 0 ? 0 : cache.id;
        }
        public MemberLoginResponse GetCurrentMember()
        {
            string token = System.Web.HttpContext.Current.Request.Headers["token"];
            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }
            var client = new RedisCacheHelper<Model.Member>();
            var cache = client.Get(token);
            if (cache == null || cache.id <= 0)
            {
                return null;
            }
            var member = MemberRepository.Get(cache.id);
            if (member == null)
            {
                return null;
            }
            return new MemberLoginResponse
            {
                id = member.Id,
                mobile = member.MobilePhone,
                portrait = member.Portrait,
                display_name = member.DisplayName,
                gender = member.Gender,
                location_area = member.LocationArea,
                birthday = member.Birthday,
                account_balance = member.AccountBalance,
                amount_total = member.AmountTotal,
                amount_withdrawn = member.AmountWithdrawn,
                total_score = member.TotalScore,
                total_withdraw_score = member.TotalWithdrawScore,
                token = token
            };
        }
    }
}