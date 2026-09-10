using CapitalCom.Tests.Core.Models;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests.Pages.About.Who_We_Are
{
    public class OurBusinessModelPage
    {
        private readonly IPage _page;

        private ILocator SpreadsBlock => _page.Locator("p:has-text('EUR/USD')");
        private ILocator ButtonCreateYourAccount => _page.Locator("button[data-type='banner_with_steps']");

        public OurBusinessModelPage(IPage page)
        {
            _page = page;
            loginAndSignUpForm = new LoginAndSignUpForm(page);
            locationForm = new LocationForm(page);
        }

        public LoginAndSignUpForm loginAndSignUpForm { get; }
        public LocationForm locationForm { get; }

        public async Task ExpectLoadedOurBusinessModelPageAsync()
        {
            await Assertions.Expect(_page).ToHaveURLAsync(new Regex(CapitalPagePath.OurBusinessModelPage));
            await Assertions.Expect(SpreadsBlock).ToBeVisibleAsync();
        }

        public async Task ClickCreateYourAccountButtonAsync()
        {
            await ButtonCreateYourAccount.ClickAsync();
        }
    }
}
