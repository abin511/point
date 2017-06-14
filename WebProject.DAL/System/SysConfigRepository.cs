using System;
using System.Collections.Generic;
using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 系统配置信息
    /// </summary>
    public class SysConfigRepository: BaseRepository<SysConfigModel>
    {
        public static bool Add(SysConfigModel entity)
        {
            using (var context = new PointContexts())
            {
                context.SysConfigs.Add(entity);
                return context.SaveChanges() >= 1;
            }
        }

        public static bool Update(SysConfigModel entity)
        {
            const string sqlQuery = @"UPDATE [dbo].[DictionaryConfig] SET GroupName={0},KeyName={1},Value={2},Description={3},Expand={4},TypeId={5},OwnerName={6},LastOpUserId={7},UpdateTime={8} WHERE Id={9}";
            using (var context = new PointContexts())
            {
                return context.Database.ExecuteSqlCommand(sqlQuery, entity.GroupName, entity.KeyName, entity.Value, entity.Description, entity.Expand, entity.TypeId, entity.OwnerName, entity.LastOpUserId, entity.UpdateTime, entity.Id) > 0;
            }
        }

        public static List<SysConfigModel> GetList(int typeId, string search)
        {
            string sqlQuery = @"SELECT * FROM [dbo].[DictionaryConfig] WITH(NOLOCK) WHERE IsActive=1 ";
            if (typeId >= 0)
            {
                sqlQuery += string.Format(" AND TypeId = {0}", typeId);
            }
            if (!string.IsNullOrEmpty(search))
            {
                sqlQuery += String.Format(" AND ( GroupName LIKE '%{0}%' OR KeyName LIKE '%{0}%'  OR [Value] LIKE '%{0}%' OR [Description] LIKE '%{0}%' OR OwnerName LIKE '%{0}%')", search);
            }
            sqlQuery += " ORDER BY ID DESC";
            using (var context = new PointContexts())
            {
                return context.Database.SqlQuery<SysConfigModel>(sqlQuery, typeId).ToList();
            }
        }
        public static bool? Exists(string keyName, int id = 0)
        {
            using (var context = new PointContexts())
            {
                return context.SysConfigs.Any(m => id == 0 && m.KeyName == keyName || m.Id != id && m.KeyName == keyName);
            }
        }
        public static SysConfigModel GetDictionaryConfig(string keyName)
        {
            using (var context = new PointContexts())
            {
                return context.SysConfigs.FirstOrDefault(m => m.KeyName == keyName && m.IsActive);
            }
        }
    }
}
