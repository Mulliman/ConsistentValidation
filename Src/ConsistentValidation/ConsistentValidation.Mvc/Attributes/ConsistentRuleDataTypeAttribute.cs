using ConsistentValidation.Messages;
using ConsistentValidation.Rules;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes
{
    public abstract class ConsistentRuleDataTypeAttribute : DataTypeAttribute, IConsistentValidationRuleAttribute
    {
        protected string DisplayName;

        public ConsistentRuleDataTypeAttribute(DataType dataType)
            : base(dataType)
        {
            var resolver = new MessageResolver(Configuration.MessageProvider, Configuration.MessageCache);

            ErrorMessage = resolver.GetMessage(Rule);
        }

        public ConsistentRuleDataTypeAttribute(string customDataType)
            : base(customDataType)
        {
            var resolver = new MessageResolver(Configuration.MessageProvider, Configuration.MessageCache);

            ErrorMessage = resolver.GetMessage(Rule);
        }

        public abstract IValidationRule Rule { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DisplayName = validationContext.GetDisplayName();

            var isValid = Rule.IsValid(value);

            return isValid
                ? ValidationResult.Success
                : new ValidationResult(FormatErrorMessage(DisplayName));
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, DisplayName);
        }
    }
}