using ConsistentValidation.Rules;
using System.Collections.Generic;

namespace ConsistentValidation.Messages
{
    public interface IMessageProvider
    {
        string GetMessageFor(IValidationRuleData ruleData);
    }
}