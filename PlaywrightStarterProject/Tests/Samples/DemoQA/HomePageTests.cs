using PlaywrightStarterProject.Pages.Samples.DemoQA;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA;

public class HomePageTests : BaseTest
{
    [SetUp]
    public Task Init() => Pages.HomePage.GotoAsync();

    [Test]
    public async Task CanNavigate()
    {
        await Expect(Page).ToHaveURLAsync("https://demoqa.com/");
        await Expect(Page).ToHaveTitleAsync("demosite");
    }

    [Test]
    public async Task ShowsAllCategoryCards()
    {
        // Aria snapshots assert on the accessible structure of the page in one go.
        await Expect(Pages.HomePage.CategoryCards).ToMatchAriaSnapshotAsync("""
            - link "Elements":
              - /url: /elements
            - link "Forms":
              - /url: /forms
            - link "Alerts, Frame & Windows":
              - /url: /alertsWindows
            - link "Widgets":
              - /url: /widgets
            - link "Interactions":
              - /url: /interaction
            - link "Book Store Application":
              - /url: /books
            """);
    }

    [Test]
    public async Task CanNavigateToFormsPage()
    {
        await Pages.HomePage.FormsCard.ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex($"{FormsPage.Route}$"));
    }
}
