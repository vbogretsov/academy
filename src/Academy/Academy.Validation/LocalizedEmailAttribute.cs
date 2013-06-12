using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Academy.Resources;

namespace Academy.Validation
{
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    public class LocalizedEmailAttribute : LocalizedRegularExpressionAttribute
    {
        public LocalizedEmailAttribute(string errorMessageTag)
            :base(Smtp.SmtpAddressPattern, errorMessageTag)
        {
        }
    }
}
