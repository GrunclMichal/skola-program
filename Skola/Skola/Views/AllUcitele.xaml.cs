namespace Skola.Views;

public partial class AllUcitele : ContentPage
{
    public AllUcitele()
    {
        InitializeComponent();

        BindingContext = new Models.AllUcitele();
    }

    protected override void OnAppearing()
    {
        ((Models.AllUcitele)BindingContext).LoadUcitele();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(UcitelePage));
    }

    private async void uciteleCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var ucitel = (Models.Ucitel)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(UcitelePage)}?{nameof(UcitelePage.ItemId)}={ucitel.Filename}");

            // Unselect the UI
            uciteleCollection.SelectedItem = null;
        }
    }
}