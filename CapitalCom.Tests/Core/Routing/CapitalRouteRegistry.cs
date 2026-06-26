namespace CapitalCom.Tests.Core
{
    public static class CapitalRouteRegistry
    {
        public static IEnumerable<CapitalRoute> GetSupportedRoutes()
        {
            yield return new CapitalRoute(CapitalLicense.CMA, CapitalLanguage.En, CapitalCountry.Default);
            yield return new CapitalRoute(CapitalLicense.CMA, CapitalLanguage.Ar, CapitalCountry.Default);

            yield return new CapitalRoute(CapitalLicense.ASIC, CapitalLanguage.En, CapitalCountry.Default);

            yield return new CapitalRoute(CapitalLicense.FCA, CapitalLanguage.En, CapitalCountry.Default);

            foreach (var language in new[]
            {
                CapitalLanguage.En,
                CapitalLanguage.Ar,
                CapitalLanguage.De,
                CapitalLanguage.Es,
                CapitalLanguage.Fr,
                CapitalLanguage.Ru,
                CapitalLanguage.Mn,
                CapitalLanguage.Vi,
                CapitalLanguage.Hans,
                CapitalLanguage.Hant
            })
            {
                yield return new CapitalRoute(CapitalLicense.SCB, language, CapitalCountry.Default);
            }

            yield return new CapitalRoute(CapitalLicense.CySEC, CapitalLanguage.En, CapitalCountry.Default);
            yield return new CapitalRoute(CapitalLicense.CySEC, CapitalLanguage.De, CapitalCountry.Austria);
            yield return new CapitalRoute(CapitalLicense.CySEC, CapitalLanguage.De, CapitalCountry.Germany);

            foreach (var language in new[]
{
                CapitalLanguage.El,
                CapitalLanguage.It,
                CapitalLanguage.Fr,
                CapitalLanguage.Hu,
                CapitalLanguage.Nl,
                CapitalLanguage.Pl,
                CapitalLanguage.Ro
            })
            {
                yield return new CapitalRoute(CapitalLicense.CySEC, language, CapitalCountry.Default);
            }
        }
    }
}
