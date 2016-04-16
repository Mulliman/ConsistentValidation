using ConsistentValidation.Rules.Dates.BaseRules;
using System;

namespace ConsistentValidation.Rules.Dates
{
    public class DateAfterRule : DateRuleBase, IValidationRule
    {
        private readonly DateTime _startDate;

        public DateAfterRule(DateTime startDate)
        {
            _startDate = startDate;
        }

        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid date after {1}.";

        public string MessageId => "DateAfter";

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

            return date > _startDate;
        }
    }
}