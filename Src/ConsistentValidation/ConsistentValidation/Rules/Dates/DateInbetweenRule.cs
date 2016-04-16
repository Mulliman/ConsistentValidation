using ConsistentValidation.Rules.Dates.BaseRules;
using System;

namespace ConsistentValidation.Rules.Dates
{
    public class DateInbetweenRule : DateRuleBase, IValidationRule
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public DateInbetweenRule(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public string DefaultMessageFormat => "Please fill in the '{0}' field with a date inbetween {1} and {2}.";

        public string MessageId => "DateInbetween";

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
            
            if(date == null)
            {
                // If empty, let the required validation handle those messages.
                return true;
            }

            return date >= _startDate && date <= _endDate;
        }
    }
}