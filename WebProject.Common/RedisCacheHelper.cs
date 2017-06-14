using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack;
using ServiceStack.Redis;
using ServiceStack.ServiceClient;
using System.Configuration;

namespace WebProject.Common
{
    public class RedisCacheHelper<T>
    {
        private readonly string host;
        private readonly int port;
        private readonly string passrowd;


        public RedisCacheHelper()
        {
            this.host = ConfigurationManager.AppSettings["RedisHost"];
            this.port = int.Parse(ConfigurationManager.AppSettings["RedisPort"]);
            this.passrowd = ConfigurationManager.AppSettings["RedisAuth"];
        }

        public IRedisClient GetRedisClient()
        {
            return new RedisClient(this.host, this.port)
            {
                Password = this.passrowd
            };
        }

        public T Get(string key)
        {
            using (IRedisClient client = this.GetRedisClient())
            {
                return client.Get<T>(key);
            }
        }

        public bool Set(string key, T t, TimeSpan expiresIn)
        {
            using (IRedisClient client = this.GetRedisClient())
            {
                return client.Set(key, t, expiresIn);
            }
        }
    }
}