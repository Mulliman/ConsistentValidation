using ConsistentValidation.Caching;
using ConsistentValidation.Messages;

namespace ConsistentValidation
{
    public static class Configuration
    {
        public static string ConfigurationDateFormat { get; private set; } = "yyyy-MM-dd";

        public static IMessageCache MessageCache { get; private set; } = new NoCacheProvider();

        public static IMessageProvider MessageProvider { get; private set; } = new DefaultMessageProvider();
    }
}