using PlaywrightStarterProject.Pages.Samples.DemoQA;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA;

public class LinksTests : BaseTest
{
    [SetUp]
    public Task Init() => Pages.LinksPage.GotoAsync();

    [Test]
    public async Task VerifyUrlInNewTab()
    {
        // Start listening for the new tab before the click that opens it.
        var newTab = await Context.RunAndWaitForPageAsync(() => Pages.LinksPage.HomeInNewTabLink.ClickAsync());

        await Expect(newTab).ToHaveURLAsync("https://demoqa.com/");
        await Expect(Page).ToHaveURLAsync(new Regex($"{LinksPage.Route}$"));
    }
}
