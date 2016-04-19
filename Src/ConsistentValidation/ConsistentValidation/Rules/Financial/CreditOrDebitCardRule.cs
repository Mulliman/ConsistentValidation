using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsistentValidation.Rules.Financial
{
    /// <summary>
    /// This validates a credit or debit card number.
    /// </summary>
    /// <remarks>Accepts: string only. Can have numeric and dash chars.</remarks>
    public class CreditOrDebitCardRule : ValidationRuleBase
    {
        public const int MinLength = 13;
        public const int MaxLength = 19;

        private readonly Regex Regex = new Regex("[0-9\\-]+");

        public override string DefaultMessageFormat => "Please fill in the '{0}' field with a valid credit or debit card number.";

        public override string MessageId => "CreditOrDebitCard";

        public override IEnumerable<Type> AllowedTypes => new [] { typeof(string) };

        public override bool IsValid(object rawValue)
        {
            EnsureThatPropertyIsValidType(rawValue);

            if (rawValue == null)
            {
                return true;
            }

            var creditCardNumber = rawValue as string;
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return true;
            }

            if (!Regex.IsMatch(creditCardNumber))
            {
                return false;
            }

            creditCardNumber = creditCardNumber.Replace("-", string.Empty).Replace(" ", string.Empty);

            if (IsCardNumberValidLength(creditCardNumber))
            {
                return false;
            }

            return PassesMod10LuhnAlgorithm(creditCardNumber);
        }

        private static bool IsCardNumberValidLength(string creditCardNumber)
        {
            return string.IsNullOrEmpty(creditCardNumber) 
                || creditCardNumber.Length < MinLength 
                || creditCardNumber.Length > MaxLength;
        }

        private bool PassesMod10LuhnAlgorithm(string creditCardNumber)
        {
            int sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9')
                    .Reverse()
                    .Select((e, i) => (e - 48) * (i % 2 == 0 ? 1 : 2))
                    .Sum((e) => e / 10 + e % 10);
            
            return sumOfDigits % 10 == 0;
        }
    }
}