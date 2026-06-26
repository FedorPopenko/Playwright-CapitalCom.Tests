namespace CapitalCom.Tests.Core;

public static class CapitalUrlBuilder
{
    public static string Build(CapitalLicense license, CapitalLanguage language, CapitalCountry country = CapitalCountry.Default)
    {
        var path = (license, language, country) switch
        {
            (CapitalLicense.FCA, CapitalLanguage.En, _) => "/en-gb",

            (CapitalLicense.ASIC, CapitalLanguage.En, _) => "/en-au",

            (CapitalLicense.CMA, CapitalLanguage.En, _) => "/en-ae",
            (CapitalLicense.CMA, CapitalLanguage.Ar, _) => "/ar-ae",

            (CapitalLicense.SCB, CapitalLanguage.En, _) => "/en-int",
            (CapitalLicense.SCB, CapitalLanguage.Ar, _) => "/ar-int",
            (CapitalLicense.SCB, CapitalLanguage.De, _) => "/de-int",
            (CapitalLicense.SCB, CapitalLanguage.Es, _) => "/es-int",
            (CapitalLicense.SCB, CapitalLanguage.Fr, _) => "/fr-int",
            (CapitalLicense.SCB, CapitalLanguage.Ru, _) => "/ru-int",
            (CapitalLicense.SCB, CapitalLanguage.Mn, _) => "/mn-int",
            (CapitalLicense.SCB, CapitalLanguage.Vi, _) => "/vi-int",
            (CapitalLicense.SCB, CapitalLanguage.Hans, _) => "/zh-hans",
            (CapitalLicense.SCB, CapitalLanguage.Hant, _) => "/zh-hant",

            (CapitalLicense.CySEC, CapitalLanguage.En, _) => "/en-eu",
            (CapitalLicense.CySEC, CapitalLanguage.De, CapitalCountry.Germany) => "/de-de",
            (CapitalLicense.CySEC, CapitalLanguage.De, CapitalCountry.Austria) => "/de-at",
            (CapitalLicense.CySEC, CapitalLanguage.El, _) => "/el-gr",
            (CapitalLicense.CySEC, CapitalLanguage.It, _) => "/it-it",
            (CapitalLicense.CySEC, CapitalLanguage.Fr, _) => "/fr-fr",
            (CapitalLicense.CySEC, CapitalLanguage.Hu, _) => "/hu-hu",
            (CapitalLicense.CySEC, CapitalLanguage.Nl, _) => "/nl-nl",
            (CapitalLicense.CySEC, CapitalLanguage.Pl, _) => "/pl-pl",
            (CapitalLicense.CySEC, CapitalLanguage.Ro, _) => "/ro-ro",

            _ => throw new ArgumentOutOfRangeException()
        };

        return $"{TestSettings.BaseUrl}{path}";
    }
}
