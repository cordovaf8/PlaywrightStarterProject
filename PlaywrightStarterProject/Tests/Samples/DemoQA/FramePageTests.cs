using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA
{
    public class FramePageTests : BaseTest
    {
        [Test]
        public async Task CanNavigateAndVerifyIFrameContents()
        {
            var iFrameTextContent = "This is a sample page";
            await BasePage.GotoAsync(Pages.HomePage.Url + Pages.IFramePage.Route);

            var frame1TextContent = await Pages.IFramePage.IFrame1.Locator(Pages.IFramePage.IFrameHeader).TextContentAsync(); ;

            //.TextContentAsync();
            var frame2TextContent = await Pages.IFramePage.IFrame2.Locator(Pages.IFramePage.IFrameHeader).TextContentAsync(); ;

            frame1TextContent.Should().Be(iFrameTextContent);
            frame2TextContent.Should().Be(iFrameTextContent);

        }
    }
}
