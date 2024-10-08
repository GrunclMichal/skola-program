using Skola.Models;

namespace Skola.Views;

public partial class AllPodpora : ContentPage
{
    public AllPodpora()
    {
        InitializeComponent();

        BindingContext = new Models.AllPodpora();
    }

    protected override void OnAppearing()
    {
        ((Models.AllPodpora)BindingContext).LoadPodpora();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PodporaPage));
    }

    private async void podporaCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var podpora = (Models.Podpora)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(PodporaPage)}?{nameof(PodporaPage.ItemId)}={podpora.Filename}");

            // Unselect the UI
            podporaCollection.SelectedItem = null;
        }
    }
}