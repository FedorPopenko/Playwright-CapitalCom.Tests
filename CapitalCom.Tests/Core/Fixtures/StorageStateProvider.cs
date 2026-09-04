using CapitalCom.Tests.Core.Fixtures;

namespace CapitalCom.Tests.Core;

public static class StorageStateProvider
{
    public static string? GetStorageStatePath(UserSessionState userSessionState)
    {
        return userSessionState switch
        {
            UserSessionState.Unregistered => null,
            UserSessionState.Unauthorized => StorageStatePaths.Unauthorized,
            UserSessionState.Authorized => StorageStatePaths.Authorized,
            _ => throw new ArgumentOutOfRangeException(nameof(userSessionState), userSessionState, null)
        };
    }
}
