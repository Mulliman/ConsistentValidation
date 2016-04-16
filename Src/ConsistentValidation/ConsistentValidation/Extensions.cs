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

        public static DateTime? GetDateTimeFromRawObject(this object raw)
        {
            if (raw == null)
            {
                return null;
            }

            var nullableDate = raw as DateTime?;

            if (nullableDate.HasValue)
            {
                return nullableDate;
            }

            var stringDate = raw as string;

            if (string.IsNullOrEmpty(stringDate))
            {
                return null;
            }

            DateTime dateFromString;
            // TODO: Maybe improve to have different formats.
            var isValid = DateTime.TryParse(stringDate, out dateFromString);

            if (!isValid)
            {
                throw new ArgumentException("Date is not valid");
            }

            return dateFromString;
        }

        public static int? GetIntFromRawObject(this object raw)
        {
            if (raw == null)
            {
                return null;
            }

            var nullableInt = raw as int?;

            if (nullableInt.HasValue)
            {
                return nullableInt;
            }

            var stringInt = raw as string;

            if (string.IsNullOrEmpty(stringInt))
            {
                return null;
            }

            int intFromString;
            var isValid = int.TryParse(stringInt, out intFromString);

            if (!isValid)
            {
                throw new ArgumentException("Int is not valid");
            }

            return intFromString;
        }
    }
}