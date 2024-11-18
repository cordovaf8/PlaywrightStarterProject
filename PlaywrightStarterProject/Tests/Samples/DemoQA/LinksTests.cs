using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA
{
    public class LinksTests : BaseTest
    {
        [SetUp]
        public async Task Init()
        {
            await BasePage.GotoAsync(Pages.HomePage.Url + Pages.LinksPage.Route);
        }

        [Test]
        public async Task VerifyUrlInNewTab()
        {
            await Pages.LinksPage.HomeInNewTabLink.ClickAsync();

            var newTab1 = BasePage.Context.Pages[BasePage.Context.Pages.Count - 1];

            newTab1.Url.Should().Contain(Pages.HomePage.Url);
            BasePage.Url.Should().Contain(Pages.LinksPage.Route);
        }
    }
}
