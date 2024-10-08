namespace Skola.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class UcitelePage : ContentPage
{
    public string ItemId
    {
        set { LoadUcitel(value); }
    }

    public UcitelePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.ucitele.txt";

        LoadUcitel(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        string[] lines = new string[3];
        lines[0] = FirstNameEditor.Text;
        lines[1] = LastNameEditor.Text;
        lines[2] = TitleEditor.Text;

        if (BindingContext is Models.Ucitel ucitel)
            File.WriteAllText(ucitel.Filename, $"{lines[0]}\n{lines[1]}\n{lines[2]}");

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Ucitel ucitel)
        {
            // Delete the file.
            if (File.Exists(ucitel.Filename))
                File.Delete(ucitel.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadUcitel(string fileName)
    {
        Models.Ucitel ucitelModel = new Models.Ucitel();
        ucitelModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            ucitelModel.Filename = fileName;
            ucitelModel.FirstName = lines[0];
            ucitelModel.LastName = lines[1];
            ucitelModel.Title = lines[2];
        }
        BindingContext =ucitelModel;

    }
}