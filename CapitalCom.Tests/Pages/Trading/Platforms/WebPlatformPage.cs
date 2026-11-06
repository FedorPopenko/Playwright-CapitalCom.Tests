using CapitalCom.Tests.Core.Models;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests.Pages.Trading.Platforms
{
    public class WebPlatformPage
    {
        private readonly IPage _page;

        private ILocator BunnerText => _page.Locator("p:has-text('100+')").First;
        private ILocator ButtonExplorePlatform => _page.Locator("button[data-type='homepage_hero_banner_btn2_signup']");

        public WebPlatformPage(IPage page)
        {
            _page = page;
            loginAndSignUpForm = new LoginAndSignUpForm(page);
            locationForm = new LocationForm(page);
        }
        public LoginAndSignUpForm loginAndSignUpForm { get; }
        public LocationForm locationForm { get; }


        public async Task ExpectLoadedWebPlatformPageAsync()
        {
            await Assertions.Expect(_page).ToHaveURLAsync(new Regex(CapitalPagePath.WebPlatformPage));
            await Assertions.Expect(BunnerText).ToBeVisibleAsync();
        }

        public async Task ClickExplorePlatformButtonAsync()
        {
            await ButtonExplorePlatform.ClickAsync();
        }
    }
}
