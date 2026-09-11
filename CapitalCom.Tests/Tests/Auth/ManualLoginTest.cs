using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Fixtures;
using CapitalCom.Tests.Pages;
using Microsoft.Playwright;

namespace CapitalCom.Tests;

public class ManualLoginTest
{

    [Test]
    [Explicit("Use this test to complete CAPTCHA or MFA manually and refresh the authorized storage state.")]
    [NonParallelizable]
    public async Task SaveAuthorizedStateWithVisibleChromeAsync()
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

        var loginForm = new LoginAndSignUpForm(page);
        await TestContext.Progress.WriteLineAsync(
            "Complete sign-in, CAPTCHA, and MFA in the opened Chrome window. The test will continue after the sign-in form closes.");

        await Assertions.Expect(loginForm.LoginFormCloseButton).ToBeVisibleAsync(new()
        {
            Timeout = 120_000
        });

        await Assertions.Expect(loginForm.LoginFormCloseButton).ToBeHiddenAsync(new()
        {
            Timeout = 120_000
        });

        var candidateStatePath = Path.Combine(StorageStatePaths.AuthDirectory, "authorized-user.candidate.json");

        try
        {
            await context.StorageStateAsync(new()
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

        await context.CloseAsync();
    }
}
