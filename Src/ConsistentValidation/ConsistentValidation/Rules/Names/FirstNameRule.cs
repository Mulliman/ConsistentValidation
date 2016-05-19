using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsistentValidation.Rules.Names
{
    public class FirstNameRule : ValidationRuleBase
    {
        public const int MinLength = 2;
        public const int MaxLength = 255;

        private readonly Regex Regex = new Regex("^[a-zA-Z-']{2,255}$");

        public override string DefaultMessageFormat => "Please fill in the '{0}' field with a valid name.";
        
        public override string MessageId => "FirstName";

        public override IEnumerable<Type> AllowedTypes => new[] { typeof(string) };

        public override bool IsValid(object rawValue)
        {
            var value = rawValue as string;

            if(string.IsNullOrEmpty(value))
            {
                // If this is empty return true as
                // required validators should check if filled in.
                return true;
            }

            return Regex.IsMatch(value);
        }
    }
}