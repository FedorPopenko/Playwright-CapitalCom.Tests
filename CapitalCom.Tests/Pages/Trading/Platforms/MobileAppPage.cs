using CapitalCom.Tests.Core.Models;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using System.Web;

namespace CapitalCom.Tests.Pages.Trading.Platforms
{
    public class MobileAppPage
    {
        private readonly IPage _page;

        private ILocator BunnerTitle => _page.Locator("h1:has-text('500+')");
        private ILocator QrCodes => _page.GetByAltText("QR code").Filter(new() { Visible = true });

        public MobileAppPage(IPage page)
        {
            _page = page;
        }

        public async Task ExpectLoadedMobileAppPageAsync()
        {
            await Assertions.Expect(_page).ToHaveURLAsync(new Regex(CapitalPagePath.MobileAppPage));
            await Assertions.Expect(BunnerTitle).ToBeVisibleAsync();
        }

        public async Task<int> GetQrCodeCountAsync()
        {
            return await QrCodes.CountAsync();
        }

        public async Task<string?> GetQrCodeUrlAsync(int index)
        {
            var src = await QrCodes.Nth(index).GetAttributeAsync("src");

            if (string.IsNullOrWhiteSpace(src))
            {
                return null;
            }

            var uri = new Uri(new Uri(_page.Url), src);
            var query = HttpUtility.ParseQueryString(uri.Query);

            return query["content"];
        }
    }
}
