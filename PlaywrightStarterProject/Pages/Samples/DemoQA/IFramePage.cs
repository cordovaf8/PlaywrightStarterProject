namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

public class IFramePage(IPage page)
{
    public const string Route = "/frames";

    public IFrameLocator Frame1 => page.Locator("#frame1").ContentFrame;
    public IFrameLocator Frame2 => page.Locator("#frame2").ContentFrame;

    public static ILocator Heading(IFrameLocator frame) => frame.GetByRole(AriaRole.Heading);

    public Task GotoAsync() => page.GotoAsync(Route);
}
