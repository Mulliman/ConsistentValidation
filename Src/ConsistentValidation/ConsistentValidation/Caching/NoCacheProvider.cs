namespace ConsistentValidation.Caching
{
    public class NoCacheProvider : IMessageCache
    {
        public string GetMessageFromCacheFor(string validatorKey)
        {
            return null;
        }
    }
}