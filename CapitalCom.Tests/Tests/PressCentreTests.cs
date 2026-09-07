using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Artifacts;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages.About.Who_We_Are;

namespace CapitalCom.Tests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class PressCentreTests : CapitalTestBase
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

    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.EnglishContexts))]
    public async Task PressCentrePage_ShouldOpenSuccessfully(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.PressCentrePage);
        var pressCentrePage = new PressCentrePage(Page);

        await pressCentrePage.ExpectLoadedPressCentrePageAsync();
    }

    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.EnglishContexts))]
    public async Task TradeButton_ShouldOpenExpectedDestination(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.PressCentrePage);
        var pressCentrePage = new PressCentrePage(Page);

        await CloseLocationFormIfDisplayedAsync(pressCentrePage.locationForm);

        await ExpectСtaClickResultAsync(context, () => pressCentrePage.ClickTradeButtonAsync(),
            pressCentrePage.loginAndSignUpForm);
    }
}
