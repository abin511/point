using WebProject.Model;

namespace WebProject.DAL
{
    /// <summary>
    /// 用户申请记录
    /// </summary>
    public class ApplyRepository : BaseRepository<MemberApplyModel>
    {
        public static int Add(MemberApplyModel entity)
        {
            return AddEntity(entity).Id;
        }
    }
}
