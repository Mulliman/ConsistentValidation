using System;

namespace ConsistentValidation.Rules.Dates
{
    public class YearCurrentOrInPastRule : IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a this year or a year in the past.";

        public string MessageId => "YearCurrentOrInPast";

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

            return year <= DateTime.Now.Year;
        }
    }
}