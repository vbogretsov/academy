using System;
using System.Collections.Generic;
using System.Resources;
using System.Web;
using Academy.Validation.Dictionaries;

namespace Academy.Resources
{
    public class Localization
    {

        private static readonly IDictionary<string, ResourceManager> resourceManagers;

        static Localization()
        {
            resourceManagers = new Dictionary<string, ResourceManager>();
            resourceManagers.Add("lang.eng", English.ResourceManager);
            resourceManagers.Add("lang.rus", Russian.ResourceManager);
        }

        public static string GetString(string key)
        {
            return CurrentResourceManager.GetString(key);
        }

        public static bool IsLanguageSuppoerted(string language)
        {
            return resourceManagers.ContainsKey(language);
        }

        public static IEnumerable<string> SupportedLanguages
        {
            get
            {
                return resourceManagers.Keys;
            }
        }

        private static ResourceManager CurrentResourceManager
        {
            get
            {
                string language = (string)HttpContext.Current.Session["Language"];
                return resourceManagers.ContainsKey(language)
                    ? resourceManagers[language]
                    : Empty.ResourceManager;
            }
        }
    }
}
