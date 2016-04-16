using ConsistentValidation.Rules.Dates.BaseRules;
using System;

namespace ConsistentValidation.Rules.Dates
{
    public class YearRule : YearRuleBase, IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid year.";

        public string MessageId => "Year";

        public bool IsValid(object rawValue)
        {
            if (rawValue == null)
            {
                return true;
            }

            var stringValue = Convert.ToString(rawValue);

            if (string.IsNullOrEmpty(stringValue))
            {
                return true;
            }

            return IsAValid4DigitYear(stringValue);
        }
    }
}