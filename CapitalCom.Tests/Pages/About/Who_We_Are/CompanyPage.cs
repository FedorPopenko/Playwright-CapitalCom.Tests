using CapitalCom.Tests.Core.Models;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests.Pages.About.Who_We_Are
{
    public class CompanyPage
    {
        private readonly IPage _page;

        private ILocator BunnerTitle => _page.Locator("h1:has-text('2016')");

        public CompanyPage(IPage page)
        {
            _page = page;
        }

        public async Task ExpectLoadedCompanyPageAsync()
        {
            await Assertions.Expect(_page).ToHaveURLAsync(new Regex(CapitalPagePath.CompanyPage));
            await Assertions.Expect(BunnerTitle).ToBeVisibleAsync();
        }
    }
}
