namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

public class HomePage(IPage page)
{
    public const string Route = "/";

    public ILocator CategoryCards => page.Locator(".category-cards");

    public ILocator Card(string name) => CategoryCards.GetByRole(AriaRole.Link, new() { Name = name, Exact = true });

    public ILocator FormsCard => Card("Forms");

    public Task GotoAsync() => page.GotoAsync(Route);
}
