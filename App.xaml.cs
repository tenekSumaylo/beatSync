namespace beatSync
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CreateAccount), typeof(CreateAccount));
            Routing.RegisterRoute(nameof(Login), typeof( Login));
            Routing.RegisterRoute(nameof(PublisherLandingPage), typeof(PublisherLandingPage));
            Routing.RegisterRoute(nameof(AddSong), typeof(AddSong));
            MainPage = new AppShell();
        }
    }
}