using ConsistentValidation.Messages;
using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Dates;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes.Dates
{
    /// <summary>
    /// This ensures that the year specified is either this year, or one in the future
    /// </summary>
    /// <remarks>Accepts: string and int.</remarks>
    public class ConsistentYearCurrentOrInFutureAttribute : ValidationAttribute, IConsistentValidationRuleAttribute
    {
        private string _displayName;

        public ConsistentYearCurrentOrInFutureAttribute()
        {
            Rule = new YearCurrentOrInFutureRule();

            var resolver = new MessageResolver(Configuration.MessageProvider, Configuration.MessageCache);

            ErrorMessage = resolver.GetMessage(Rule);
        }

        public IValidationRule Rule { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _displayName = validationContext.GetDisplayName();

            var isValid = Rule.IsValid(value);

            return isValid
                ? ValidationResult.Success
                : new ValidationResult(FormatErrorMessage(_displayName)); ;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, _displayName);
        }
    }
}