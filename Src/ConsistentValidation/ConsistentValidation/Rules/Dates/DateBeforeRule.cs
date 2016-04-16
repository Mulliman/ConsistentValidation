using ConsistentValidation.Rules.Dates.BaseRules;
using System;

namespace ConsistentValidation.Rules.Dates
{
    public class DateBeforeRule : DateRuleBase, IValidationRule
    {
        private readonly DateTime _endDate;

        public DateBeforeRule(DateTime endDate)
        {
            _endDate = endDate;
        }

        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid date before {1}.";

        public string MessageId => "DateBefore";

        public bool IsValid(object rawValue)
        {
            DateTime? date;

            try
            {
                date = rawValue.GetDateTimeFromRawObject();
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

            return date < _endDate;
        }
    }
}