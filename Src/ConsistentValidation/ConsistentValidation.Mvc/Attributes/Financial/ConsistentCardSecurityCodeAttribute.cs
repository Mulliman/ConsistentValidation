using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Financial;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes.Financial
{
    public class ConsistentCardSecurityCodeAttribute : ValidationAttribute, IConsistentValidationRuleAttribute
    {
        private string _displayName;

        public ConsistentCardSecurityCodeAttribute()
        {
            ErrorMessage = Configuration.MessageCache.GetMessageFromCacheFor(Rule.MessageId)
                ?? Configuration.MessageProvider.GetMessageFor(Rule);
        }

        public IValidationRule Rule { get; } = new CardSecurityCodeRule();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _displayName = validationContext.GetDisplayName();

            var isValid = Rule.IsValid(value);

            return isValid 
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, _displayName);
        }
    }
}