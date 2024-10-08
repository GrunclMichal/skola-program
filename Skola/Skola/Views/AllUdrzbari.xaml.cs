namespace Skola.Views;

public partial class AllUdrzbari : ContentPage
{
    public AllUdrzbari()
    {
        InitializeComponent();

        BindingContext = new Models.AllUdrzbari();
    }

    protected override void OnAppearing()
    {
        ((Models.AllUdrzbari)BindingContext).LoadUdrzbari();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(UdrzbariPage));
    }

    private async void udrzbariCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var udrzbar = (Models.Udrzbar)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(UdrzbariPage)}?{nameof(UdrzbariPage.ItemId)}={udrzbar.Filename}");

            // Unselect the UI
            udrzbariCollection.SelectedItem = null;
        }
    }
}