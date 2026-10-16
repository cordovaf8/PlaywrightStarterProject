namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

public class WebTablePage(IPage page)
{
    public const string Route = "/webtables";

    public enum Column
    {
        FirstName = 1,
        LastName,
        Age,
        Email,
        Salary,
        Department,
        Action,
    }

    public ILocator AddNewRecordButton => page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true });
    public ILocator SearchBoxInput => page.GetByPlaceholder("Type to search");

    public ILocator Table => page.GetByRole(AriaRole.Table);
    public ILocator Rows => Table.Locator("tbody tr");

    /// <summary>The row containing <paramref name="text"/> in any cell.</summary>
    public ILocator Row(string text) => Rows.Filter(new() { HasText = text });

    public ILocator CellsInColumn(Column column) => Rows.Locator($"td:nth-child({(int)column})");

    public Task DeleteRowAsync(string text) => Row(text).GetByTitle("Delete").ClickAsync();

    public Task GotoAsync() => page.GotoAsync(Route);
}
