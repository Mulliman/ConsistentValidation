﻿using System;

namespace ConsistentValidation.Rules.Dates
{
    /// <summary>
    /// This ensures that the year specified is in the past
    /// </summary>
    /// <remarks>Accepts: string and int.</remarks>
    public class YearInPastRule : IValidationRule
    {
        public string DefaultMessageFormat => "Please fill in the '{0}' field with a valid year in the past.";

        public string MessageId => "YearCurrentOrInPast";

        public bool IsValid(object rawValue)
        {
            int? year;

            try
            {
                year = rawValue.GetIntFromRawObject();
            }
            catch (ArgumentException)
            {
                // Int is in an invalid format.
                return false;
            }

            if (year == null)
            {
                // Leave required validation to specialist rules.
                return true;
            }

            return year < DateTime.Now.Year;
        }
    }
}