using CapitalCom.Tests.Core.Models;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests.Pages.About.Who_We_Are
{
    public class IsCapitalComSafePage
    {
        private readonly IPage _page;

        private ILocator BannerOnThePage => _page.Locator("#bannerHomePage");
        private ILocator ButtonOpenAnAccount => _page.Locator("button[data-type='homepage_hero_banner_btn1_signup']");

        public IsCapitalComSafePage(IPage page)
        {
            _page = page;
            loginAndSignUpForm = new LoginAndSignUpForm(page);
            locationForm = new LocationForm(page);
        }

        public LoginAndSignUpForm loginAndSignUpForm { get; }
        public LocationForm locationForm { get; }

        public async Task ExpectLoadedIsCapitalComSafePageAsync()
        {
            await Assertions.Expect(_page).ToHaveURLAsync(new Regex(CapitalPagePath.IsCapitalComSafePage));
            await Assertions.Expect(BannerOnThePage).ToBeVisibleAsync();
        }

        public async Task ClickOpenAnAccountButtonAsync()
        {
            await ButtonOpenAnAccount.ClickAsync();
        }
    }
}
