using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentValidation.Mvc
{
    public static class ValidationContextExtensions
    {
        public static string GetDisplayName(this ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(validationContext.MemberName))
            {
                return validationContext.DisplayName;
            }

            var attributes = validationContext.ObjectType
                .GetProperty(validationContext.MemberName)
                .GetCustomAttributes(typeof(DisplayNameAttribute), true);

            return attributes != null
                ? (attributes[0] as DisplayNameAttribute).DisplayName
                : validationContext.DisplayName;
        }
    }
}