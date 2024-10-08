namespace Skola.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class StudentiPage : ContentPage
{
    public string ItemId
    {
        set { LoadStudent(value); }
    }

    public StudentiPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.studenti.txt";

        LoadStudent(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        string[] lines = new string[3];
        lines[0] = FirstNameEditor.Text;
        lines[1] = LastNameEditor.Text;
        lines[2] = ClassEditor.Text;

        if (BindingContext is Models.Student student)
            File.WriteAllText(student.Filename, $"{lines[0]}\n{lines[1]}\n{lines[2]}");

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Student student)
        {
            // Delete the file.
            if (File.Exists(student.Filename))
                File.Delete(student.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadStudent(string fileName)
    {
        Models.Student studentModel = new Models.Student();
        studentModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            studentModel.Filename = fileName;
            studentModel.FirstName = lines[0];
            studentModel.LastName = lines[1];
            studentModel.Class = lines[2];
        }
        BindingContext = studentModel;

    }
}