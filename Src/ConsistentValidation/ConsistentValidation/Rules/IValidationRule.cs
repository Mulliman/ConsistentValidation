namespace ConsistentValidation.Rules
{
    public interface IValidationRule : IValidationRuleData
    {
        bool IsValid(object rawValue);
    }
}
