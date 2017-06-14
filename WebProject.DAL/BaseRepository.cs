using System.Data.Entity;

namespace WebProject.DAL
{
    public class BaseRepository<T> where T : class
    {
        protected static T AddEntity(T entity)
        {
            using (var pointContext = new PointContexts())
            {
                pointContext.Entry(entity).State = EntityState.Added;
                //下面的写法统一
                pointContext.SaveChanges();
                return entity;
            }
        }
        protected static bool UpdateEntity(T entity)
        {
            //EF4.0的写法
            //Db.CreateObjectSet<T>().Addach(entity);
            //Db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            //EF5.0的写法 
            using (var pointContext = new PointContexts())
            {
                pointContext.Set<T>().Attach(entity);
                pointContext.Entry<T>(entity).State = EntityState.Modified;
                return pointContext.SaveChanges() > 0;
            }
        }
        public static bool DeleteEntity(T entity)
        {
            using (var pointContext = new PointContexts())
            {
                pointContext.Set<T>().Attach(entity);
                pointContext.Entry<T>(entity).State = EntityState.Deleted;
                return pointContext.SaveChanges() > 0;
            }
        }
    }
}
