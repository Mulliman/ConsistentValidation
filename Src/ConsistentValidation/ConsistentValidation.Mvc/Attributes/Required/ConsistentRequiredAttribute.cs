using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Required;
using System;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes
{
    public class ConsistentRequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute, IConsistentValidationAttribute
    {
        private string _displayName;

        public IValidationRuleData RuleData
        {
            get
            {
                return new RequiredRuleData();
            }
        }

        public ConsistentRequiredAttribute()
        {
            ErrorMessage = Configuration.MessageCache.GetMessageFromCacheFor(RuleData.MessageId)
                ?? Configuration.MessageProvider.GetMessageFor(RuleData);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _displayName = validationContext.GetDisplayName();

            return base.IsValid(value, validationContext);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, _displayName);
        }
    }
}