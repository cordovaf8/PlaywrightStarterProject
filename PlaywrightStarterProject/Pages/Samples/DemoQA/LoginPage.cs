using Microsoft.Playwright;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class LoginPage
    {
        private readonly IPage _page;

        internal LoginPage(IPage page)
        {
            _page = page;
        }

        public readonly String Route = "/login";

        private readonly String UserName = "Test@888";
        private readonly String Password = "Test@888";

        public ILocator UserNameInput => _page.GetByTestId($"userName");
        public ILocator PasswordInput => _page.GetByTestId($"password");
        public ILocator LoginButton => _page.GetByTestId($"login");
        public ILocator LogoutButton => _page.Locator($"//button[text()='Log out']");


        public async Task Login()
        {
            await UserNameInput.FillAsync(UserName);
            await PasswordInput.FillAsync(Password);
            await LoginButton.ClickAsync();

            await LogoutButton.WaitForAsync(new() { State = WaitForSelectorState.Visible});
        }
    }
}
