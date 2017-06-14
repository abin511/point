using System;
using System.Collections.Generic;
using WebProject.DAL;
using WebProject.Model;

namespace WebProject.BLL
{
    public static class QuestionService
    {
        /// <summary>
        /// 添加新闻的互动问题
        /// </summary>
        /// <returns></returns>
        public static void Add(QuestionModel ent)
        {
            QuestionRepository.Add(ent);
        }
        /// <summary>
        /// 更新互动问题
        /// </summary>
        /// <returns></returns>
        public static void Update(QuestionModel ent)
        {
            QuestionRepository.Update(ent);
        }
        /// <summary>
        /// 获取问卷的互动问题
        /// </summary>
        /// <returns></returns>
        public static List<QuestionModel> GetList(int id)
        {
            var result = new List<QuestionModel>();
            if (id <= 0)
            {
                return result;
            }
            return QuestionRepository.GetList(id);
        }
    }
}
