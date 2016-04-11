using System;
using ConsistentValidation.Validators;

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