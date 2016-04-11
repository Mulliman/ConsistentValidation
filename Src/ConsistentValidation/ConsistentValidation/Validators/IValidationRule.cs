namespace ConsistentValidation.Validators
{
    public interface IValidationRule : IValidationRuleData
    {
        bool IsValid(object rawValue);
    }
}
