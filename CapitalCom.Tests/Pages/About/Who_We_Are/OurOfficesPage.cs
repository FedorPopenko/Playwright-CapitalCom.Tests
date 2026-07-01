using CapitalCom.Tests.Core.Models;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace CapitalCom.Tests.Pages.About.Who_We_Are
{
    public class OurOfficesPage
    {
        private readonly IPage _page;

        private ILocator UnitedArabEmiratesOffice => _page.Locator("p:has-text('14C')").First;
        private ILocator ButtonCreateYourAccount => _page.Locator("button[data-type='banner_with_steps']");

        public OurOfficesPage(IPage page)
        {
            _page = page;
            loginAndSignUpForm = new LoginAndSignUpForm(page);
            locationForm = new LocationForm(page);
        }

        public LoginAndSignUpForm loginAndSignUpForm { get; }
        public LocationForm locationForm { get; }

        public async Task ExpectLoadedOurOfficesPageAsync()
        {
            await Assertions.Expect(_page).ToHaveURLAsync(new Regex(CapitalPagePath.OurOfficesPage));
            await Assertions.Expect(UnitedArabEmiratesOffice).ToBeVisibleAsync();
        }

        public async Task ClickCreateYourAccountButtonAsync()
        {
            await ButtonCreateYourAccount.ClickAsync();
        }
    }
}
