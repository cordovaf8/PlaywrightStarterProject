using FluentAssertions;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA
{
    public class HomePageTests : BaseTest
    {
        [Test]
        public async Task CanNavigate()
        {
            await BasePage.GotoAsync(Pages.HomePage.Url);

            await BasePage.WaitForURLAsync(url => url.Contains(Pages.HomePage.Url));

            BasePage.Url.Should().Contain(Pages.HomePage.Url);
        }

        [Test]
        public async Task CanNavigateToFormsPage()
        {
            await BasePage.GotoAsync(Pages.HomePage.Url);

            await Pages.HomePage.FormsCard.ClickAsync();

            await BasePage.WaitForURLAsync(url => url.Contains(Pages.FormsPage.Route));

            BasePage.Url.Should().Contain(Pages.FormsPage.Route);
        }
    }
}
