using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace QualisTechnologiesCurpSolution.Localization
{
    public static class QualisTechnologiesCurpSolutionLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(QualisTechnologiesCurpSolutionConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(QualisTechnologiesCurpSolutionLocalizationConfigurer).GetAssembly(),
                        "QualisTechnologiesCurpSolution.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
