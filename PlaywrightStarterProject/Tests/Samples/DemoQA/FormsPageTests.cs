using PlaywrightStarterProject.Pages.Samples.DemoQA;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA;

public class FormsPageTests : BaseTest
{
    [Test]
    public async Task CanNavigateToPracticeForm()
    {
        await Pages.HomePage.GotoAsync();

        await Pages.HomePage.FormsCard.ClickAsync();
        await Pages.FormsPage.PracticeFormLink.ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex($"{PracticeFormPage.Route}$"));
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Practice Form" })).ToBeVisibleAsync();
    }
}
