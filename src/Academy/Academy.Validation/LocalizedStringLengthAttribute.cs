using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Academy.Resources;

namespace Academy.Validation
{
    public class LocalizedStringLengthAttribute : StringLengthAttribute, IClientValidatable
    {
        public LocalizedStringLengthAttribute(
            int minLength,
            int maxLength,
            string errorMessageTag)
            :base(maxLength)
        {
            MinimumLength = minLength;
            ErrorMessage = Localization.GetString(errorMessageTag);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationStringLengthRule(
                ErrorMessageString,
                MinimumLength,
                MaximumLength);
            return new[] { rule };
        }
    }
}
