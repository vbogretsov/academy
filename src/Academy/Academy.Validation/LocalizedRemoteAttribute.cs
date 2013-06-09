using System;
using System.Web.Mvc;
using Academy.Resources;

namespace Academy.Validation
{
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    public class LocalizedRemoteAttribute : RemoteAttribute
    {
        public LocalizedRemoteAttribute(
            string actionName,
            string controllerName,
            string httpMethod,
            string errorMessageTag)
            :base(actionName, controllerName)
        {
            HttpMethod = httpMethod;
            ErrorMessage = Localization.GetString(errorMessageTag);
        }
    }
}
