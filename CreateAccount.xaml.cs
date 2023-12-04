using beatSync.ViewModels;
using CommunityToolkit.Maui.Views;

namespace beatSync;

public partial class CreateAccount : Popup
{

	public CreateAccountViewModel ViewModel { get; set; }
	public CreateAccount()
	{
		ViewModel = new CreateAccountViewModel();
		BindingContext = ViewModel;
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		CloseAsync();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
		if ( ViewModel.ValidateForm())
			CloseAsync();
    }
}