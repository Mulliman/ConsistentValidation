using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsistentValidation.Rules
{
    public abstract class ValidationRuleBase : IValidationRule
    {
        public abstract IEnumerable<Type> AllowedTypes { get; }

        public abstract string DefaultMessageFormat { get; }

        public abstract string MessageId { get; }

        public abstract bool IsValid(object rawValue);

        protected void EnsureThatPropertyIsValidType(object property)
        {
            if(property == null)
            {
                return;
            }

            foreach (var type in AllowedTypes)
            {
                if (type.IsInstanceOfType(property))
                {
                    return;
                }
            }

            var propertyType = property.GetType();
            var errorMessageFormat = "{0} does not accept properties of the type {1}. Allowed types: {2}.";

            throw new InvalidOperationException(string.Format(errorMessageFormat, 
                GetType().Name,
                propertyType, 
                string.Join(",", AllowedTypes.Select(t => t.Name))));
        }
    }
}