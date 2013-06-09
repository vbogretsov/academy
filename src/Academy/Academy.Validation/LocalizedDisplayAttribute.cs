using System;
using System.ComponentModel;
using Academy.Resources;

namespace Academy.Validation
{
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    public class LocalizedDisplayAttribute : DisplayNameAttribute
    {
        public LocalizedDisplayAttribute(string displayNameTag)
        {
            DisplayNameValue = Localization.GetString(displayNameTag);
        }
    }
}
