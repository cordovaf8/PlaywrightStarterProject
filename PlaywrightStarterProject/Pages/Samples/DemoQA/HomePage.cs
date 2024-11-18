
using Microsoft.Playwright;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class HomePage
    {
        private readonly IPage _page;

        internal HomePage(IPage page)
        {
            _page = page;
        }

        public readonly String Url = "https://demoqa.com";

        public ILocator FormsCard => _page.Locator($"//h5[contains(text(), 'Forms')]/ancestor::div[contains(@class, 'card ')]");
    }
}
