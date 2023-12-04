using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using beatSync.Models;
using beatSync.Services;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;

namespace beatSync.ViewModels
{

    public class CreateAccountViewModel : BaseViewModel
    {
        public PublisherBeat PublisherPerson { get; set; }
        private string confirmPass;
        public ICommand OnClear => new Command( Clear );
        public PublisherService publisherService;
        public List<string> pickerItems { get; set; }
        private int selectedUser;
        private readonly IPopupService popupService;
        public CreateAccountViewModel() {
            popupService = new PopupService();
            PublisherPerson = new PublisherBeat();
            publisherService = new PublisherService();
            pickerItems = UserTypesSelect();
        }

        public List<string> UserTypesSelect() => new List<string> { "--SELECT--" ,"Publisher", "Artist", "Customer" };
        
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

        public bool ValidateForm()
        {
            int flag = 1;
            PublisherPerson.Age = getAccurateAge(PublisherPerson.DateBirth);
            PublisherPerson.PersonIndex = GetIDNumber( PublisherPerson.UserID );
            --PublisherPerson.PersonIndex;


            if ( string.IsNullOrEmpty( PublisherPerson.UserID ) || string.IsNullOrEmpty( PublisherPerson.FirstName) || string.IsNullOrEmpty( PublisherPerson.LastName) || string.IsNullOrEmpty( PublisherPerson.Password ) || string.IsNullOrEmpty( PublisherPerson.Address ) || string.IsNullOrEmpty( PublisherPerson.Email) ) {
                _ = Shell.Current.DisplayAlert("Error", $"No inputs should be empty ", "Close");
                flag = 0;
            }

            if ( !EmailCheck( PublisherPerson.Email ) )
            {
                _ = Shell.Current.DisplayAlert("INVALID EMAIL", "SHOULD BE A PROPER EMAIL", "CLOSE");
                flag = 0;
            }

            if ( PublisherPerson.Age < 15 )
            {
                _ = Shell.Current.DisplayAlert("NOT ALLOWED", "You should be older than 15", "Close");
                flag = 0;
            }

            if ( PublisherPerson.Password != ConfirmPass )
            {
                _ = Shell.Current.DisplayAlert("Error", "PASSWORD SHOULD MATCH", "CLOSE");
                flag = 0;
            }

            if ( flag == 1 )
            {
        //        PublisherService publisherService = new PublisherService();
                publisherService.WriteData( PublisherPerson, SelectedUser );
                _ = Shell.Current.DisplayAlert("SUCCESS", "SUCCESSFUL REGISTRATION", "CLOSE");
                //        SongService serviceK = new SongService();
                //        serviceK.CheckExisting(PublisherPerson.UserID);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async void Clear() {
            await Task.Run( () => PublisherPerson.ClearFields() );
            SelectedUser = 0;
        }
    }
}
