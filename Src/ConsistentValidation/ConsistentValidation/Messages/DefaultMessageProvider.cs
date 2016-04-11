using System;
using ConsistentValidation.Rules;

namespace ConsistentValidation.Messages
{
    public class DefaultMessageProvider : IMessageProvider
    {
        public string GetMessageFor(IValidationRuleData ruleData)
        {
            return ruleData.DefaultMessageFormat;
        }
    }
}