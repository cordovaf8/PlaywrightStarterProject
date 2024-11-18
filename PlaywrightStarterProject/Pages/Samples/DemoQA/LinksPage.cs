using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class LinksPage
    {
        private readonly IPage _page;

        internal LinksPage(IPage page)
        {
            _page = page;
        }

        public readonly String Route = "/links";

        public ILocator HomeInNewTabLink => _page.GetByTestId($"simpleLink");
    }
}
