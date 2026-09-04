using Microsoft.Playwright;

namespace CapitalCom.Tests.Pages
{
    public sealed class CookieForm
    {
        private readonly IPage _page;

        public CookieForm(IPage page)
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

        public async Task RejectCookieAsync()
        {
            await RejectButton.ClickAsync();
        }

        public async Task AcceptCookieAsync()
        {
            await AcceptButton.ClickAsync();
        }

        public async Task CustomizeCookieAsync()
        {
            await CustomizeButton.ClickAsync();
        }
    }
}
