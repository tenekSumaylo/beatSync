using beatSync.Services;
using beatSync.ViewModels;
namespace beatSync;
using CommunityToolkit.Maui.Views;

public partial class PublisherLandingPage : ContentPage
{
	public PublisherLandingPageViewModel ViewModel { get; set; }
	public PublisherLandingPage()
	{
		ViewModel = new PublisherLandingPageViewModel();
		BindingContext = ViewModel; 
		InitializeComponent();
	}
}