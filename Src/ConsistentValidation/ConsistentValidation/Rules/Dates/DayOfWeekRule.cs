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
            int? dayOfWeek;

            try
            {
                dayOfWeek = rawValue.GetIntFromRawObject();
            }
            catch (ArgumentException)
            {
                // Int is in an invalid format.
                return false;
            }

            if (dayOfWeek == null)
            {
                // If empty, let the required validation handle those messages.
                return true;
            }

            return dayOfWeek >= 0 && dayOfWeek <= 6;
        }
    }
}