using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Dates;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes.Dates
{
    public class ConsistentDateInbetweenAttribute : ValidationAttribute, IConsistentValidationRuleAttribute
    {
        private string _displayName;
        private DateTime _startDate;
        private DateTime _endDate;

        public ConsistentDateInbetweenAttribute(string startDate, string endDate)
        {
            _startDate = startDate.ToDateTimeUsingConfigurationFormat();
            _endDate = endDate.ToDateTimeUsingConfigurationFormat();

            Rule = new DateInbetweenRule(_startDate, _endDate);

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