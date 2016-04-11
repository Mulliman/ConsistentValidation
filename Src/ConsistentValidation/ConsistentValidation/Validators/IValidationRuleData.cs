namespace ConsistentValidation.Validators
{
    public interface IValidationRuleData
    {
        string MessageId { get; }

        string DefaultMessageFormat { get; }
    }
}