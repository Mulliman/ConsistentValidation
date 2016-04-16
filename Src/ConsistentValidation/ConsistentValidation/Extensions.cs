using System;
using System.Globalization;

namespace ConsistentValidation
{
    public static class Extensions
    {
        public static DateTime ToDateTimeUsingConfigurationFormat(this string dateString)
        {
            DateTime date;
            var format = Configuration.ConfigurationDateFormat;

            var isValid = DateTime.TryParseExact(dateString,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date);

            if (!isValid)
            {
                throw new ArgumentException("The date provided is not in the format defined in ConsistentValidation Configuration ({0}).", format);
            }

            return date;
        }
    }
}