# Playwright Starter Project

A starter UI test suite for [DemoQA](https://demoqa.com) built with
[Playwright for .NET](https://playwright.dev/dotnet/), NUnit and the page object pattern.

## Stack

- .NET 10, C# latest
- Microsoft.Playwright.NUnit 1.63 (`PageTest` base class, web-first `Expect` assertions)
- NUnit 4

## Getting started

```bash
dotnet build
```

```bash
pwsh PlaywrightStarterProject/bin/Debug/net10.0/playwright.ps1 install chromium
```

```bash
dotnet test
```

The `playwright.ps1` commands need PowerShell 7 (`pwsh`). On Windows without it, use `powershell -File` instead.

## Configuration

Browser, headless mode, `Expect` timeout and parallel workers are set in
[`PlaywrightStarterProject/.runsettings`](PlaywrightStarterProject/.runsettings).
Any value can be overridden on the command line:

```bash
dotnet test -- Playwright.BrowserName=firefox Playwright.LaunchOptions.Headless=false
```

Set `HEADED=1` to watch tests run, or `PWDEBUG=1` to step through them with the Playwright Inspector.

The Book Store tests need a DemoQA account. Set `DEMOQA_USERNAME` and `DEMOQA_PASSWORD`
(locally as environment variables, in CI as repository secrets); without them those tests are skipped.

## Debugging failures

Every test records a [trace](https://playwright.dev/dotnet/docs/trace-viewer); traces for failed tests are
saved to `bin/Debug/net10.0/playwright-traces/` (and uploaded as an artifact in CI). Open one with:

```bash
pwsh PlaywrightStarterProject/bin/Debug/net10.0/playwright.ps1 show-trace <path-to-trace.zip>
```

Or drop the zip onto [trace.playwright.dev](https://trace.playwright.dev).

To generate locators for a new page, use codegen:

```bash
pwsh PlaywrightStarterProject/bin/Debug/net10.0/playwright.ps1 codegen https://demoqa.com
```

## Project layout

```
PlaywrightStarterProject/
├── Pages/Samples/DemoQA/   page objects (DemoQaPages is the entry point)
├── Tests/BaseTest.cs       context options, ad blocking, tracing
├── Tests/Samples/DemoQA/   test fixtures
└── TestData/               files used by tests (e.g. uploads)
```

## Conventions

- Prefer user-facing locators: `GetByRole`, `GetByPlaceholder`, `GetByText`, `GetByLabel`. Fall back to CSS ids
  only when the page gives nothing better. Avoid XPath.
- Assert with `await Expect(locator)...` so assertions auto-wait and retry; avoid reading values and comparing them
  yourself.
- Never use fixed sleeps; Playwright's actions and assertions already wait.
