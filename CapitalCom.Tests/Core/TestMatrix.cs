namespace CapitalCom.Tests.Core;

public static class TestMatrix
{
    public static IEnumerable<TestRunContext> SmokeContexts()
    {
        var userStates = new[]
        {
            UserSessionState.Unregistered,
            UserSessionState.Unauthorized,
            UserSessionState.Authorized
        };

        foreach (var userState in userStates)
            foreach (var route in CapitalRouteRegistry.GetSupportedRoutes())
            {
                yield return new TestRunContext(userState, route.License, route.Language, route.Country);
            }
    }

    public static IEnumerable<TestRunContext> UnauthorizedContexts()
    {
        var userStates = new[]
{
            UserSessionState.Unregistered,
            UserSessionState.Unauthorized,
        };

        foreach (var userState in userStates)
            foreach (var route in CapitalRouteRegistry.GetSupportedRoutes())
            {
                yield return new TestRunContext(userState, route.License, route.Language, route.Country);
            }
    }

    public static IEnumerable<TestRunContext> AuthorizedContexts()
    {
        var userState = UserSessionState.Authorized;

        foreach (var route in CapitalRouteRegistry.GetSupportedRoutes())
        {
            yield return new TestRunContext(userState, route.License, route.Language, route.Country);
        }
    }

    public static IEnumerable<TestRunContext> EnglishContexts()
    {
        var userStates = new[]
        {
            UserSessionState.Unregistered,
            UserSessionState.Unauthorized,
            UserSessionState.Authorized
        };

        foreach (var userState in userStates)
            foreach (var route in CapitalRouteRegistry.GetSupportedRoutes())
            {
                yield return new TestRunContext(userState, route.License, CapitalLanguage.En, route.Country);
            }
    }
}
