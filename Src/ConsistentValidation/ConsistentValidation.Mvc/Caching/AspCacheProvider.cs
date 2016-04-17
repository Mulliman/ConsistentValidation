using ConsistentValidation.Caching;
using System.Collections.Generic;
using System.Web;

namespace ConsistentValidation.Mvc.Caching
{
    public class AspCacheProvider : IMessageCache
    {
        private const string CacheKey = "ConsistentValidationMessageCache";

        public bool IsEnabled => true;

        public void CacheMessage(string key, string message)
        {
            var cache = HttpRuntime.Cache[CacheKey] as IDictionary<string, string>;

            if (cache == null)
            {
                cache = new Dictionary<string, string>();
            }

            cache[key] = message;
        }

        public void ClearCache()
        {
            var cache = HttpRuntime.Cache[CacheKey];

            cache = null;
        }

        public string GetMessageFromCacheFor(string validatorKey)
        {
            var cache = HttpRuntime.Cache[CacheKey] as IDictionary<string, string>;

            if(cache == null || !cache.ContainsKey(validatorKey))
            {
                return null;
            }

            return cache[validatorKey];
        }
    }
}