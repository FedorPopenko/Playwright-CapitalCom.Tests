using Microsoft.Playwright;

namespace CapitalCom.Tests.Pages
{
    public sealed class LocationForm
    {
        private readonly IPage _page;

        public LocationForm(IPage page)
        {
            _page = page;
        }

        public ILocator StayHereButton => _page.Locator("button[data-type='wrong_location_cancel']");
        public ILocator LocalSiteButton => _page.Locator("button[data-type='wrong_location_apply']");

        public async Task CloseIfDisplayedAsync()
        {
            try
            {
                await StayHereButton.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 5000
                });

                await StayHereButton.ClickAsync();
            }
            catch (TimeoutException)
            {
                //Loсation Form is not displayed!
            }
        }
        public async Task ExpectLocationFormVisibleAsync()
        {
            await Assertions.Expect(StayHereButton).ToBeVisibleAsync();
        }

        public async Task ClickLocalSiteButtonAsync()
        {
            await LocalSiteButton.ClickAsync();
        }

        public async Task ClickStayHereButtonAsync()
        {
            await StayHereButton.ClickAsync();
        }
    }
}
