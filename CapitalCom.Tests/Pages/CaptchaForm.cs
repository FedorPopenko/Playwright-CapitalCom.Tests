using Microsoft.Playwright;

namespace CapitalCom.Tests.Pages
{
    public sealed class CaptchaForm
    {
        private readonly IPage _page;

        public CaptchaForm(IPage page)
        {
            _page = page;
        }

        private ILocator Captcha => _page.Locator("div.h-captcha");

        public async Task ExpectCaptchaFormVisibleAsync()
        {
            await Assertions.Expect(Captcha).ToBeVisibleAsync();
        }
    }
}
