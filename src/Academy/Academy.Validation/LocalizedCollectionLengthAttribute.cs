using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Academy.Resources;

namespace Academy.Validation
{
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    public class LocalizedCollectionLengthAttribute : ValidationAttribute
    {
        private readonly int min;
        private readonly int max;

        public LocalizedCollectionLengthAttribute(int min, string errorMessageTag)
            :this(min, Int32.MaxValue, errorMessageTag)
        {
        }

        public LocalizedCollectionLengthAttribute(
            int min,
            int max,
            string errorMessageTag)
        {
            this.min = min;
            this.max = max;
            ErrorMessage = Localization.GetString(errorMessageTag);
        }

        public override bool IsValid(object value)
        {
            bool result = false;
            IEnumerable collection = value as IEnumerable;
            if (collection != null)
            {
                int count = collection.Cast<dynamic>().Count();
                result = min < count && count < max;
            }
            return result;
        }
    }
}
