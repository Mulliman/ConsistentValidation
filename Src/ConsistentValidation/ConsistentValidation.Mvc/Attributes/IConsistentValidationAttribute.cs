﻿using ConsistentValidation.Rules;

namespace ConsistentValidation.Mvc.Attributes
{
    public interface IConsistentValidationAttribute
    {
        IValidationRuleData RuleData { get; }
    }
}