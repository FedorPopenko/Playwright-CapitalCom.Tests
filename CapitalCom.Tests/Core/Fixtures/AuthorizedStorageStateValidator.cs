using System.Text.Json;

namespace CapitalCom.Tests.Core.Fixtures;

public static class AuthorizedStorageStateValidator
{
    private const string AccessTokenCookieName = "__cp_at";
    private static readonly TimeSpan MinimumRemainingLifetime = TimeSpan.FromMinutes(5);

    public static void EnsureUsable(string storageStatePath)
    {
        if (!File.Exists(storageStatePath))
        {
            throw new InvalidOperationException(
                $"Authorized storage state was not found: {storageStatePath}. " +
                "Generate it with the explicit SaveAuthorizedUserStorageStateAsync test.");
        }

        using var document = JsonDocument.Parse(File.ReadAllText(storageStatePath));
        var minimumExpiry = DateTimeOffset.UtcNow.Add(MinimumRemainingLifetime).ToUnixTimeSeconds();
        var isAccessTokenUsable = document.RootElement.GetProperty("cookies").EnumerateArray().Any(cookie =>
            cookie.GetProperty("name").GetString() == AccessTokenCookieName &&
            cookie.TryGetProperty("expires", out var expires) && expires.GetDouble() > minimumExpiry);

        if (!isAccessTokenUsable)
        {
            throw new InvalidOperationException(
                "Authorized storage state is missing a valid access-token cookie or it expires in under five minutes. " +
                "Regenerate it with the explicit SaveAuthorizedUserStorageStateAsync test.");
        }
    }
}
