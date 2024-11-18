using FluentAssertions;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA
{
    public class FormsPageTests : BaseTest
    {
        [Test]
        public async Task CanNavigateToPracticeForm()
        {
            await BasePage.GotoAsync(Pages.HomePage.Url);

            await Pages.HomePage.FormsCard.ClickAsync();
            await Pages.FormsPage.PracticeFormsLink.ClickAsync();

            await BasePage.WaitForURLAsync(url => url.Contains(Pages.PracticeFormPage.Route));

            BasePage.Url.Should().Contain(Pages.PracticeFormPage.Route);
        }
    }
}
