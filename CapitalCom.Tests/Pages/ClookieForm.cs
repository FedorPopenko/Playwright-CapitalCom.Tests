using Microsoft.Playwright;

namespace CapitalCom.Tests.Pages
{
    public sealed class ClookieForm
    {
        private readonly IPage _page;

        public ClookieForm(IPage page)
        {
            _page = page;
        }

        public ILocator CookieBanner => _page.Locator("dialog[aria-label='Cookie banner']");
        public ILocator RejectButton => _page.Locator("button[data-action='reject']");
        public ILocator AcceptButton => _page.Locator("button[data-action='accept']");
        public ILocator CustomizeButton => _page.Locator("button[data-action='customize']");

        public async Task ExpectCookieFormVisibleAsync()
        {
            await Assertions.Expect(CookieBanner).ToBeVisibleAsync();
        }

        public async Task ClickRejectButton()
        {
            await RejectButton.ClickAsync();
        }

        public async Task ClickAcceptButton()
        {
            await AcceptButton.ClickAsync();
        }

        public async Task ClickCustomizeButton()
        {
            await CustomizeButton.ClickAsync();
        }
    }
}
