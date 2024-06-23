using StackExchange.Redis;

namespace Data.RadisCache
{
    public class RedisCacheManager
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = "localhost:6379"; // Your Redis connection string
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public static ConnectionMultiplexer Connection => lazyConnection.Value;
    }
}
