using ConsistentValidation.Rules;

namespace ConsistentValidation.Messages
{
    public interface IMessageProvider
    {
        string GetMessageFor(IValidationRuleData ruleData);
    }
}