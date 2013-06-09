using System;
using System.Web.Mvc;
using Academy.Resources;

namespace Academy.Validation
{
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    public class LocalizedCompareAttribute : CompareAttribute
    {
        public LocalizedCompareAttribute(
            string otherProperty,
            string errorMessageTag)
            : base(otherProperty)
        {
            ErrorMessage = Localization.GetString(errorMessageTag);
        }
    }
}
