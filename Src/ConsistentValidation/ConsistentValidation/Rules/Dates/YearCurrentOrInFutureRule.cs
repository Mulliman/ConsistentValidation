using System;

namespace ConsistentValidation.Rules.Dates
{
    public class YearCurrentOrInFutureRule : IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid year in the future.";

        public string MessageId => "YearCurrentOrInFuture";

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

            int year;
            if (!int.TryParse(stringValue, out year))
            {
                return false;
            }

            return year >= DateTime.Now.Year;
        }
    }
}