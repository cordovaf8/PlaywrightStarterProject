using FluentAssertions;
using PlaywrightStarterProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA
{
    public class WebTableTests : BaseTest
    {
        [Test]
        public async Task TableDefaultUsersArePresent()
        {
            var DefaultFirstNameRecords = new List<string>() { "Cierra", "Alden", "Kierra" };

            await BasePage.GotoAsync(Pages.HomePage.Url + Pages.WebTablePage.Route);

            var cellValues = await Pages.WebTablePage.GetAllCellValuesInColumnAsync(Pages.WebTablePage.FirstNameColumn);

            DefaultFirstNameRecords.Should().Contain(cellValues);
        }
    }
}
