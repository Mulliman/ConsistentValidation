using ConsistentValidation.Messages;
using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Financial;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes.Financial
{
    /// <summary>
    /// This validates the 3 digit code that appears on the back of credit and debit cards.
    /// </summary>
    /// <remarks>Accepts: string only. Can have leading 0 so int not valid.</remarks>
    public class ConsistentCardSecurityCodeAttribute : ValidationAttribute, IConsistentValidationRuleAttribute
    {
        private string _displayName;

        public ConsistentCardSecurityCodeAttribute()
        {
            var resolver = new MessageResolver(Configuration.MessageProvider, Configuration.MessageCache);

            ErrorMessage = resolver.GetMessage(Rule);
        }

        public IValidationRule Rule { get; } = new CardSecurityCodeRule();

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