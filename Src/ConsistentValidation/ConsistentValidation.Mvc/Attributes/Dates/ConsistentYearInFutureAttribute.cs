﻿using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Dates;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes.Dates
{
    /// <summary>
    /// This ensures that the year specified is in the future
    /// </summary>
    /// <remarks>Accepts: string and int.</remarks>
    public class ConsistentYearInFutureAttribute : ValidationAttribute, IConsistentValidationRuleAttribute
    {
        private string _displayName;

        public ConsistentYearInFutureAttribute()
        {
            Rule = new YearInFutureRule();

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