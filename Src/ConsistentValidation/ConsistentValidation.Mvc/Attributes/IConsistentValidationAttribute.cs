using ConsistentValidation.Validators;

namespace ConsistentValidation.Mvc.Attributes
{
    public interface IConsistentValidationAttribute
    {
        IValidationRuleData RuleData { get; }
    }
}