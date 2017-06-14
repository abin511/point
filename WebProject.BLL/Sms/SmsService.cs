using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebProject.DAL;
using WebProject.Model;

using CCPRestSDK;

namespace WebProject.BLL
{
    public class SmsService
    {
        public Result<dynamic> Send(string mobile, byte smsType)
        {
            int smsCode = GenerateSMSCode();
            var entity = new SmsModel()
            {
                MobilePhone = mobile,
                SmsType = smsType,
                SmsCode = smsCode,
                SmsStatus = 0,
                ExpireTime = DateTime.Now.AddMinutes(10),
                CreateTime = DateTime.Now
            };
            if (SmsRepository.Add(entity))
            {
                var account_id = ConfigurationManager.AppSettings["SMS_Account_Sid"];
                var account_token = ConfigurationManager.AppSettings["SMS_Account_Token"];
                var app_Id = ConfigurationManager.AppSettings["SMS_App_Id"];

                string result = string.Empty;

                CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();
                bool init = api.init("sandboxapp.cloopen.com", "8883");
                api.setAccount(account_id, account_token);
                api.setAppId(app_Id);
                try
                {
                    if (init)
                    {
                        string[] param = { smsCode.ToString(), "10分钟" };
                        Dictionary<string, object> retApiData = api.SendTemplateSMS(mobile, "125246", param);
                        result = GetDictionaryData(retApiData);
                    }
                    else
                    {
                        return new Result<dynamic>()
                        {
                            Code = ResultCode.Error,
                            Message = "初始化失败"
                        };
                    }
                }
                catch { }
                if (result.ToLower().Contains("statuscode=000000;statusmsg=成功"))
                {
                    /* 调用短信接口发送短信验证码 */
                    return new Result<dynamic>()
                    {
                        Code = ResultCode.Success,
                        Message = "验证码发送成功"
                    };
                }
            }
            return new Result<dynamic>()
            {
                Code = ResultCode.Error,
                Message = "验证码发送失败"
            };
        }

        public Result<dynamic> VerifySmsCode(string mobilePhone, byte smsType, int smsCode)
        {
            var entity = SmsRepository.Get(mobilePhone, smsType, smsCode);
            if (entity == null)
            {
                return new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "验证码不正确"
                };
            }
            if (DateTime.Now > entity.ExpireTime || entity.SmsStatus == 1)
            {
                return new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "验证码已过期"
                };
            }
            try
            {
                entity.SmsStatus = 1;
                SmsRepository.Update(entity);
            }
            catch { }
            return new Result<dynamic>()
            {
                Code = ResultCode.Success,
                Message = "验证码验证成功"
            };
        }

        private static int GenerateSMSCode()
        {
            return new Random().Next(1000, 9999);
        }

        private static string GetDictionaryData(Dictionary<string, object> data)
        {
            string ret = null;
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    ret += item.Key.ToString() + "={";
                    ret += GetDictionaryData((Dictionary<string, object>)item.Value);
                    ret += "};";
                }
                else
                {
                    ret += item.Key.ToString() + "=" + (item.Value == null ? "null" : item.Value.ToString()) + ";";
                }
            }
            return ret;
        }
    }
}
