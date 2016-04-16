using System;

namespace ConsistentValidation.Rules.Dates.BaseRules
{
    public abstract class DateRuleBase
    {
        protected DateTime? GetDateTimeFromRawObject(object raw)
        {
            if(raw == null)
            {
                return null;
            }

            var nullableDate = raw as DateTime?;

            if(nullableDate.HasValue)
            {
                return nullableDate;
            }

            var stringDate = raw as string;

            if(string.IsNullOrEmpty(stringDate))
            {
                return null;
            }

            DateTime dateFromString;
            // TODO: Maybe improve to have different formats.
            var isValid = DateTime.TryParse(stringDate, out dateFromString);

            if(!isValid)
            {
                throw new ArgumentException("Date is not valid");
            }

            return dateFromString;
        }
    }
}