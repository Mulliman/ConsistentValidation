using ConsistentValidation.Validators;

namespace ConsistentValidation.Messages
{
    public interface IMessageProvider
    {
        string GetMessageFor(IValidationRuleData ruleData);
    }
}