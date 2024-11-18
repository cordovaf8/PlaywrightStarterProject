using Microsoft.Playwright;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class Shared
    {
        private readonly IPage _page;

        internal Shared(IPage page)
        {
            _page = page;
        }


        public void AcceptBrowserAlert()
        {
            //Wait.Until(ExpectedConditions.AlertIsPresent());
            //Driver.SwitchTo().Alert().Accept();
        }
    }
}
