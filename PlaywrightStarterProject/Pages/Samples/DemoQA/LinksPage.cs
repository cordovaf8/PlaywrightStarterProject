namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

public class LinksPage(IPage page)
{
    public const string Route = "/links";

    /// <summary>The static "Home" link, which opens the home page in a new tab.</summary>
    public ILocator HomeInNewTabLink => page.GetByRole(AriaRole.Link, new() { Name = "Home", Exact = true });

    public Task GotoAsync() => page.GotoAsync(Route);
}
