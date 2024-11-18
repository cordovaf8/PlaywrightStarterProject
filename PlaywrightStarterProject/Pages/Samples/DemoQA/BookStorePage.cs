using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class BookStorePage
    {
        private readonly IPage _page;

        internal BookStorePage(IPage page)
        {
            _page = page;
        }

        public readonly String Route = "/books";
        public ILocator GetBookLinkByIndex(int index = 1) => _page.Locator($"(//div[@class='rt-tbody']//div[contains(@class,'rt-tr ')])[<index>]//a".Replace("<index>", index.ToString()));

        public ILocator AddToCollectionButton => _page.Locator($"//button[contains(text(),'Add To Your Collection')]");
        public ILocator BackToBookStoreButton => _page.Locator($"//utton[contains(text(),'Back To Book Store')]");
        public ILocator LoginButton => _page.GetByTestId($"login");
        public ILocator LogoutButton => _page.Locator($"//button[text()='Log out']");
    }
}
