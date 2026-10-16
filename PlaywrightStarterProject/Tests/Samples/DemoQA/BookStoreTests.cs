namespace PlaywrightStarterProject.Tests.Samples.DemoQA;

/// <summary>
/// Requires a DemoQA account. Set DEMOQA_USERNAME and DEMOQA_PASSWORD
/// (environment variables or CI secrets) to run these tests; otherwise they are skipped.
/// </summary>
public class BookStoreTests : BaseTest
{
    private string? _addedBookTitle;

    [SetUp]
    public async Task Init()
    {
        var userName = Environment.GetEnvironmentVariable("DEMOQA_USERNAME");
        var password = Environment.GetEnvironmentVariable("DEMOQA_PASSWORD");
        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        {
            Assert.Ignore("Set DEMOQA_USERNAME and DEMOQA_PASSWORD to run Book Store tests.");
        }

        await Pages.LoginPage.GotoAsync();
        await Pages.LoginPage.LoginAsync(userName!, password!);
        await Pages.BookStorePage.GotoAsync();
    }

    [Test]
    public async Task AddBookToCollection()
    {
        await Pages.BookStorePage.BookLinks.First.ClickAsync();
        var bookTitle = await Pages.BookStorePage.BookTitle.InnerTextAsync();

        // DemoQA confirms with a native alert; accept it explicitly.
        Page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
        await Pages.BookStorePage.AddToCollectionButton.ClickAsync();
        _addedBookTitle = bookTitle;

        await Pages.ProfilePage.GotoAsync();
        await Pages.ProfilePage.SearchBoxInput.FillAsync(bookTitle);

        await Expect(Pages.ProfilePage.BookLink(bookTitle)).ToBeVisibleAsync();
    }

    [TearDown]
    public async Task Cleanup()
    {
        if (_addedBookTitle is null)
        {
            return;
        }

        await Pages.ProfilePage.GotoAsync();
        await Pages.ProfilePage.DeleteBookAsync(_addedBookTitle);
        _addedBookTitle = null;
    }
}
