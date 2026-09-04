using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Fixtures;
using CapitalCom.Tests.Core.Models;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests;

public class ManualLoginTest
{

    [Test]
    public async Task LoginWithVisibleChromeAsynk()
    {
        using var playwright = await Playwright.CreateAsync();

        var userDataDir = Path.Combine(StorageStatePaths.SolutionDirectory, "BrowserProfile");

        var context = await playwright.Chromium.LaunchPersistentContextAsync(userDataDir, new()
        {
            Channel = "chrome",
            Headless = false,
            SlowMo = 300,
            Locale = "en-GB"
        });

        var page = context.Pages.FirstOrDefault() ?? await context.NewPageAsync();

        await page.GotoAsync(TestSettings.BaseUrl);

        await Assertions.Expect(page).ToHaveURLAsync(new Regex(CapitalPagePath.TradingPlatform));

        await context.StorageStateAsync(new()
        {
            Path = StorageStatePaths.Authorized
        });

        await context.CloseAsync();
    }
}
