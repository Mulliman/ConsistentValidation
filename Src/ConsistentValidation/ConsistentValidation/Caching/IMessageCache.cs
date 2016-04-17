namespace ConsistentValidation.Caching
{
    public interface IMessageCache
    {
        bool IsEnabled { get; }

        string GetMessageFromCacheFor(string validatorKey);

        void CacheMessage(string key, string message);

        void ClearCache();
    }
}