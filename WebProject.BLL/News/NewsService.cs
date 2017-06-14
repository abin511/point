using System;
using System.Collections.Generic;
using WebProject.DAL;
using WebProject.Model;

namespace WebProject.BLL
{
    public static class NewsService
    {
        /// <summary>
        /// 首页获取新闻列表
        /// </summary>
        /// <returns></returns>
        public static void GetHomeFeedList(QueryBase<NewsModel> ent)
        {
            NewsRepository.GetHomeFeedList(ent);
        }
        /// <summary>
        /// 用户收藏的新闻列表
        /// </summary>
        /// <returns></returns>
        public static void GetFavoriteList(QueryBase<NewsModel> ent)
        {
            FavoriteRepository.GetFavoriteList(ent);
        }
        /// <summary>
        /// 用户点击收藏操作
        /// </summary>
        /// <returns></returns>
        public static Result<int> AddFavorite(MemberFavoriteModel ent)
        {
            var result = new Result<int>();
            if (ent.UserId <= 0 || ent.NewsId <= 0)
            {
                result.Message = "无效的参数";
                return result;
            }
            var newsInfo = NewsRepository.Get(ent.NewsId);
            if (newsInfo == null || newsInfo.Id <= 0)
            {
                result.Message = "无效的数据";
                return result;
            }
            var favoriteCount = FavoriteRepository.Count(ent.UserId);
            if (favoriteCount >= 20)
            {
                result.Message = "最多只能收藏20条新闻";
                return result;
            }
            var newsCount = FavoriteRepository.Count(ent.UserId,ent.NewsId);
            if (newsCount >= 1)
            {
                result.Message = "请勿重复收藏";
                return result;
            }
            result.Code =  ResultCode.Success;
            result.Data = FavoriteRepository.Add(ent);
            return result;
        }
        /// <summary>
        /// 获取新闻明细
        /// </summary>
        /// <returns></returns>
        public static NewsModel Get(int id)
        {
            if (id <= 0) return null;
            return NewsRepository.Get(id);
        }
        /// <summary>
        /// 批量获取新闻列表
        /// </summary>
        /// <returns></returns>
        public static List<NewsModel> GetList(List<int> ids)
        {
            var result = new List<NewsModel>();
            if (ids.Count <= 0)
            {
                return result;
            }
            return NewsRepository.GetList(ids);
        }
    }
}
