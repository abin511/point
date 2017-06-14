using System.Linq;
using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 会员信息
    /// </summary>
    public class MemberRepository : BaseRepository<MemberModel>
    {
        public static MemberModel Add(MemberModel entity)
        {
            return AddEntity(entity);
        }
        public static bool Update(MemberModel entity)
        {
            return UpdateEntity(entity);
        }
        public static MemberModel Get(int id)
        {
            if (id <= 0) return null;
            using (var pointContext = new PointContexts())
            {
                return pointContext.Members.FirstOrDefault(m => m.Id == id && m.Status == MemberStatus.Normal);
            }
        }
        public static MemberModel Get(string mobilePhone)
        {
            using (var pointContext = new PointContexts())
            {
                return pointContext.Members.FirstOrDefault(m => m.MobilePhone == mobilePhone && m.Status == MemberStatus.Normal);
            }
        }
        public static MemberModel Get(int id, string mobilePhone)
        {
            using (var pointContext = new PointContexts())
            {
                return pointContext.Members.FirstOrDefault(m => m.Id == id && m.MobilePhone == mobilePhone && m.Status == MemberStatus.Normal);
            }
        }
        public static MemberModel Get(string mobilePhone, string encryptedPwd)
        {
            using (var pointContext = new PointContexts())
            {
                return pointContext.Members.FirstOrDefault(m => m.MobilePhone == mobilePhone && m.EncryptedPwd == encryptedPwd && m.Status == MemberStatus.Normal);
            }
        }
        public static bool? Exists(string mobilePhone)
        {
            using (var context = new PointContexts())
            {
                return context.Members.Any(m => m.MobilePhone == mobilePhone);
            }
        }
    }
}
