using Microsoft.Playwright;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class IFramePage
    {
        private readonly IPage _page;

        internal IFramePage(IPage page)
        {
            _page = page;
        }

        public readonly String Route = "/frames";

        public IFrameLocator IFrame1 => _page.FrameLocator($"//div[@id='frame1Wrapper']//iframe");
        public ILocator IFrameHeader => _page.Locator("//h1");

        public IFrameLocator IFrame2 => _page.FrameLocator($"//div[@id='frame2Wrapper']//iframe");
        public ILocator IFrameSamplePageTextContent => _page.Locator($"//h1[text()='This is a sample page']");
        public ILocator IFrameByIndex(int index) => _page.Locator($"//iframe[{index}]");
    }
}
