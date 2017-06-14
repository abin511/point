using System;
using System.Collections.Generic;
using System.Linq;
using WebProject.Common;
using WebProject.DAL;
using WebProject.Model;

namespace WebProject.BLL
{
    public static class SysConfigService
    {
        /// <summary>
        /// 添加通用键值对配置信息
        /// </summary>
        /// <returns></returns>
        public static Result<bool> Add(SysConfigModel ent)
        {
            #region 数据验证
            var result = ParamsCheck(ent);
            if (result.Code != ResultCode.Success) return result;
            var exists = SysConfigRepository.Exists(ent.KeyName);
            if (exists.HasValue)
            {
                if (exists.Value)
                {
                    result.Message = "存在相同的键名";
                }
            }
            else
            {
                result.Message = "键值对查询数据库异常";
            }
            if (!string.IsNullOrEmpty(result.Message))
            {
                result.Code = ResultCode.Error;
                return result;
            }
            #endregion

            ent.InsertTime = ent.UpdateTime = DateTime.Now;
            ent.IsActive = true;
            var dbResult = SysConfigRepository.Add(ent);
            if (dbResult)
            {
                result.Code = ResultCode.Success;
                CacheHelper.Set(ent.KeyName, ent, TimeSpan.FromMinutes(10));
            }
            else
            {
                result.Code = ResultCode.Error;
                result.Message = "数据库操作异常";
            }
            return result;
        }

        /// <summary>
        /// 修改通用键值对配置信息
        /// </summary>
        /// <returns></returns>
        public static Result<bool> Update(SysConfigModel ent)
        {
            #region 数据验证
            var result = ParamsCheck(ent);
            var exists = SysConfigRepository.Exists(ent.KeyName, ent.Id);
            if (exists.HasValue)
            {
                if (exists.Value)
                {
                    result.Message = "存在相同的键名";
                }
            }
            else
            {
                result.Message = "键值对查询数据库异常";
            }
            if (!string.IsNullOrEmpty(result.Message))
            {
                result.Code = ResultCode.Error;
                return result;
            }
            #endregion
            ent.UpdateTime = DateTime.Now;
            var dbResult = SysConfigRepository.Update(ent);
            if (dbResult)
            {
                result.Code = ResultCode.Success;
                CacheHelper.Set(ent.KeyName, ent, TimeSpan.FromMinutes(10));
            }
            else
            {
                result.Code = ResultCode.Error;
                result.Message = "数据库操作异常";
            }
            return result;
        }

        #region SELECT
        /// <summary>
        /// 根据键值对的键名查询对象
        /// </summary>
        /// <returns></returns>
        public static SysConfigModel GetByKeyName(string keyName, bool fromCache = true)
        {
            if (!fromCache)
            {
                return SysConfigRepository.GetDictionaryConfig(keyName);
            }
            var sysConfig = CacheHelper.Get<SysConfigModel>(keyName);
            if (sysConfig != null) return sysConfig;
            sysConfig = SysConfigRepository.GetDictionaryConfig(keyName);
            if (sysConfig != null)
            {
                CacheHelper.Set(keyName, sysConfig, TimeSpan.FromMinutes(10));
            }
            return sysConfig ?? new SysConfigModel();
        }
        /// <summary>
        /// 获取json格式的Value，返回对象
        /// </summary>
        public static T GetValue<T>(this SysConfigModel dictionaryConfig)
        {
            if (dictionaryConfig == null) return default(T);
            return Deserialize<T>(dictionaryConfig.Value);
        }
        /// <summary>
        /// 获取json格式的Expand，返回对象
        /// </summary>
        public static T GetExpand<T>(this SysConfigModel dictionaryConfig)
        {
            if (dictionaryConfig == null) return default(T);
            return Deserialize<T>(dictionaryConfig.Expand);
        }

        public static T GetDescription<T>(this SysConfigModel dictionaryConfig)
        {
            if (dictionaryConfig == null) return default(T);
            return Deserialize<T>(dictionaryConfig.Description);
        }

        private static T Deserialize<T>(string value)
        {
            if (string.IsNullOrEmpty(value)) return default(T);
            try
            {
                if ((typeof(T)).Name.ToLower() == "string")
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                return value.JsonDeserialize<T>();
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        /// <summary>
        /// 查询所有的键值对配置信息
        /// </summary>
        /// <returns></returns>
        public static void GetList(SysConfigList model)
        {
            var list = SysConfigRepository.GetList(model.Id, model.Search);
            model.Menus = DictionaryConfigMenu();
            model.Count = list.Count;
            model.DataList = list.Skip(model.PageSize * (model.PageIndex - 1)).Take(model.PageSize).ToList();
        }
        public static List<SysConfigMenu> DictionaryConfigMenu()
        {
            var menus = GetByKeyName("DictionaryMenu").GetValue<List<SysConfigMenu>>();
            if (menus == null)
            {
                return new List<SysConfigMenu>()
                {
                    new SysConfigMenu()
                };
            }
            return menus.OrderBy(m => m.Sort).ToList();
        }
        #endregion
        private static Result<bool> ParamsCheck(SysConfigModel ent)
        {
            var result = new Result<bool>();
            ent.GroupName = string.IsNullOrEmpty(ent.GroupName) ? null : ent.GroupName.Trim();
            ent.KeyName = string.IsNullOrEmpty(ent.KeyName) ? null : ent.KeyName.Trim();
            if (string.IsNullOrEmpty(ent.GroupName))
            {
                result.Message = "组名称不能为空！";
                return result;
            }
            if (string.IsNullOrEmpty(ent.KeyName))
            {
                result.Message = "键名称不能为空！";
                return result;
            }
            if (string.IsNullOrEmpty(ent.Value.Trim()))
            {
                result.Message = "值不能为空！";
                return result;
            }
            if (string.IsNullOrEmpty(ent.OwnerName.Trim()))
            {
                result.Message = "所有者不能为空！";
                return result;
            }
            if (ent.LastOpUserId <= 0)
            {
                result.Message = "最后操作人不能为空！";
                return result;
            }
            if (string.IsNullOrEmpty(ent.Description.Trim()))
            {
                result.Message = "描述信息不能为空！";
                return result;
            }
            result.Code = ResultCode.Success;
            return result;
        }
    }
}
