using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Artifacts;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages.About.Who_We_Are;

namespace CapitalCom.Tests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class InvestorRelationsPageTests : CapitalTestBase
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
    public async Task InvestorRelationsPage_ShouldOpenSuccessfully(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.InvestorRelationsPage);
        var investorRelationsPage = new InvestorRelationsPage(Page);

        await investorRelationsPage.ExpectLoadedInvestorRelationsPageAsync();
    }

    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.EnglishContexts))]
    public async Task CreateYourAccountButton_ShouldOpenExpectedDestination(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.InvestorRelationsPage);
        var investorRelationsPage = new InvestorRelationsPage(Page);

        await CloseLocationFormIfDisplayedAsync(investorRelationsPage.locationForm);

        await ExpectСtaClickResultAsync(context, () => investorRelationsPage.ClickCreateYourAccountButtonAsync(),
            investorRelationsPage.loginAndSignUpForm);
    }
}
