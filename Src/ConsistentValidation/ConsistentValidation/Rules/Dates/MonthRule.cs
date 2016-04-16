using System;

namespace ConsistentValidation.Rules.Dates
{
    public class MonthRule : IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid month.";

        public string MessageId => "Month";

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

            int month;
            if (!int.TryParse(stringValue, out month))
            {
                return false;
            }

            return month >= 1 && month <= 12;
        }
    }
}