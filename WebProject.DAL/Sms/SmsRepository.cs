using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Model;

namespace WebProject.DAL
{
    public class SmsRepository : BaseRepository<SmsModel>
    {
        public static bool Add(SmsModel entity)
        {
            return AddEntity(entity).Id >= 1;
        }

        public static bool Update(SmsModel entity)
        {
            return UpdateEntity(entity);
        }

        public static SmsModel Get(string mobilePhone, byte smsType, int smsCode)
        {
            using (var context = new PointContexts())
            {
                return context.Sms.OrderByDescending(m => m.Id).FirstOrDefault
                (
                    m =>
                                m.MobilePhone == mobilePhone &&
                                m.SmsType == smsType &&
                                m.SmsCode == smsCode
                );
            }
        }
    }
}