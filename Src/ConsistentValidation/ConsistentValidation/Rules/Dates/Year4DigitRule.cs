using ConsistentValidation.Rules.Dates.BaseRules;
using System;

namespace ConsistentValidation.Rules.Dates
{
    public class Year4DigitRule : YearRuleBase, IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid 4 digit year.";

        public string MessageId => "Year";

        public bool IsValid(object rawValue)
        {
            if (rawValue == null)
            {
                return true;
            }

            var nullableInt = rawValue as int?;

            if (nullableInt.HasValue)
            {
                return IsAValid4DigitYear(nullableInt.Value);
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