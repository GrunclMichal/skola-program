using Skola.Models;

namespace Skola.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class UdrzbariPage : ContentPage
{
	

    public string ItemId
    {
        set { LoadUdrzbar(value); }
    }

    public UdrzbariPage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.udrzbari.txt";

        LoadUdrzbar(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        string[] lines = new string[3];
        lines[0] = FirstNameEditor.Text;
        lines[1] = LastNameEditor.Text;

        if (BindingContext is Models.Udrzbar udrzbar)
            File.WriteAllText(udrzbar.Filename, $"{lines[0]}\n{lines[1]}\n{lines[2]}");

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Udrzbar udrzbar)
        {
            // Delete the file.
            if (File.Exists(udrzbar.Filename))
                File.Delete(udrzbar.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadUdrzbar(string fileName)
    {
        Models.Udrzbar udrzbarModel = new Models.Udrzbar();
        udrzbarModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            udrzbarModel.Filename = fileName;
            udrzbarModel.FirstName = lines[0];
            udrzbarModel.LastName = lines[1];
        }
        BindingContext = udrzbarModel;

    }
}
