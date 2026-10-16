using PlaywrightStarterProject.Pages.Samples.DemoQA;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA;

public class FramePageTests : BaseTest
{
    [Test]
    public async Task CanNavigateAndVerifyIFrameContents()
    {
        await Pages.IFramePage.GotoAsync();

        await Expect(IFramePage.Heading(Pages.IFramePage.Frame1)).ToHaveTextAsync("This is a sample page");
        await Expect(IFramePage.Heading(Pages.IFramePage.Frame2)).ToHaveTextAsync("This is a sample page");
    }
}
