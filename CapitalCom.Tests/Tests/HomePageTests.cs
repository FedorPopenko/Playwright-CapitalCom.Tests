using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Models;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests.Tests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class HomePageTests : CapitalTestBase
{
    [TestCaseSource(typeof(TestMatrix), nameof(TestMatrix.SmokeContexts))]
    public async Task HomePage_ShouldOpenSuccessfully(TestRunContext context)
    {
        await OpenCapitalPageAsync(context, CapitalPagePath.HomePage);

        await Expect(Page).ToHaveTitleAsync(new Regex("Capital\\.com", RegexOptions.IgnoreCase));
    }
}
