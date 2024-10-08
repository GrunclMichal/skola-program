using Skola.Models;

namespace Skola.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class PodporaPage : ContentPage
{
    public string ItemId
    {
        set { LoadPodpora(value); }
    }

    public PodporaPage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.podpora.txt";

        LoadPodpora(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        string[] lines = new string[3];
        lines[0] = FirstNameEditor.Text;
        lines[1] = LastNameEditor.Text;

        if (BindingContext is Models.Podpora podpora)
            File.WriteAllText(podpora.Filename, $"{lines[0]}\n{lines[1]}\n{lines[2]}");

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Podpora podpora)
        {
            // Delete the file.
            if (File.Exists(podpora.Filename))
                File.Delete(podpora.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadPodpora(string fileName)
    {
        Models.Podpora podporaModel = new Models.Podpora();
        podporaModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            podporaModel.Filename = fileName;
            podporaModel.FirstName = lines[0];
            podporaModel.LastName = lines[1];
        }
        BindingContext = podporaModel;

    }
}