using System;
using System.ComponentModel;
using Academy.Resources;

namespace Academy.Validation
{
    public class LocalizedDisplayAttribute : DisplayNameAttribute
    {
        public LocalizedDisplayAttribute(string displayNameTag)
        {
            DisplayNameValue = Localization.GetString(displayNameTag);
        }
    }
}
