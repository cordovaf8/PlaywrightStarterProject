using static PlaywrightStarterProject.Pages.Samples.DemoQA.WebTablePage;

namespace PlaywrightStarterProject.Tests.Samples.DemoQA;

public class WebTableTests : BaseTest
{
    [SetUp]
    public Task Init() => Pages.WebTablePage.GotoAsync();

    [Test]
    public async Task TableDefaultUsersArePresent()
    {
        await Expect(Pages.WebTablePage.CellsInColumn(Column.FirstName))
            .ToContainTextAsync(["Cierra", "Alden", "Kierra"]);
    }

    [Test]
    public async Task SearchFiltersRows()
    {
        await Pages.WebTablePage.SearchBoxInput.FillAsync("Cierra");

        await Expect(Pages.WebTablePage.Rows).ToHaveCountAsync(1);
        await Expect(Pages.WebTablePage.Row("Cierra")).ToContainTextAsync("cierra@example.com");
    }

    [Test]
    public async Task CanDeleteRow()
    {
        await Pages.WebTablePage.DeleteRowAsync("Alden");

        await Expect(Pages.WebTablePage.Row("Alden")).ToHaveCountAsync(0);
        await Expect(Pages.WebTablePage.Row("Cierra")).ToBeVisibleAsync();
    }
}
