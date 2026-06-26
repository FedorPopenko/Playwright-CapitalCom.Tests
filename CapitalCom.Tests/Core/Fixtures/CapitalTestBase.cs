using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests.Core;

public abstract class CapitalTestBase : PageTest
{
    public override BrowserNewContextOptions ContextOptions()
    {
        var options = base.ContextOptions();
        var context = GetCurrentRunContext();

        if (context is null)
        {
            return options;
        }

        options.Locale = CapitalLocaleProvider.GetLocale(context.Language);
        options.RecordVideoDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "test-results", "videos"); //для записи падающих тестов

        var storageStatePath = StorageStateProvider.GetStorageStatePath(context.UserSessionState);
        if (storageStatePath is not null)
        {
            var absoluteStorageStatePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, storageStatePath);
            if (File.Exists(absoluteStorageStatePath))
            {
                options.StorageStatePath = absoluteStorageStatePath;
            }
        }

        return options;
    }

    protected async Task OpenCapitalPageAsync(TestRunContext context, string pagePath)
    {
        var baseUrl = CapitalUrlBuilder.Build(context.License, context.Language, context.Country);

        var url = string.IsNullOrWhiteSpace(pagePath) ? baseUrl : baseUrl + pagePath;

        await TestContext.Out.WriteLineAsync($"Opening URL: {url}");

        await Page.GotoAsync(url, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.DOMContentLoaded
        });
    }

    protected async Task ExpectСtaClickResultAsync(TestRunContext context, Func<Task> clickAction, LoginAndSignUpForm loginAndSignUp) // CTA-Call to action (кнопка призыва к действию)
    {
        await clickAction();

        switch (context.UserSessionState)
        {
            case UserSessionState.Authorized:
                await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
                await Assertions.Expect(Page).ToHaveURLAsync(new Regex(CapitalPagePath.TradingPlatform)); // RegexOptions.IgnoreCase - если нужно прировнять регистр букв
                break;

            case UserSessionState.Unregistered:
                await loginAndSignUp.ExpectSignUpFormVisibleAsync();
                break;

            case UserSessionState.Unauthorized:
                await loginAndSignUp.ExpectSignUpFormVisibleAsync(); // ExpectLoginFormVisibleAsync()
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(context), context.UserSessionState,
                    $"Unsupported user session state for CTA click result. Context: {context.UserSessionState}");
        }
    }

    private static TestRunContext? GetCurrentRunContext()
    {
        return TestContext.CurrentContext.Test.Arguments
            .OfType<TestRunContext>()
            .SingleOrDefault();
    }
}
