using System.Text.RegularExpressions;

namespace ConsistentValidation.Rules.Dates.BaseRules
{
    public abstract class YearRuleBase
    {
        protected readonly Regex YearRegex = new Regex(@"^[0-9]{4}$");

        protected bool IsAValid4DigitYear(string year)
        {
            return YearRegex.IsMatch(year);
        }

        protected bool IsAValid4DigitYear(int year)
        {
            return year >= 1000 && year <= 9999;
        }
    }
}