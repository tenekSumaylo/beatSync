using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using beatSync.Models;
using beatSync.Services;

namespace beatSync.ViewModels
{

    public class CreateAccountViewModel : BaseViewModel
    {
        public PublisherBeat PublisherPerson { get; set; }
        private string confirmPass;
        public ICommand OnSubmit => new Command( ValidateForm );
        public ICommand OnBack => new Command( ReturnToMain );
        public PublisherService publisherService;
        public List<string> pickerItems { get; set; }
        private int selectedUser;
        public CreateAccountViewModel() { 
            PublisherPerson = new PublisherBeat();
            publisherService = new PublisherService();
            pickerItems = UserTypesSelect();
        }

        public List<string> UserTypesSelect() => new List<string> { "--SELECT--" ,"Publisher", "Admin" };
        
        public int SelectedUser
        {
            get => this.selectedUser;
            set
            {
                selectedUser = value;
                PublisherPerson.UserID = publisherService.GenerateID( value );
                PublisherPerson.UserType = value;
                OnPropertyChanged(nameof( selectedUser ) );
            }
        }

        public string ConfirmPass
        {
            get => confirmPass;
            set
            {
                confirmPass = value;
                OnPropertyChanged(nameof(ConfirmPass));
            }
        }

        public void ValidateForm()
        {
            if ( string.IsNullOrEmpty( PublisherPerson.UserID ) || string.IsNullOrEmpty( PublisherPerson.FirstName) || string.IsNullOrEmpty( PublisherPerson.LastName) || string.IsNullOrEmpty( PublisherPerson.Password ) || string.IsNullOrEmpty( PublisherPerson.Address ) || string.IsNullOrEmpty( PublisherPerson.Email) || string.IsNullOrEmpty( PublisherPerson.DateBirth) ) {
                _ = Shell.Current.DisplayAlert("Error", "No inputs should be empty", "Close");
            }
            else if ( PublisherPerson.Password != ConfirmPass )
            {
                _ = Shell.Current.DisplayAlert("Error", "PASSWORD SHOULD MATCH", "CLOSE");
            }
            else
            {
        //        PublisherService publisherService = new PublisherService();
                publisherService.WriteData( PublisherPerson );
                _ = Shell.Current.DisplayAlert("SUCCESS", "SUCCESSFUL REGISTRATION", "CLOSE");
        //        SongService serviceK = new SongService();
        //        serviceK.CheckExisting(PublisherPerson.UserID);
                ReturnToMain();
            }
        }

        public async void ReturnToMain() { await Shell.Current.GoToAsync(".."); }
    }
}
