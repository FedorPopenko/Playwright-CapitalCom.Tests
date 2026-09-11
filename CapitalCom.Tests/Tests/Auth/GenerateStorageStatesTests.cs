using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Artifacts;
using CapitalCom.Tests.Core.Fixtures;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Core.Users;
using CapitalCom.Tests.Pages;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests;

public class GenerateStorageStatesTests : PageTest
{
    private ArtifactManager? _artifactManager;

    [SetUp]
    public async Task SetUpAsync()
    {
        _artifactManager = new ArtifactManager(Context, Page);
        await _artifactManager.StartTraceAsync();
    }
    public override BrowserNewContextOptions ContextOptions()
    {
        var options = base.ContextOptions();

        options.RecordVideoDir = ArtifactPaths.Videos;

        return options;
    }

    [Test]
    [Explicit("Run this test explicitly to refresh .auth/authorized-user.json.")]
    [NonParallelizable]
    public async Task SaveAuthorizedUserStorageStateAsync()
    {
        await Page.GotoAsync(TestSettings.BaseUrl);

        var loginForm = new LoginAndSignUpForm(Page);
        var cookieForm = new CookieForm(Page);

        await cookieForm.AcceptIfDisplayedAsync();

        await loginForm.LoginAsync(TestUsers.QaUser);

        await Assertions.Expect(loginForm.LoginFormCloseButton).ToBeHiddenAsync(new()
        {
            Timeout = 120_000
        });

        var candidateStatePath = Path.Combine(StorageStatePaths.AuthDirectory, "authorized-user.candidate.json");

        try
        {
            await Context.StorageStateAsync(new()
            {
                Path = candidateStatePath
            });

            AuthorizedStorageStateValidator.EnsureUsable(candidateStatePath);
            File.Move(candidateStatePath, StorageStatePaths.Authorized, overwrite: true);
        }
        finally
        {
            if (File.Exists(candidateStatePath))
            {
                File.Delete(candidateStatePath);
            }
        }
    }

    [Test]
    [Explicit("Run this test explicitly to refresh .auth/unauthorized-user.json.")]
    [NonParallelizable]
    public async Task SaveUnauthorizedUserStorageStateAsync()
    {
        await Page.GotoAsync(TestSettings.BaseUrl);

        var cookieForm = new CookieForm(Page);
        var locationForm = new LocationForm(Page);

        await cookieForm.AcceptIfDisplayedAsync();
        await Assertions.Expect(cookieForm.CookieBanner).ToBeHiddenAsync();

        await locationForm.CloseIfDisplayedAsync();

        await Context.StorageStateAsync(new()
        {
            Path = StorageStatePaths.Unauthorized
        });
    }

    [TearDown]
    public async Task TearDownAsync()
    {
        if (_artifactManager is not null)
        {
            await _artifactManager.StopTraceAsync();
        }
    }

}
