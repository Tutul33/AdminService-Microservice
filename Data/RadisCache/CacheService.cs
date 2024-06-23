using Data.DataContext.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Data.RadisCache
{
    public class CacheService
    {
        private readonly IDatabase _cache;

        public CacheService()
        {
            _cache = RedisCacheManager.Connection.GetDatabase();
        }

        public T GetCache<T>(string key)
        {
            var value = _cache.StringGet(key);
            if (!value.HasValue) return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }

        public void SetCache<T>(string key, T value, TimeSpan expiration)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            _cache.StringSet(key, serializedValue, expiration);
        }

    }

}
