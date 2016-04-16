using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsistentValidation.Mvc.Tests.Attributes
{
    public class AttributeTestBase
    {
        protected static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);

            Validator.TryValidateObject(model, ctx, validationResults, true);

            return validationResults;
        }
    }
}