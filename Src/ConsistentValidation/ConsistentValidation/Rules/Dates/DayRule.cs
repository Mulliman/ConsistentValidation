using System;

namespace ConsistentValidation.Rules.Dates
{
    /// <summary>
    /// This ensures that a day of the month is valid
    /// </summary>
    /// <remarks>Accepts: string and int.</remarks>
    public class DayRule : IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid day.";

        public string MessageId => "Day";

        public bool IsValid(object rawValue)
        {
            int? day;

            try
            {
                day = rawValue.GetIntFromRawObject();
            }
            catch (ArgumentException)
            {
                // Int is in an invalid format.
                return false;
            }

            if (day == null)
            {
                // Leave required validation to specialist rules.
                return true;
            }

            return day >= 1 && day <= 31;
        }
    }
}