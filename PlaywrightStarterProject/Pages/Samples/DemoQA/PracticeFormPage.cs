namespace PlaywrightStarterProject.Pages.Samples.DemoQA;

public class PracticeFormPage(IPage page)
{
    public const string Route = "/automation-practice-form";

    private ILocator Form => page.Locator("#userForm");

    public ILocator FirstNameInput => Form.GetByPlaceholder("First Name");
    public ILocator LastNameInput => Form.GetByPlaceholder("Last Name");
    public ILocator EmailInput => Form.GetByPlaceholder("name@example.com");
    public ILocator MobileNumberInput => Form.GetByPlaceholder("Mobile Number");
    public ILocator CurrentAddressTextArea => Form.GetByPlaceholder("Current Address");
    public ILocator PictureUploadInput => Form.Locator("#uploadPicture");
    public ILocator SubmitButton => Form.GetByRole(AriaRole.Button, new() { Name = "Submit" });

    // DemoQA's radios and checkboxes are visually covered by their labels,
    // so we assert on the input but click the label text.
    public ILocator GenderRadio(string gender) => Form.GetByRole(AriaRole.Radio, new() { Name = gender, Exact = true });
    public Task SelectGenderAsync(string gender) => Form.GetByText(gender, new() { Exact = true }).ClickAsync();

    public ILocator HobbyCheckbox(string hobby) => Form.GetByRole(AriaRole.Checkbox, new() { Name = hobby, Exact = true });
    public Task CheckHobbyAsync(string hobby) => Form.GetByText(hobby, new() { Exact = true }).ClickAsync();

    // react-select widgets: type to filter, then pick the matching option.
    public ILocator SubjectsInput => Form.Locator("#subjectsInput");
    public ILocator SelectedSubjects => Form.Locator(".subjects-auto-complete__multi-value__label");

    public async Task AddSubjectAsync(string subject)
    {
        await SubjectsInput.PressSequentiallyAsync(subject);
        await page.GetByRole(AriaRole.Option, new() { Name = subject, Exact = true }).ClickAsync();
    }

    public ILocator StateDropDown => Form.Locator("#state");
    public ILocator CityDropDown => Form.Locator("#city");

    public Task SelectStateAsync(string state) => SelectFromDropDownAsync(StateDropDown, state);
    public Task SelectCityAsync(string city) => SelectFromDropDownAsync(CityDropDown, city);

    private async Task SelectFromDropDownAsync(ILocator dropDown, string option)
    {
        await dropDown.ClickAsync();
        await page.GetByRole(AriaRole.Option, new() { Name = option, Exact = true }).ClickAsync();
    }

    public Task GotoAsync() => page.GotoAsync(Route);
}
