using System;
using System.Web.Mvc;
using Academy.Resources;

namespace Academy.Validation
{
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
