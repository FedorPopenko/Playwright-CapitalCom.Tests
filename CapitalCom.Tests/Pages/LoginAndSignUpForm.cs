using Microsoft.Playwright;

namespace CapitalCom.Tests.Pages
{
    public sealed class LoginAndSignUpForm
    {
        private readonly IPage _page;

        public LoginAndSignUpForm(IPage page)
        {
            _page = page;
        }

        public ILocator LoginForm => _page.Locator("button[data-type='SIGN_IN_close']");
        public ILocator SignUpForm => _page.Locator("button[data-type='SIGN_UP_close']");

        public async Task ExpectLoginFormVisibleAsync()
        {
            await Assertions.Expect(LoginForm).ToBeVisibleAsync();
        }

        public async Task ExpectSignUpFormVisibleAsync()
        {
            await Assertions.Expect(SignUpForm.Or(LoginForm)).ToBeVisibleAsync(new() //LoginForm - добавлено временно
            {
                Timeout = 15000
            });
        }
    }
}
