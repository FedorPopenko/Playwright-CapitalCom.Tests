using CapitalCom.Tests.Core;
using CapitalCom.Tests.Core.Models;
using CapitalCom.Tests.Pages.About.Who_We_Are;

namespace CapitalCom.Tests;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class OurOfficesTests : CapitalTestBase
{
    [SetUp]
    public async Task StartTraceAsync()
    {
        await Context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
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

        await ExpectСtaClickResultAsync(context, () => ourOfficesPage.ClickCreateYourAccountButtonAsync(),
            ourOfficesPage.loginAndSignUpForm);
    }

    [TearDown]
    public async Task StopTraceAsync()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        var status = TestContext.CurrentContext.Result.Outcome.Status;

        if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            var tracePath = Path.Combine(TestContext.CurrentContext.WorkDirectory,
                "test-result",
                $"{SanitizeFileName(testName)}.zip");

            await Context.Tracing.StopAsync(new()
            {
                Path = tracePath,
            });

            await TestContext.Out.WriteLineAsync($"Trace saved; {tracePath}");
        }
        else
        {
            await Context.Tracing.StopAsync();
        }
    }

    private static string SanitizeFileName(string fileName)
    {
        foreach (var invalidChar in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(invalidChar, '_');
        }

        return fileName;
    }
}
