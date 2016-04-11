using System.Text.RegularExpressions;

namespace ConsistentValidation.Rules.Financial
{
    public class CardSecurityCodeRule : IValidationRule
    {
        public const int MinLength = 3;
        public const int MaxLength = 3;

        private readonly Regex Regex = new Regex("^[0-9]{3}$");

        public string DefaultMessageFormat => "Please fill in the '{0}' field with the 3 digit code on your card.";
        
        public string MessageId => "CardSecurityCode";
        
        public bool IsValid(object rawValue)
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