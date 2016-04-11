using ConsistentValidation.Rules;

namespace ConsistentValidation.Mvc.Attributes
{
    public interface IConsistentValidationRuleAttribute
    {
        IValidationRule Rule { get;  }
    }
}