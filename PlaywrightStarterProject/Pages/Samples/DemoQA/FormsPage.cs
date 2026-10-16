namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

public class FormsPage(IPage page)
{
    public const string Route = "/forms";

    // Collapsed sidebar groups are hidden, and role locators skip hidden elements,
    // so this only matches the link inside the expanded "Forms" group.
    public ILocator PracticeFormLink => page.GetByRole(AriaRole.Link, new() { Name = "Practice Form" });

    public Task GotoAsync() => page.GotoAsync(Route);
}
