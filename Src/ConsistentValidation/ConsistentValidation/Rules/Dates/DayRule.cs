using System;

namespace ConsistentValidation.Rules.Dates
{
    public class DayRule : IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid day.";

        public string MessageId => "Day";

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

            int day;
            if (!int.TryParse(stringValue, out day))
            {
                return false;
            }

            return day >= 1 && day <= 31;
        }
    }
}