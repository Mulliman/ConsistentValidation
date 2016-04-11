namespace ConsistentValidation.Rules.Required
{
    public class RequiredRuleData : IValidationRuleData
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field.";

        public string MessageId => "ConsistentRequired";
    }
}
