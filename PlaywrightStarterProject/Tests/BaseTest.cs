using NUnit.Framework.Interfaces;
using PlaywrightStarterProject.Pages.Samples.DemoQA;

namespace PlaywrightStarterProject.Tests;

/// <summary>
/// Base class for all UI tests. <see cref="PageTest"/> gives every test its own isolated
/// browser context and page, configured through <c>.runsettings</c>.
/// </summary>
[Parallelizable(ParallelScope.Self)]
public abstract class BaseTest : PageTest
{
    // DemoQA is ad-heavy; blocking these keeps tests fast and stops overlays from stealing clicks.
    private static readonly Regex AdAndTrackingHosts = new(
        @"^https?://([^/]+\.)?(googlesyndication\.com|doubleclick\.net|googletagservices\.com|googletagmanager\.com|google-analytics\.com|adservice\.google\.com|ad\.plus|amazon-adsystem\.com|pubmatic\.com|criteo\.(com|net)|rubiconproject\.com|taboola\.com|outbrain\.com)/",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static string TraceDirectory =>
        Path.Combine(TestContext.CurrentContext.WorkDirectory, "playwright-traces");

    protected DemoQaPages Pages { get; private set; } = null!;

    public override BrowserNewContextOptions ContextOptions() => new()
    {
        BaseURL = "https://demoqa.com",
        ViewportSize = new() { Width = 1920, Height = 1080 },
    };

    [SetUp]
    public async Task BaseSetUp()
    {
        await Context.RouteAsync(AdAndTrackingHosts, route => route.AbortAsync());

        await Context.Tracing.StartAsync(new()
        {
            Title = TestContext.CurrentContext.Test.FullName,
            Screenshots = true,
            Snapshots = true,
            Sources = true,
        });

        Pages = new DemoQaPages(Page);
    }

    [TearDown]
    public async Task BaseTearDown()
    {
        // Only keep traces for failures. Open them with: pwsh bin/Debug/net10.0/playwright.ps1 show-trace <file>
        var outcome = TestContext.CurrentContext.Result.Outcome.Status;
        var failed = outcome is TestStatus.Failed;

        string? tracePath = null;
        if (failed)
        {
            Directory.CreateDirectory(TraceDirectory);
            var fileName = string.Concat(TestContext.CurrentContext.Test.FullName.Split(Path.GetInvalidFileNameChars()));
            tracePath = Path.Combine(TraceDirectory, $"{fileName}.zip");
        }

        await Context.Tracing.StopAsync(new() { Path = tracePath });

        if (tracePath is not null)
        {
            TestContext.AddTestAttachment(tracePath, "Playwright trace");
        }
    }
}
