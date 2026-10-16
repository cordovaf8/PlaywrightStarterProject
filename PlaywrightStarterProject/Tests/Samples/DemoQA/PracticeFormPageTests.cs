namespace PlaywrightStarterProject.Tests.Samples.DemoQA;

public class PracticeFormPageTests : BaseTest
{
    [SetUp]
    public Task Init() => Pages.PracticeFormPage.GotoAsync();

    [Test]
    public async Task FillOutForm()
    {
        var form = Pages.PracticeFormPage;
        var uploadFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Test.txt");

        await form.FirstNameInput.FillAsync("First");
        await form.LastNameInput.FillAsync("Last");
        await form.EmailInput.FillAsync("test@test.com");
        await form.SelectGenderAsync("Male");
        await form.MobileNumberInput.FillAsync("1234343123");
        await form.AddSubjectAsync("Maths");
        await form.CheckHobbyAsync("Sports");
        await form.CheckHobbyAsync("Reading");
        await form.CheckHobbyAsync("Music");
        await form.PictureUploadInput.SetInputFilesAsync(uploadFile);
        await form.CurrentAddressTextArea.FillAsync("TextArea");
        await form.SelectStateAsync("NCR");
        await form.SelectCityAsync("Delhi");

        await Expect(form.FirstNameInput).ToHaveValueAsync("First");
        await Expect(form.LastNameInput).ToHaveValueAsync("Last");
        await Expect(form.EmailInput).ToHaveValueAsync("test@test.com");
        await Expect(form.GenderRadio("Male")).ToBeCheckedAsync();
        await Expect(form.GenderRadio("Female")).Not.ToBeCheckedAsync();
        await Expect(form.GenderRadio("Other")).Not.ToBeCheckedAsync();
        await Expect(form.MobileNumberInput).ToHaveValueAsync("1234343123");
        await Expect(form.SelectedSubjects).ToHaveTextAsync(["Maths"]);
        await Expect(form.HobbyCheckbox("Sports")).ToBeCheckedAsync();
        await Expect(form.HobbyCheckbox("Reading")).ToBeCheckedAsync();
        await Expect(form.HobbyCheckbox("Music")).ToBeCheckedAsync();
        await Expect(form.PictureUploadInput).ToHaveValueAsync(new Regex(@"Test\.txt$"));
        await Expect(form.CurrentAddressTextArea).ToHaveValueAsync("TextArea");
        await Expect(form.StateDropDown).ToContainTextAsync("NCR");
        await Expect(form.CityDropDown).ToContainTextAsync("Delhi");
    }
}
