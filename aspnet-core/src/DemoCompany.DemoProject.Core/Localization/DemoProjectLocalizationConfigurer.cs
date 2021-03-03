using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace DemoCompany.DemoProject.Localization
{
    public static class DemoProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(DemoProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DemoProjectLocalizationConfigurer).GetAssembly(),
                        "DemoCompany.DemoProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
