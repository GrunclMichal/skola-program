namespace Skola.Views;

public partial class AllStudents : ContentPage
{
	public AllStudents()
	{
		InitializeComponent();

        BindingContext = new Models.AllStudents();
    }

    protected override void OnAppearing()
    {
        ((Models.AllStudents)BindingContext).LoadStudents();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(StudentiPage));
    }

    private async void studentiCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var student = (Models.Student)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(StudentiPage)}?{nameof(StudentiPage.ItemId)}={student.Filename}");

            // Unselect the UI
            studentiCollection.SelectedItem = null;
        }
    }
}