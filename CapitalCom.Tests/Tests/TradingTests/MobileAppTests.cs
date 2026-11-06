using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Artifacts;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages.Trading.Platforms;

namespace CapitalCom.Tests.Tests.TradingTests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class MobileAppTests : CapitalTestBase
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
    public async Task MobileAppPage_ShouldOpenSuccessfully(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.MobileAppPage);
        var mobileAppPage = new MobileAppPage(Page);

        await mobileAppPage.ExpectLoadedMobileAppPageAsync();
    }

    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.SmokeContexts))]
    public async Task AllQrCodes_ShouldContainExpectedUrl(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.MobileAppPage);
        var mobileAppPage = new MobileAppPage(Page);

        var qrCodeCount = await mobileAppPage.GetQrCodeCountAsync();
        Assert.That(qrCodeCount, Is.EqualTo(4));

        for (int i = 0; i < qrCodeCount; i++)
        {
            var actualUrl = await mobileAppPage.GetQrCodeUrlAsync(i);
            Assert.That(actualUrl, Is.Not.Null.And.Not.Empty);
            await ExpectQrCodeResultAsync(actualUrl!);
        }
    }
}
