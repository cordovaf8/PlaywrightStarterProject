using Microsoft.Playwright;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class PracticeFormPage
    {
        private readonly IPage _page;

        internal PracticeFormPage(IPage page)
        {
            _page = page;
        }

        public readonly String Route = "/automation-practice-form";


        #region Selectors
        public ILocator FirstNameInput => _page.GetByTestId($"firstName");
        public ILocator LastNameInput => _page.GetByTestId($"lastName");
        public ILocator EmailInput => _page.GetByTestId($"userEmail");

        public ILocator SubjectsContainer => _page.GetByTestId($"subjectsContainer");
        public ILocator SubjectsAutoCompleteMenu => _page.GetByTestId($"//div[contains(@class, 'subjects-auto-complete__control--is-focused')]");
        public ILocator MaleRadioClickWrapper => _page.Locator($"//label[@for='gender-radio-1']");
        public ILocator MaleRadioInput => _page.GetByTestId($"gender-radio-1");
        public ILocator FemaleRadioClickWrapper => _page.Locator($"//label[@for='gender-radio-2']");
        public ILocator FemaleRadioInput => _page.GetByTestId($"gender-radio-2");
        public ILocator OtherRadioClickWrapper => _page.Locator($"//label[@for='gender-radio-3']");
        public ILocator OtherRadioInput => _page.GetByTestId($"gender-radio-3");


        public ILocator MobileNumberInput => _page.GetByTestId($"userNumber");


        //example of input being covered ILocator a label -- had to get creative and click the label
        public ILocator SportsHobILocatorClickWrapper => _page.Locator($"//label[@for='hobbies-checkbox-1']");
        public ILocator SportsHobILocatorRadioInput => _page.GetByTestId($"hobbies-checkbox-1");
        public ILocator ReadingHobILocatorClickWrapper => _page.Locator($"//label[@for='hobbies-checkbox-2']");
        public ILocator ReadingHobILocatorRadioInput => _page.GetByTestId($"hobbies-checkbox-2");
        public ILocator MusicHobILocatorClickWrapper => _page.Locator($"//label[@for='hobbies-checkbox-3']");
        public ILocator MusicHobILocatorRadioInput => _page.GetByTestId($"hobbies-checkbox-3");


        public ILocator PictureUploadInput => _page.GetByTestId($"uploadPicture");

        public ILocator CurrentAddressTextArea => _page.Locator($"//textarea[@id='currentAddress']");

        public ILocator StateDropDownMenuButton => _page.GetByTestId($"state");

        private String StateDropDownMenuOptionsXpathILocatorIndex = $"(//div[@id='state']//div[contains(@class, '-menu')]/div//div)[<index>]";
        public ILocator GetStateDropDownMenuOptionILocatorIndex(int index = 1) => _page.Locator(StateDropDownMenuOptionsXpathILocatorIndex.Replace("<index>", index.ToString()));

        public ILocator CityDropDownMenuButton => _page.GetByTestId($"city");

        private String CityDropDownMenuOptionsXpathILocatorIndex = $"(//div[@id='city']//div[contains(@class, '-menu')]/div//div)[<index>]";
        public ILocator GetCityDropDownMenuOptionsILocatorIndex(int index = 1) => _page.Locator(CityDropDownMenuOptionsXpathILocatorIndex.Replace("<index>", index.ToString()));

        public ILocator SubmitButton => _page.GetByTestId($"submit");

        #endregion
    }
}
