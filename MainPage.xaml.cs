using beatSync.Services;
using beatSync.ViewModels;

namespace beatSync
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }
        public PublisherService PubService { get; set; }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainPageViewModel();
            BindingContext = ViewModel;
            PubService = new PublisherService();
        }

    }
}