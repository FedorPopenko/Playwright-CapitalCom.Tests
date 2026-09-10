using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Artifacts;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages.About.Who_We_Are;

namespace CapitalCom.Tests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class OurBusinessModelTests : CapitalTestBase
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
    public async Task OurBusinessModelPage_ShouldOpenSuccessfully(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.OurBusinessModelPage);
        var ourBusinessModelPage = new OurBusinessModelPage(Page);

        await ourBusinessModelPage.ExpectLoadedOurBusinessModelPageAsync();
    }

    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.SmokeContexts))]
    public async Task CreateYourAccountButton_ShouldOpenExpectedDestination(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.OurBusinessModelPage);
        var ourBusinessModelPage = new OurBusinessModelPage(Page);

        await CloseLocationFormIfDisplayedAsync(ourBusinessModelPage.locationForm);

        await ExpectСtaClickResultAsync(context, () => ourBusinessModelPage.ClickCreateYourAccountButtonAsync(),
            ourBusinessModelPage.loginAndSignUpForm);
    }
}
