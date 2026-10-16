namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

/// <summary>Entry point to every DemoQA page object, all bound to the same <see cref="IPage"/>.</summary>
public class DemoQaPages(IPage page)
{
    public HomePage HomePage { get; } = new(page);
    public FormsPage FormsPage { get; } = new(page);
    public PracticeFormPage PracticeFormPage { get; } = new(page);
    public LinksPage LinksPage { get; } = new(page);
    public LoginPage LoginPage { get; } = new(page);
    public BookStorePage BookStorePage { get; } = new(page);
    public ProfilePage ProfilePage { get; } = new(page);
    public WebTablePage WebTablePage { get; } = new(page);
    public IFramePage IFramePage { get; } = new(page);
}
