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

    private async void AddNewSongToArtist( object sender, EventArgs e )
	{
		if ( ValidateForm() )
		{
			SongService addServiceS = new SongService();
			Song newSong = new Song();
			newSong.Artist = txtSongArtist.Text;
			newSong.SongName = txtSongName.Text;
			newSong.DatePublished = DateTime.Now;
			newSong.Genre = txtSongGenre.Text;
			newSong.DisplayPhoto = SongPictureDir + $"/{UserID}/" + fileNameX;
			addServiceS.WriteData(newSong, UserID);
			addServiceS.CopyPicture(fileP, fileNameX, UserID);
			newSong.ClearAllFields();
			await Shell.Current.GoToAsync($"{nameof(PublisherLandingPage)}?UserID={UserID}");
		}
	} 

	private bool ValidateForm()
	{
		if ( string.IsNullOrEmpty( txtSongArtist.Text ) || string.IsNullOrEmpty( txtSongGenre.Text) || string.IsNullOrEmpty(txtSongName.Text) || string.IsNullOrEmpty( fileP ))
		{
			_=DisplayAlert("ERROR", "PLEASE ENTER ALL FIELDS", "CLOSE");
			return false;
		} 
		else
		{
            _=DisplayAlert("SUCCESS", "SUCCESSFULLY ADDED SONG", "CLOSE");
			return true;
        }
	}


}