using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Academy.Resources;

namespace Academy.Validation
{
    public class LocalizedRequiredAttribute : RequiredAttribute, IClientValidatable
    {
        public LocalizedRequiredAttribute(string errorMessageTag)
        {
            ErrorMessage = Localization.GetString(errorMessageTag);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRequiredRule(ErrorMessageString);
            return new[] { rule };
        }
    }
}
