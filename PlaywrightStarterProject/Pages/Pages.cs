using Microsoft.Playwright;
using PlaywrightStarterProject.Framework;
using PlaywrightStarterProject.Pages.Samples;
using PlaywrightStarterProject.Pages.Samples.DemoQA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages
{
    public class Pages
    {
        public HomePage HomePage { get; set; }
        public FormsPage FormsPage { get; set; }
        public PracticeFormPage PracticeFormPage { get; set; }
        public LinksPage LinksPage { get; set; }
        public LoginPage LoginPage { get; set; }
        public BookStorePage BookStorePage { get; set; }
        public ProfilePage ProfilePage { get; set; }
        public WebTablePage WebTablePage { get; set; }
        public IFramePage IFramePage { get; set; }
        public Shared Shared { get; set; }

        public Pages(IPage page)
        {
            #region DemoQA Pages

            HomePage = new(page);
            FormsPage = new(page);
            PracticeFormPage = new(page);
            LinksPage = new(page);
            LoginPage = new(page);
            BookStorePage = new(page);
            ProfilePage = new(page);
            Shared = new(page);
            WebTablePage = new(page);
            IFramePage = new(page);

            #endregion
        }
    }
}
