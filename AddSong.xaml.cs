using beatSync.Models;
using beatSync.Services;
using beatSync.ViewModels;

namespace beatSync;
[QueryProperty( nameof( UserID), nameof(UserID))]
public partial class AddSong : ContentPage
{
	public AddSongViewModel viewModel { get; set; }
	private string fileP;
    string SongPictureDir = FileSystem.Current.AppDataDirectory + @"/SONGPICTURES/";
	private string userID;
	private string fileNameX;
    public AddSong()
	{
		viewModel = new AddSongViewModel();
		BindingContext = viewModel;
		InitializeComponent();
	}

	public string UserID
	{
		get => userID;
		set
		{
			userID = value;
		}
	}

}