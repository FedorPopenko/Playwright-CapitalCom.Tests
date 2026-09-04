using CapitalCom.Tests.Core.Models;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests.Pages.About.Who_We_Are
{
    public class InvestorRelationsPage
    {
        private readonly IPage _page;

        private ILocator BannerOnThePage => _page.Locator("p:has-text('$1.7')").First;
        private ILocator ButtonCreateYourAccount => _page.Locator("button[data-type='banner_with_steps']");

        public InvestorRelationsPage(IPage page)
        {
            _page = page;
            loginAndSignUpForm = new LoginAndSignUpForm(page);
            locationForm = new LocationForm(page);
        }

        public LoginAndSignUpForm loginAndSignUpForm { get; }
        public LocationForm locationForm { get; }

        public async Task ExpectLoadedInvestorRelationsPageAsync()
        {
            await Assertions.Expect(_page).ToHaveURLAsync(new Regex(CapitalPagePath.InvestorRelationsPage));
            await Assertions.Expect(BannerOnThePage).ToBeVisibleAsync();
        }

        public async Task ClickCreateYourAccountButtonAsync()
        {
            await ButtonCreateYourAccount.ClickAsync();
        }
    }
}
