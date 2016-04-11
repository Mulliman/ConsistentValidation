namespace ConsistentValidation.Validators.RequiredValidators
{
    public class RequiredValidator : IValidationRuleData
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field.";

        public string MessageId => "ConsistentRequired";
    }
}
