using System;
using WebProject.DAL;
using WebProject.Model;

namespace WebProject.BLL
{
    public static class FundingService
    {
        /// <summary>
        /// 用户账户明细列表
        /// </summary>
        /// <returns></returns>
        public static void GetList(QueryBase<MemberFundingModel> ent)
        {
            FundingRepository.GetList(ent);
        }
        /// <summary>
        /// 会员申请提现
        /// </summary>
        /// <returns></returns>
        public static Result<int> WithdrawalApply(int userId, decimal amount)
        {
            #region 数据验证
            var result = new Result<int>();
            if (userId <= 0)
            {
                result.Message = "用户信息无效";
                return result;
            }
            if (amount <= 0)
            {
                result.Message = "申请提现的金额无效";
                return result;
            }
            #endregion

            //添加用户提现申请记录
            var iRet = ApplyRepository.Add(new MemberApplyModel()
            {
                UserId = userId,
                ApType = ApplyType.Withdrawal,
                ApValue = amount,
                Status = ApplyStatus.Applying,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            });
            if (iRet > 0)
            {
                result.Code = ResultCode.Success;
                result.Data = iRet;
            }
            else
            {
                result.Code = ResultCode.Error;
                result.Message = "提交提现申请失败";
            }
            return result;
        }
    }
}
