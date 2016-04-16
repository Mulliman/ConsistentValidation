using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Dates;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes.Dates
{
    /// <summary>
    /// This ensures that a date is after a date specified by the developer.
    /// </summary>
    /// <remarks>Accepts: string and DateTime.</remarks>
    public class ConsistentDateAfterAttribute : ValidationAttribute, IConsistentValidationRuleAttribute
    {
        private string _displayName;
        private DateTime _startDate;

        public ConsistentDateAfterAttribute(string startDate)
        {
            _startDate = startDate.ToDateTimeUsingConfigurationFormat();
            Rule = new DateAfterRule(_startDate);

            ErrorMessage = Configuration.MessageCache.GetMessageFromCacheFor(Rule.MessageId)
                ?? Configuration.MessageProvider.GetMessageFor(Rule);
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
            return string.Format(ErrorMessage, _displayName, _startDate);
        }
    }
}