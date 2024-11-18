using Microsoft.Playwright;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Pages.Samples.DemoQA
{
    public class WebTablePage 
    {
        private readonly IPage _page;

        internal WebTablePage(IPage page)
        {
            _page = page;
        }

        public readonly String Route = "/webtables";

        public ILocator AddNewRecordButton => _page.GetByTestId("addNewRecordButton");
        public ILocator SearchBoxInput => _page.GetByTestId("searchBox");


        #region Registration Form Fields
        public ILocator FirstName => _page.GetByTestId("firstName");
        public ILocator LastName => _page.GetByTestId("lastName");
        public ILocator UserEmailInput => _page.GetByTestId("userEmail");
        public ILocator AgeInput => _page.GetByTestId("age");
        public ILocator SalaryInput => _page.GetByTestId("salary");
        public ILocator DepartmentInput => _page.GetByTestId("department");
        public ILocator SubmitButton => _page.GetByTestId("submit");

        #endregion

        #region Table Columns
        public int FirstNameColumn = 1;
        public int LastNameColumn = 2;
        public int AgeColumn = 3;
        public int EmailColumn = 4;
        public int Salary = 5;
        public int Department = 6;
        #endregion


        public async Task<List<string>> GetAllCellValuesInColumnAsync(int column)
        {
            var rawValues = _page.Locator($"//div[@class='rt-tbody']//div[contains(@class,'rt-tr') and @role='row']/div[@class='rt-td'][{column}]");
            return  (await rawValues.AllTextContentsAsync()).Where(x => !String.IsNullOrWhiteSpace(x)).ToList();
        }

        public ILocator GetCellByColumnValue(int column, string value)
        {
            return _page.Locator($"//tr/td[{column} and text() = '{value}']");
        }

        public async Task DeleteRowByCellValue(string value)
        {
            await _page.Locator($"(//div[@class='rt-td' and text() = '{value}']/following-sibling::div[@class='rt-td'])[last()]//span[contains(@id, 'delete-record')]").ClickAsync();
        }
        
        public ILocator GetCellByRowAndColumn(int row, int column)  
        {
            return _page.Locator($"(//div[@class='rt-tbody']//div[@role='row'])[{row}]/div[@role='gridcell'][{column}]");
        }
    }
}
