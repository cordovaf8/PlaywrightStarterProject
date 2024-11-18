using FluentAssertions;
using PlaywrightStarterProject.Framework;
using PlaywrightStarterProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA
{
    public class BookStoreTests : BaseTest
    {
        [SetUp]
        public async Task Init()
        {
            try
            {
                var url = Pages.HomePage.Url + Pages.BookStorePage.Route;
                await BasePage.GotoAsync(Pages.HomePage.Url + Pages.BookStorePage.Route);

                if (await Pages.BookStorePage.LogoutButton.CountAsync() == 0)
                {
                    await Pages.BookStorePage.LoginButton.ClickAsync();
                    await Pages.LoginPage.Login();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [Test]
        public async Task AddBookToCollection()
        {
            await Pages.BookStorePage.GetBookLinkByIndex().ClickAsync();
            var bookTitle = await Pages.ProfilePage.TitleTextLabel.TextContentAsync();

            //await BasePage.EvaluateAsync(() => alert("alert"));
            await Pages.BookStorePage.AddToCollectionButton.ClickAsync(new() { Force = true});

            //Interaction.JavaScriptClick(Pages.BookStorePage.AddToCollectionButton);
            //Pages.Shared.AcceptBrowserAlert();

            await BasePage.GotoAsync(Pages.HomePage.Url + Pages.ProfilePage.Route);

            await Pages.ProfilePage.SearchBoxInput.FillAsync(bookTitle);
            await Pages.ProfilePage.SearchBoxInput.PressAsync("Tab");

            var bookInGridTitle = await Pages.ProfilePage.GetRecordLinkILocatorTitle(bookTitle).TextContentAsync();

            bookInGridTitle.Should().Be(bookTitle);
        }


        [TearDown]
        public async Task Cleanup()
        {
            await Pages.ProfilePage.GetDeleteButtonForRow(1).ClickAsync();
            await Pages.ProfilePage.DeleteBookModalOkButton.ClickAsync();
        }
    }
}
