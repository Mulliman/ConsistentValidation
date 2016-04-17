using ConsistentValidation.Caching;
using ConsistentValidation.Rules;

namespace ConsistentValidation.Messages
{
    public class MessageResolver
    {
        private readonly IMessageProvider _provider;
        private readonly IMessageCache _cache;

        public MessageResolver(IMessageProvider provider, IMessageCache cache)
        {
            _provider = provider;
            _cache = cache;
        }

        public string GetMessage(IValidationRuleData rule)
        {
            if(!_cache.IsEnabled)
            {
                return _provider.GetMessageFor(rule);
            }

            var cachedMessage = _cache.GetMessageFromCacheFor(rule.MessageId);

            if(cachedMessage != null)
            {
                return cachedMessage;
            }

            var message = _provider.GetMessageFor(rule);

            _cache.CacheMessage(rule.MessageId, message);

            return message;
        }
    }
}