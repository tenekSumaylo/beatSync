using beatSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace beatSync.ViewModels
{
    [QueryProperty(nameof(UserID), nameof(UserID))]
    public class AddSongViewModel : BaseViewModel
    {
        public ICommand AddImage => new Command(OnAddImage);
        public ICommand OnValidateForm;
        private string userID;
        private Song toBeAdded;

        public AddSongViewModel()
        {
            ToBeAdded = new Song();
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

        public Song ToBeAdded
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
                FileTypes = FilePickerFileType.Images
            });

            if (result == null)
            {
                return;
            }

            var imageStream = await result.OpenReadAsync();
           // imagePlace.Source = ImageSource.FromStream(() => imageStream);
          //  fileP = result.FullPath;
          //  fileNameX = result.FileName;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty( ToBeAdded.SongID ) || string.IsNullOrEmpty( ToBeAdded.SongName ) || string.IsNullOrEmpty( ToBeAdded.Genre ) || string.IsNullOrEmpty( ToBeAdded.DisplayPhoto ) || string.IsNullOrEmpty( ToBeAdded.ArtistID ) || string.IsNullOrEmpty( ToBeAdded.DatePublished.ToString()) || string.IsNullOrEmpty( ToBeAdded.Language ))
            {
           //     _= DisplayAlert("ERROR", "PLEASE ENTER ALL FIELDS", "CLOSE");
                return false;
            }
            else
            {
             //   _= DisplayAlert("SUCCESS", "SUCCESSFULLY ADDED SONG", "CLOSE");
                return true;
            }
        }


    }
}
