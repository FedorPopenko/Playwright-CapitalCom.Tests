using CapitalCom.Tests.Core.Models;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests.Pages.About.Who_We_Are
{
    public class PressCentrePage
    {
        private readonly IPage _page;

        private ILocator BannerOnThePage => _page.Locator("p:has-text('shamillia.sivathambu@capital.com')");
        private ILocator ButtonTrade => _page.Locator("button[data-type='wdg_most_traded_btn']").First;

        public PressCentrePage(IPage page)
        {
            _page = page;
            loginAndSignUpForm = new LoginAndSignUpForm(page);
            locationForm = new LocationForm(page);
        }

        public LoginAndSignUpForm loginAndSignUpForm { get; }
        public LocationForm locationForm { get; }

        public async Task ExpectLoadedPressCentrePageAsync()
        {
            await Assertions.Expect(_page).ToHaveURLAsync(new Regex(CapitalPagePath.PressCentrePage));
            await Assertions.Expect(BannerOnThePage).ToBeVisibleAsync();
        }

        public async Task ClickTradeButtonAsync()
        {
            await ButtonTrade.ClickAsync();
        }
    }
}
