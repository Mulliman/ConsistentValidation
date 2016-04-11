namespace ConsistentValidation.Rules
{
    public interface IValidationRuleData
    {
        string MessageId { get; }

        string DefaultMessageFormat { get; }
    }
}