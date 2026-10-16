namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

public class BookStorePage(IPage page)
{
    public const string Route = "/books";

    public ILocator BookLinks => page.GetByRole(AriaRole.Table).GetByRole(AriaRole.Link);
    public ILocator BookLink(string title) => BookLinks.Filter(new() { HasText = title });

    // Book detail view
    public ILocator BookTitle => page.Locator("#title-wrapper #userName-value");
    public ILocator AddToCollectionButton => page.GetByRole(AriaRole.Button, new() { Name = "Add To Your Collection" });
    public ILocator BackToBookStoreButton => page.GetByRole(AriaRole.Button, new() { Name = "Back To Book Store" });

    public ILocator LoginButton => page.GetByRole(AriaRole.Button, new() { Name = "Login" });
    public ILocator LogoutButton => page.GetByRole(AriaRole.Button, new() { Name = "Log out" });

    public Task GotoAsync() => page.GotoAsync(Route);
}
