using System;
using System.Collections.Generic;

namespace ConsistentValidation.Caching
{
    public class NoCacheProvider : IMessageCache
    {
        public bool IsEnabled => false;

        public void CacheMessage(string key, string message)
        {
            throw new NotImplementedException();
        }

        public void ClearCache()
        {
            // No implementation
        }

        public string GetMessageFromCacheFor(string validatorKey)
        {
            return null;
        }
    }
}