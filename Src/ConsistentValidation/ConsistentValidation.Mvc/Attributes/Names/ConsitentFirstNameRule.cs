using ConsistentValidation.Messages;
using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Financial;
using ConsistentValidation.Rules.Names;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes.Names
{
    public class ConsistentFirstNameAttribute : ValidationAttribute, IConsistentValidationRuleAttribute
    {
        private string _displayName;

        public ConsistentFirstNameAttribute()
        {
            var resolver = new MessageResolver(Configuration.MessageProvider, Configuration.MessageCache);

            ErrorMessage = resolver.GetMessage(Rule);
        }

        public IValidationRule Rule { get; } = new FirstNameRule();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _displayName = validationContext.GetDisplayName();

            var isValid = Rule.IsValid(value);

            return isValid
                ? ValidationResult.Success
                : new ValidationResult(FormatErrorMessage(_displayName));
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, _displayName);
        }
    }
}