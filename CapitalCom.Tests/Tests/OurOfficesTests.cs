using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Artifacts;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages.About.Who_We_Are;

namespace CapitalCom.Tests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class OurOfficesTests : CapitalTestBase
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
    public async Task OurOfficesPage_ShouldOpenSuccessfully(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.OurOfficesPage);
        var ourOfficesPage = new OurOfficesPage(Page);

        await ourOfficesPage.ExpectLoadedOurOfficesPageAsync();
    }

    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.SmokeContexts))]
    public async Task CreateYourAccountButton_ShouldOpenExpectedDestination(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.OurOfficesPage);
        var ourOfficesPage = new OurOfficesPage(Page);

        await CloseLocationFormIfDisplayedAsync(ourOfficesPage.locationForm);

        await ExpectСtaClickResultAsync(context, () => ourOfficesPage.ClickCreateYourAccountButtonAsync(),
            ourOfficesPage.loginAndSignUpForm);
    }
}
