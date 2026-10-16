namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

public class LoginPage(IPage page)
{
    public const string Route = "/login";

    public ILocator UserNameInput => page.GetByPlaceholder("UserName");
    public ILocator PasswordInput => page.GetByPlaceholder("Password");
    public ILocator LoginButton => page.GetByRole(AriaRole.Button, new() { Name = "Login" });
    public ILocator LogoutButton => page.GetByRole(AriaRole.Button, new() { Name = "Log out" });

    public async Task LoginAsync(string userName, string password)
    {
        await UserNameInput.FillAsync(userName);
        await PasswordInput.FillAsync(password);
        await LoginButton.ClickAsync();

        await LogoutButton.WaitForAsync();
    }

    public Task GotoAsync() => page.GotoAsync(Route);
}
