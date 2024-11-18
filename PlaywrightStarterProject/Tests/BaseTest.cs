using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywrightStarterProject.Pages;
using Microsoft.Playwright;
using PlaywrightStarterProject.Pages.Samples.DemoQA;
using System.Net;
using Polly;

namespace PlaywrightStarterProject.Tests
{
    public class BaseTest
    {
        public WaitHelper WaitHelper { get; set; }
        public TestUtilities TestUtilities { get; set; }
        public Dictionary<String, String> Configuration { get; set; }
        public PlaywrightStarterProject.Pages.Pages Pages { get; set; }
        protected IBrowserContext Browser { get; private set; } = null!;
        protected IPage BasePage { get; set; }


        public BaseTest()
        {
            
        }

        [SetUp]
        public async Task StartTest()
        {
            BrowserNewContextOptions contextOptions = new()
            {
                BaseURL = "https://demoqa.com",
                ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 },
                ScreenSize = new ScreenSize() { Width = 1920, Height = 1080 }
            };

            var playwright = await Playwright.CreateAsync();
            playwright.Selectors.SetTestIdAttribute("id");
            var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false, SlowMo=500 });
            BasePage = await browser.NewPageAsync();

            try
            {
                await BasePage.GotoAsync("https://demoqa.com", new() { WaitUntil = WaitUntilState.DOMContentLoaded });
                Pages = new Pages.Pages(BasePage);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            //Driver.Quit();
        }
    }
}
