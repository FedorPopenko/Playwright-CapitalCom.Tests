using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Artifacts;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages.Trading.Platforms;

namespace CapitalCom.Tests.Tests.AboutTests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class WebPlatfomTests : CapitalTestBase
{
    [SetUpFixture]
    public sealed class TestRunCleanup
    {
        [OneTimeTearDown]
        public void Cleanup()
        {
            ArtifactClaener.DeletePassedVideos();
        }
    }

    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.SmokeContexts))]
    public async Task WebPlatformPage_ShouldOpenSuccessfully(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.WebPlatformPage);
        var webPlatformPage = new WebPlatformPage(Page);

        await webPlatformPage.ExpectLoadedWebPlatformPageAsync();
    }

    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.SmokeContexts))]
    public async Task ExplorePlatformButton_ShouldOpenExpectedDestination(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.WebPlatformPage);
        var webPlatformPage = new WebPlatformPage(Page);

        await CloseLocationFormIfDisplayedAsync(webPlatformPage.locationForm);

        await ExpectСtaClickResultAsync(context, () => webPlatformPage.ClickExplorePlatformButtonAsync(),
        webPlatformPage.loginAndSignUpForm);
    }
}
