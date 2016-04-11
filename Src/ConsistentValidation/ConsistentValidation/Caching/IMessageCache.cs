namespace ConsistentValidation.Caching
{
    public interface IMessageCache
    {
        string GetMessageFromCacheFor(string validatorKey);
    }
}