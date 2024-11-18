using FluentAssertions;
using NUnit.Framework;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA
{
    public class PracticeFormPageTests : BaseTest
    {
        [SetUp]
        public async Task Init()
        {
            await BasePage.GotoAsync(Pages.HomePage.Url);
           
        }

        [Test]
        public async Task FillOutForm()
        {
            await Pages.HomePage.FormsCard.ClickAsync();

            await Pages.FormsPage.PracticeFormsLink.ClickAsync();

            await Pages.PracticeFormPage.FirstNameInput.FillAsync("First");
            await Pages.PracticeFormPage.LastNameInput.FillAsync("Last");
            await Pages.PracticeFormPage.EmailInput.FillAsync("test@test.com");
            await Pages.PracticeFormPage.MaleRadioClickWrapper.ClickAsync();

            await Pages.PracticeFormPage.MobileNumberInput.FillAsync("1234343123");

            await Pages.PracticeFormPage.SubjectsContainer.ClickAsync();
            await BasePage.Keyboard.PressAsync("A");
            await Pages.PracticeFormPage.SubjectsAutoCompleteMenu.IsVisibleAsync();
            await BasePage.Keyboard.PressAsync("ArrowDown");
            await BasePage.Keyboard.PressAsync("Enter");


            await Pages.PracticeFormPage.SportsHobILocatorClickWrapper.ClickAsync();
            await Pages.PracticeFormPage.ReadingHobILocatorClickWrapper.ClickAsync();
            await Pages.PracticeFormPage.MusicHobILocatorClickWrapper.ClickAsync();

            var testItemDir = Directory.GetCurrentDirectory() + "\\Tests\\Samples\\DemoQA\\Test.txt";
            await Pages.PracticeFormPage.PictureUploadInput.SetInputFilesAsync(testItemDir);
            await Pages.PracticeFormPage.CurrentAddressTextArea.FillAsync("TextArea");

            //Asserts 
            var test = (await Pages.PracticeFormPage.FirstNameInput.InputValueAsync());

            (await Pages.PracticeFormPage.FirstNameInput.InputValueAsync()).Should().Be("First");
            (await Pages.PracticeFormPage.LastNameInput.InputValueAsync()).Should().Be("Last");
            (await Pages.PracticeFormPage.EmailInput.InputValueAsync()).Should().Be("test@test.com");
            (await Pages.PracticeFormPage.MaleRadioInput.IsCheckedAsync()).Should().BeTrue();
            (await Pages.PracticeFormPage.FemaleRadioInput.IsCheckedAsync()).Should().BeFalse();
            (await Pages.PracticeFormPage.OtherRadioInput.IsCheckedAsync()).Should().BeFalse();
            (await Pages.PracticeFormPage.MobileNumberInput.InputValueAsync()).Should().Be("1234343123");
            (await Pages.PracticeFormPage.SportsHobILocatorRadioInput.IsCheckedAsync()).Should().BeTrue();
            (await Pages.PracticeFormPage.ReadingHobILocatorRadioInput.IsCheckedAsync()).Should().BeTrue();
            (await Pages.PracticeFormPage.MusicHobILocatorRadioInput.IsCheckedAsync()).Should().BeTrue();
            (await Pages.PracticeFormPage.MusicHobILocatorRadioInput.IsVisibleAsync()).Should().BeTrue();
            (await Pages.PracticeFormPage.CurrentAddressTextArea.InputValueAsync()).Should().Be("TextArea");
            (await Pages.PracticeFormPage.PictureUploadInput.InputValueAsync()).Contains("Test.txt").Should().BeTrue();
        }
    }
}
