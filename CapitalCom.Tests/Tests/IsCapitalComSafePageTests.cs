using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Artifacts;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages.About.Who_We_Are;

namespace CapitalCom.Tests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class IsCapitalComSafePageTests : CapitalTestBase
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
    public async Task IsCapitalComSafePage_ShouldOpenSuccessfully(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.IsCapitalComSafePage);
        var isCapitalComSafePage = new IsCapitalComSafePage(Page);

        await isCapitalComSafePage.ExpectLoadedIsCapitalComSafePageAsync();
    }

    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.SmokeContexts))]
    public async Task OpenAnAccountButton_ShouldOpenExpectedDestination(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.IsCapitalComSafePage);
        var isCapitalComSafePage = new IsCapitalComSafePage(Page);

        await CloseLocationFormIfDisplayedAsync(isCapitalComSafePage.locationForm);

        await ExpectСtaClickResultAsync(context, () => isCapitalComSafePage.ClickOpenAnAccountButtonAsync(),
            isCapitalComSafePage.loginAndSignUpForm);
    }
}
