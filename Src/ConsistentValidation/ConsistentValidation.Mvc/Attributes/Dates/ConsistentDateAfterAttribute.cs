using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Dates;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes.Dates
{
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
                : new ValidationResult(ErrorMessage);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, _displayName);
        }
    }
}