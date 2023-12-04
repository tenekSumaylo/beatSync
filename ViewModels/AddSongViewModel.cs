using beatSync.Models;
using beatSync.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace beatSync.ViewModels
{
    [QueryProperty(nameof(DataStore), "DataStore")]
    public class AddSongViewModel : BaseViewModel
    {
        public ICommand AddImage => new Command(OnAddImage);
        public ICommand OnValidateForm => new Command(AddSong);
        private string userID;
        private Album toBeAdded;
        private int selectionOfPublish;
        private List<string> typeOfPublish = new List<string>() { "Single", "Album" };
        private bool hideEntries;
        private string scrollDisabler;
        private Song song1;
        private Song song2;
        private Song song3;
        private Song song4;
        private Song song5;
        private PassingService dataStore;
        private string fullPath;
        private string fileName;
        PublisherService pubService;


        public AddSongViewModel()
        {
            Song1 = new Song();
            Song2 = new Song();
            Song3 = new Song();
            Song4 = new Song();
            Song5 = new Song();
            ToBeAdded = new Album();
            SelectionOfPublish = 0;
            pubService = new PublisherService(); 
        }

        public List<string> TypeOfPublish { get => this.typeOfPublish; }

        public PassingService DataStore
        {
            get => this.dataStore;
            set
            {
                this.dataStore = value;
                OnPropertyChanged(nameof(DataStore));
            }
        }

        public Song Song1
        {
            get => this.song1;
            set
            {
                this.song1 = value;
                OnPropertyChanged(nameof(Song1));
            }
        }

        public Song Song2
        {
            get => this.song2;
            set
            {
                this.song2 = value;
                OnPropertyChanged(nameof(Song2));
            }
        }
        public Song Song3
        {
            get => this.song3;
            set
            {
                this.song3 = value;
                OnPropertyChanged(nameof(Song3));
            }
        }

        public Song Song4
        {
            get => this.song4;
            set
            {
                this.song4 = value;
                OnPropertyChanged(nameof(Song4));
            }
        }

        public Song Song5
        {
            get => this.song5;
            set
            {
                this.song5 = value;
                OnPropertyChanged(nameof(Song5));
            }
        }

        public string ScrollDisabler
        {
            get => this.scrollDisabler;
            set
            {
                this.scrollDisabler = value;
                OnPropertyChanged(nameof(ScrollDisabler));
            }
        }

        public bool HideEntries
        {
            get => this.hideEntries;
            set
            {
               this.hideEntries = value;
                OnPropertyChanged(nameof(HideEntries));
            }
        }


        public int SelectionOfPublish
        {
            get => this.selectionOfPublish;
            set
            {
                this.selectionOfPublish = value;
                OnPropertyChanged(nameof(SelectionOfPublish));
                if ( value == 0 )
                {
                    HideEntries = false;
                    ScrollDisabler = "Vertical";
                } 
                else
                {
                    HideEntries = true;
                    ScrollDisabler = "Neither";
                }
            }
        } 
        public string UserID
        {
            get => userID;
            set
            {
                userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        public Album ToBeAdded
        {
            get => toBeAdded;
            set
            {
                toBeAdded = value;
                OnPropertyChanged(nameof(ToBeAdded));
            }
        }

        private async void OnAddImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick Image Here",
                FileTypes = FilePickerFileType.Png
            });

            if (result == null)
            {
                return;
            }

            var imageStream = await result.OpenReadAsync();
            ToBeAdded.AlbumCover = result.FullPath;
            fullPath = result.FullPath;
            fileName = result.FileName;
           // imagePlace.Source = ImageSource.FromStream(() => imageStream);
          //  fileP = result.FullPath;
          //  fileNameX = result.FileName;
        }

        private void MoveFromObjectToObservableCollection()
        {
            Song1 = addSongID(Song1);
            Song2 = addSongID(Song2);
            Song3 = addSongID(Song3);
            Song4 = addSongID(Song4);
            Song5 = addSongID(Song5);
            if (!string.IsNullOrEmpty(Song1.SongName))
            {
                Song1.DisplayPhoto = ToBeAdded.AlbumCover;
                Song1.Artist = DataStore.UserInfo.FirstName + $" {DataStore.UserInfo.LastName}";
                Song1.DatePublished = DateTime.Now;
                Song1.ArtistID = DataStore.UserInfo.UserID;
                ToBeAdded.Songs.Add(Song1);
            }

            if (!string.IsNullOrEmpty(Song2.SongName))
            {
                Song2.DisplayPhoto = ToBeAdded.AlbumCover;
                Song2.Artist = DataStore.UserInfo.FirstName + $" {DataStore.UserInfo.LastName}";
                Song2.DatePublished = DateTime.Now;
                Song2.ArtistID = DataStore.UserInfo.UserID;
                ToBeAdded.Songs.Add(Song2);
            }

            if (!string.IsNullOrEmpty(Song3.SongName))
            {
                Song3.DisplayPhoto = ToBeAdded.AlbumCover;
                Song3.Artist = DataStore.UserInfo.FirstName + $" {DataStore.UserInfo.LastName}";
                Song3.DatePublished = DateTime.Now;
                Song3.ArtistID = DataStore.UserInfo.UserID;
                ToBeAdded.Songs.Add(Song3);
            }

            if (!string.IsNullOrEmpty(Song4.SongName))
            {
                Song4.DisplayPhoto = ToBeAdded.AlbumCover;
                Song4.Artist = DataStore.UserInfo.FirstName + $" {DataStore.UserInfo.LastName}";
                Song4.DatePublished = DateTime.Now;
                Song4.ArtistID = DataStore.UserInfo.UserID;
                ToBeAdded.Songs.Add(Song4);
            }

            if (!string.IsNullOrEmpty(Song5.SongName))
            {
                Song5.DisplayPhoto = ToBeAdded.AlbumCover;
                Song5.Artist = DataStore.UserInfo.FirstName + $" {DataStore.UserInfo.LastName}";
                Song5.DatePublished = DateTime.Now;
                Song5.ArtistID = DataStore.UserInfo.UserID;
                ToBeAdded.Songs.Add(Song5);
            }
        }

        private Song addSongID( Song song )
        {
            if ( !string.IsNullOrEmpty( song.SongName))
                song.SongID += userID + $"-{song.SongName}";
            return song;
        }

        private void AddSong()
        {
            if ( string.IsNullOrEmpty(Song1.SongName ) || string.IsNullOrEmpty(Song1.Language) || string.IsNullOrEmpty(Song1.Genre))
            {
                Shell.Current.DisplayAlert("Must Not Have Empty Field", "Enter All Fields", "Close");
            }
            else
            {
                ToBeAdded.AlbumArtist = DataStore.UserInfo.FirstName + $" {DataStore.UserInfo.LastName}";
                ToBeAdded.AlbumTitle = Song1.SongName;
                if (fullPath != null)
                {
                    if (!Directory.Exists(FileSystem.Current.AppDataDirectory + @"/SONGPICTURES")) {
                        Directory.CreateDirectory(FileSystem.Current.AppDataDirectory + @"/SONGPICTURES");
                    }
                    File.Copy(fullPath, FileSystem.Current.AppDataDirectory + @"/SONGPICTURES/" + fileName );
                }
                ToBeAdded.AlbumCover = FileSystem.Current.AppDataDirectory + @"/SONGPICTURES/" + fileName;
                MoveFromObjectToObservableCollection();
                DataStore.UserInfo.addAlbum(ToBeAdded);
                pubService.UpdateInfo(DataStore.UserInfo);
                Shell.Current.DisplayAlert("Success", "Successfully Added", "Close");
                Shell.Current.GoToAsync(nameof(PublisherLandingPage), true, new Dictionary<string, object>
                {
                    { "DataStore", DataStore }
                });
            }
        }





    }
}
