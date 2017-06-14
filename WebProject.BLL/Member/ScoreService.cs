using System;
using WebProject.DAL;
using WebProject.Model;

namespace WebProject.BLL
{
    public static class ScoreService
    {
        /// <summary>
        /// 会员积分转让申请
        /// </summary>
        /// <returns></returns>
        public static Result<decimal> ScoreSellApply(int userId, decimal score)
        {
            #region 数据验证
            var result = new Result<decimal>();
            if (userId <= 0)
            {
                result.Message = "用户信息无效";
                return result;
            }
            
            var memberInfo = MemberRepository.Get(userId);
            if (memberInfo == null)
            {
                result.Message = "会员信息无效";
                return result;
            }
            memberInfo.TotalWithdrawScore += score;
            if (score <= 0 || memberInfo.TotalWithdrawScore > memberInfo.TotalScore)
            {
                result.Message = "转让的积分数量无效";
                return result;
            }
            #endregion

            var dbResult = MemberRepository.Update(memberInfo);
            if (dbResult)
            {
                result.Code = ResultCode.Success;
                result.Data = memberInfo.TotalWithdrawScore;
                //添加用户积分申请记录
                ApplyRepository.Add(new MemberApplyModel()
                {
                    UserId = userId,
                    ApType = ApplyType.ScoreSell,
                    ApValue = score,
                    Status = ApplyStatus.Applying, 
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                });
            }
            else
            {
                result.Code = ResultCode.Error;
                result.Message = "数据库操作异常";
            }
            return result;
        }
    }
}
