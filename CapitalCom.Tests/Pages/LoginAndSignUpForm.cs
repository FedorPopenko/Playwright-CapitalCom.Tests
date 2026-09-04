using CapitalCom.Tests.Core.Users;
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

        public ILocator LoginFormOpenButton => _page.Locator("button[data-type='btn_header_login']").Last;
        public ILocator LoginFormCloseButton => _page.Locator("button[data-type='SIGN_IN_close']");
        public ILocator LoginEmailField => _page.Locator("#email");
        public ILocator LoginPasswordField => _page.Locator("#password");
        public ILocator LoginContinueButton => _page.Locator("button[type='submit']");
        public ILocator LoginGoogleButton => _page.Locator("#button-label");
        public ILocator LoginErrorMessage => _page.Locator("form[method='post']");
        public ILocator SignUpFormCloseButton => _page.Locator("button[data-type='SIGN_UP_close']");
        public ILocator SignUpFormOpenButton => _page.Locator("button[data-type='btn_header']");


        public async Task OpenLoginFormAsync()
        {
            await LoginFormOpenButton.ClickAsync();
        }
        public async Task ExpectLoginFormVisibleAsync()
        {
            await Assertions.Expect(LoginFormCloseButton).ToBeVisibleAsync();
        }
        public async Task EnterEmailAsync(TestUser user)
        {
            await LoginEmailField.FillAsync(user.Email);
        }
        public async Task EnterPasswordAsync(TestUser user)
        {
            await LoginPasswordField.ClickAsync();
            await LoginPasswordField.PressSequentiallyAsync(user.Password);
        }
        public async Task ClickContinueButtonAsync()
        {
            await LoginContinueButton.ClickAsync();
        }
        public async Task CloseLoginFormAsync()
        {
            await LoginFormCloseButton.ClickAsync();
        }
        public async Task OpenSignUpFormAsync()
        {
            await SignUpFormOpenButton.ClickAsync();
        }
        public async Task ExpectSignUpFormVisibleAsync()
        {
            await Assertions.Expect(SignUpFormCloseButton.Or(LoginFormCloseButton)).ToBeVisibleAsync(new() //LoginForm - добавлено временно
            {
                Timeout = 15000
            });
        }
        public async Task CloseSignUpFormAsync()
        {
            await SignUpFormCloseButton.ClickAsync();
        }
        public async Task LoginAsync(TestUser user)
        {
            await OpenLoginFormAsync();

            await ExpectLoginFormVisibleAsync();

            await EnterEmailAsync(user);
            await EnterPasswordAsync(user);

            await ClickContinueButtonAsync();
        }
    }
}
