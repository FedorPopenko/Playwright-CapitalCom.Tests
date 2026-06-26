using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages.About.Who_We_Are;

namespace CapitalCom.Tests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CompanyTests : CapitalTestBase
{
    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.SmokeContexts))]
    public async Task CompanyPage_ShouldOpenSuccessfully(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.CompanyPage);
        var companyPage = new CompanyPage(Page);

        await companyPage.ExpectLoadedCompanyPageAsync();
    }
}
