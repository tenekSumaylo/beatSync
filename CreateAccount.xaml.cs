using beatSync.ViewModels;

namespace beatSync;

public partial class CreateAccount : ContentPage
{

	public CreateAccountViewModel ViewModel { get; set; }
	public CreateAccount()
	{
		ViewModel = new CreateAccountViewModel();
		BindingContext = ViewModel;
		InitializeComponent();
	}
}