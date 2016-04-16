using System;

namespace ConsistentValidation.Rules.Dates
{
    /// <summary>
    /// This checks the integer representation of the day of the week.
    /// 0 = Sunday to 6 = Saturday
    /// </summary>
    public class DayOfWeekRule : IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid day of the week.";

        public string MessageId => "DayOfWeek";

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

            int dayOfWeek;
            if (!int.TryParse(stringValue, out dayOfWeek))
            {
                return false;
            }

            return dayOfWeek >= 0 && dayOfWeek <= 6;
        }
    }
}