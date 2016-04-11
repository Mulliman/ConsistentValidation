using ConsistentValidation.Caching;
using ConsistentValidation.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentValidation
{
    public static class Configuration
    {
        public static IMessageCache MessageCache { get; private set; } = new NoCacheProvider();

        public static IMessageProvider MessageProvider { get; private set; } = new DefaultMessageProvider();
    }
}