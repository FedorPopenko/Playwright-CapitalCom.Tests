namespace CapitalCom.Tests.Core;

public sealed record TestRunContext(
    UserSessionState UserSessionState,
    CapitalLicense License,
    CapitalLanguage Language,
    CapitalCountry Country);

