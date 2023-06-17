using System.Runtime.Caching;

namespace LoadManagement
{
    internal class Cache<TKey,TValue>
    {
        private readonly MemoryCache cache;
        private readonly int capacity;

        public Cache(int capacity)
        { 
            this.capacity = capacity;
            this.cache = new MemoryCache("Cache");
        }

        public TValue Get(TKey key)
        {
            TValue value = (TValue)cache.Get(key.ToString());
            if (value != null)
            {
                cache.Remove(key.ToString());
                cache.Set(key.ToString(), value, Cache<TKey, TValue>.GetCacheItemPolicy());
            }

            return value;
        }

        public void Put(TKey key, TValue value)
        {
            cache.Set(key.ToString(), value, Cache<TKey, TValue>.GetCacheItemPolicy());

            if (cache.GetCount() > capacity)
            {
                var lruKey = cache.Select(kvp => kvp.Key).LastOrDefault();
                cache.Remove(lruKey);
            }
        }

        private static CacheItemPolicy GetCacheItemPolicy()
        {
            return new CacheItemPolicy
            {
                Priority = CacheItemPriority.Default,
                SlidingExpiration = TimeSpan.FromMinutes(10) 
            };
        }
    }
}
