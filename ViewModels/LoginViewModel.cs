using beatSync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace beatSync.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand OnLoginButton => new Command(LoginUser);
        private string _username;
        private string _password;
        private PassingService dataStore;
        
        public LoginViewModel()
        {
            DataStore = new PassingService();
        }

        public PassingService DataStore
        {
            get => this.dataStore;
            set
            {
                this.dataStore = value;
                OnPropertyChanged( nameof(DataStore) );
            }
        }

        public string UserID
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserID));
            }
        }
        
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private async void LoginUser()
        {
            if ( CheckUser() )
            {
                _= Shell.Current.DisplayAlert("Success", "Login Successful", "Close");
                await Shell.Current.GoToAsync(nameof(PublisherLandingPage), true, new Dictionary<string, object>
                {
                    { "DataStore", DataStore }
                });
            }
            else
            {
                _= Shell.Current.DisplayAlert("Invalid Login Credentials", "Username or Password did not match", "Close");
            }
        }

        private bool CheckUser()
        {
            PublisherService pubService = new PublisherService();
            int indicateUser = 1;

            if ( string.IsNullOrEmpty( UserID) || string.IsNullOrEmpty( Password ) )
            {
                return false;
            } 
            else
            {
                if ( UserID.IndexOf( "artist" ) != -1 )
                {
                    indicateUser = 2;
                }

                if ( pubService.CheckUser( UserID, Password, indicateUser )  )
                {
                    pubService.GetData();
                    DataStore.Persons = pubService.PublisherPeople;
                    DataStore.UserID = UserID;
                    DataStore.GetUser();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
