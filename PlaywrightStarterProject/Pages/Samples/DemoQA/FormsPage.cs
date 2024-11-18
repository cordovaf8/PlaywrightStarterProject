using Microsoft.Playwright;
using PlaywrightStarterProject.Framework;
using PlaywrightStarterProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class FormsPage
    {
        private readonly IPage _page;

        internal FormsPage(IPage page)
        {
            _page = page;
        }

        public readonly String Route = "/forms";

        public ILocator PracticeFormsLink => _page.Locator($"//span[contains(text(),'Practice Form')]");
        public ILocator FormsDropDownOpenElement => _page.Locator($"//div[@class='header-text' and contains(text(),'Forms')]");
        public ILocator FormDropDownList => _page.Locator("(//div[@class='header-text' and contains(text(),'Forms')]//preceding::div[@class='element-group'][1])//div[contains(@class,'element-list collapse')]");

        public async Task<bool> IsFormDropDownOpen() => (await FormDropDownList.GetAttributeAsync("class")).Contains("open");     

    }
}
