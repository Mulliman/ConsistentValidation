using ConsistentValidation.Messages;
using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Required;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes
{
    public class ConsistentRequiredAttribute : RequiredAttribute, IConsistentValidationAttribute
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
            var resolver = new MessageResolver(Configuration.MessageProvider, Configuration.MessageCache);

            ErrorMessage = resolver.GetMessage(RuleData);
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