using ConsistentValidation.Messages;
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
    public class ConsistentDateBeforeAttribute : ValidationAttribute, IConsistentValidationRuleAttribute
    {
        private string _displayName;
        private DateTime _endDate;

        public ConsistentDateBeforeAttribute(string endDate)
        {
            _endDate = endDate.ToDateTimeUsingConfigurationFormat();
            Rule = new DateBeforeRule(_endDate);

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
            return string.Format(ErrorMessage, _displayName, _endDate);
        }
    }
}