namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

public class ProfilePage(IPage page)
{
    public const string Route = "/profile";

    public ILocator SearchBoxInput => page.GetByPlaceholder("Type to search");

    public ILocator BookRow(string title) => page.GetByRole(AriaRole.Table).Locator("tbody tr").Filter(new() { HasText = title });
    public ILocator BookLink(string title) => BookRow(title).GetByRole(AriaRole.Link, new() { Name = title });

    public ILocator DeleteBookModalOkButton => page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    public async Task DeleteBookAsync(string title)
    {
        await BookRow(title).GetByTitle("Delete").ClickAsync();
        await DeleteBookModalOkButton.ClickAsync();
    }

    public Task GotoAsync() => page.GotoAsync(Route);
}
