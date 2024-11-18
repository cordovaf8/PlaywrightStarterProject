using Microsoft.Playwright;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class ProfilePage
    {
        private readonly IPage _page;

        internal ProfilePage(IPage page)
        {
            _page = page;
        }

        public readonly String Route = "/profile";

        public ILocator GetRecordLinkILocatorTitle(string title) => _page.Locator($"//div[@class='rt-tbody']//a[contains(text(),'{title}')]");

        public ILocator TitleTextLabel => _page.Locator($"//div[@id='title-wrapper']//label[@id='userName-value']");
        public ILocator SearchBoxInput => _page.GetByTestId($"searchBox");

        public ILocator DeleteBookModalOkButton => _page.GetByTestId($"closeSmallModal-ok");
        public ILocator DeleteBookModalCancelButton => _page.GetByTestId($"closeSmallModal-cancel");


        public ILocator GetCellILocatorRowAndColumn(int row, int column)
        {
            return _page.Locator($"(//div[@class='rt-tbody']//div[@role='row'])[{row}]/div[@role='gridcell'][{column}]");
        }

        public ILocator GetDeleteButtonForRow(int row)
        {
            return _page.Locator($"(//div[@class='rt-tbody']//div[@role='row'])[{row}]//span[@title='Delete']");
        }

    }
}
