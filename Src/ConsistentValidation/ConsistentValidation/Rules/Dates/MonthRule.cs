using System;

namespace ConsistentValidation.Rules.Dates
{
    public class MonthRule : IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid month.";

        public string MessageId => "Month";

        public bool IsValid(object rawValue)
        {
            int? month;

            try
            {
                month = rawValue.GetIntFromRawObject();
            }
            catch (ArgumentException)
            {
                // Int is in an invalid format.
                return false;
            }

            if (month == null)
            {
                // Leave required validation to specialist rules.
                return true;
            }

            return month >= 1 && month <= 12;
        }
    }
}