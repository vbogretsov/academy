using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Academy.Resources;

namespace Academy.Validation
{
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    public class LocalizedRegularExpressionAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public LocalizedRegularExpressionAttribute(
            string pattern,
            string errorMessageTag)
            :base(pattern)
        {
            ErrorMessage = Localization.GetString(errorMessageTag);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRegexRule(ErrorMessageString, Pattern);
            return new[] { rule };
        }
    }
}
