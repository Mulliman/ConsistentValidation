using ConsistentValidation.Rules;
using ConsistentValidation.Rules.Financial;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Attributes.Financial
{
    public class ConsistentCreditOrDebitCardAttribute : ConsistentRuleDataTypeAttribute
    {
        public ConsistentCreditOrDebitCardAttribute()
            : base(DataType.CreditCard)
        {
        }

        public override IValidationRule Rule { get; } = new CreditOrDebitCardRule();
    }
}