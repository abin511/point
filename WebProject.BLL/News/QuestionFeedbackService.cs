using System;
using System.Collections.Generic;
using WebProject.Common;
using WebProject.DAL;
using WebProject.Model;

namespace WebProject.BLL
{
    public static class QuestionFeedbackService
    {
        /// <summary>
        /// 回答新闻的互动问题
        /// </summary>
        /// <returns></returns>
        public static Result<int> Add(QuestionFeedbackModel ent)
        {
            var result = new Result<int>();
            if (ent.UserId <= 0 || ent.NewsId <= 0)
            {
                result.Message = "无效的参数";
                return result;
            }
            if (ent.QuestionOption.IsNullOrEmpty())
            {
                result.Message = "提交的互动问题不能为空";
                return result;
            }
            var feedback = ent.QuestionOption.JsonDeserialize<List<QuestionOptionRequest>>();
            if (feedback.IsNullOrEmpty())
            {
                result.Message = "提交的互动问题无效";
                return result;
            }
            if (QuestionFeedbackRepository.Exists(ent.NewsId, ent.UserId))
            {
                result.Message = "请勿重复提交问卷";
                return result;
            }
            var memberInfo = MemberRepository.Get(ent.UserId);
            if (memberInfo == null)
            {
                result.Message = "会员信息无效";
                return result;
            }
            decimal score = 0;
            feedback.ForEach(item =>
            {
                var questionInfo = QuestionRepository.Get(item.QId);
                if (questionInfo != null)
                {
                    ent.QuestionId = item.QId;
                    ent.QuestionOption = item.Text;
                    var iRet = QuestionFeedbackRepository.Add(ent);
                    if (iRet > 0)
                    {
                        score += questionInfo.QuestionScore;
                        result.Code = ResultCode.Success;
                    }
                }
            });
            //修改用户积分
            memberInfo.TotalScore += score;
            MemberRepository.Update(memberInfo);
            //增加账户明细
            FundingRepository.Add(new MemberFundingModel()
            {
                UserId = ent.UserId,
                OpType = OperationType.QuestionFeedback,
                ChangeType = ScoreChangeType.Increase,
                OpValue = score,
                Remark = OperationType.QuestionFeedback.Description(),
                CreateTime = DateTime.Now
            });
            return result;
        }
    }
}
