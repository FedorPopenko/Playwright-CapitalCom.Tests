namespace CapitalCom.Tests.Core;

public static class StorageStateProvider
{
    public static string? GetStorageStatePath(UserSessionState userSessionState)
    {
        return userSessionState switch
        {
            UserSessionState.Unregistered => null,
            UserSessionState.Unauthorized => ".auth/returning-user.json",
            UserSessionState.Authorized => ".auth/authorized-user.json",
            _ => throw new ArgumentOutOfRangeException(nameof(userSessionState), userSessionState, null)
        };
    }
}
