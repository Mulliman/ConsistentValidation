using ConsistentValidation.Rules.Dates.BaseRules;
using System;

namespace ConsistentValidation.Rules.Dates
{
    public class DateInPastRule : DateRuleBase, IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid date in the past.";

        public string MessageId => "DateInPast";

        public bool IsValid(object rawValue)
        {
            DateTime? date;

            try
            {
                date = GetDateTimeFromRawObject(rawValue);
            }
            catch (ArgumentException)
            {
                // Date is in an invalid format.
                return false;
            }

            if (date == null)
            {
                // If empty, let the required validation handle those messages.
                return true;
            }

            return date < DateTime.Now.Date;
        }
    }
}