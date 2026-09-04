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
    public async Task SaveAuthorizedUserStorageStateAsync()
    {
        await Page.GotoAsync(TestSettings.BaseUrl);

        var loginForm = new LoginAndSignUpForm(Page);
        var cookieForm = new CookieForm(Page);

        await cookieForm.AcceptCookieAsync();

        await loginForm.LoginAsync(TestUsers.QaUser);
        await Assertions.Expect(Page).ToHaveURLAsync(new Regex(CapitalPagePath.TradingPlatform));

        await Context.StorageStateAsync(new()
        {
            Path = StorageStatePaths.Authorized
        });
    }

    [Test]
    public async Task SaveUnauthorizedUserStorageStateAsync()
    {
        await Page.GotoAsync(TestSettings.BaseUrl);

        var cookieForm = new CookieForm(Page);
        var locationForm = new LocationForm(Page);

        await cookieForm.AcceptCookieAsync();
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
