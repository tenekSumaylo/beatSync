using beatSync.ViewModels;

namespace beatSync;

public partial class Login : ContentPage
{
	LoginViewModel viewModel { get; set; }
	public Login()
	{
		viewModel = new LoginViewModel();
		BindingContext = viewModel;
		InitializeComponent();
	}
}