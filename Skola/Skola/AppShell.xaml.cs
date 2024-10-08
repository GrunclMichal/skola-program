namespace Skola
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.StudentiPage), typeof(Views.StudentiPage));
            Routing.RegisterRoute(nameof(Views.UcitelePage), typeof(Views.UcitelePage));
            Routing.RegisterRoute(nameof(Views.PodporaPage), typeof(Views.PodporaPage));
            Routing.RegisterRoute(nameof(Views.UdrzbariPage), typeof(Views.UdrzbariPage));
        }
    }
}
