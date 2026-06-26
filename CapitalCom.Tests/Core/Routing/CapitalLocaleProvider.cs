namespace CapitalCom.Tests.Core;

public static class CapitalLocaleProvider
{
    public static string GetLocale(CapitalLanguage language)
    {
        return language switch
        {
            CapitalLanguage.En => "en-US",
            CapitalLanguage.Ar => "ar-AR",
            CapitalLanguage.De => "de-DE",
            CapitalLanguage.Es => "es-ES",
            CapitalLanguage.Fr => "fr-FR",
            CapitalLanguage.Ru => "ru-RU",
            CapitalLanguage.Mn => "mn-MN",
            CapitalLanguage.Vi => "vi-VI",
            CapitalLanguage.Hans => "zh-hans",
            CapitalLanguage.Hant => "zh-hant",
            CapitalLanguage.El => "el-EL",
            CapitalLanguage.It => "it-IT",
            CapitalLanguage.Hu => "hu-HU",
            CapitalLanguage.Nl => "nl-NL",
            CapitalLanguage.Pl => "pl-PL",
            CapitalLanguage.Ro => "ro-RO",
            _ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
        };
    }
}
