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
                await Shell.Current.GoToAsync($"{nameof(PublisherLandingPage)}?UserID={UserID}");
            }
            else
            {
                _= Shell.Current.DisplayAlert("Invalid Login Credentials", "Username or Password did not match", "Close");
            }
        }

        private bool CheckUser()
        {
            PublisherService pubService = new PublisherService();

            if ( string.IsNullOrEmpty( UserID) || string.IsNullOrEmpty( Password ) )
            {
                return false;
            } 
            else
            {
                if ( pubService.CheckUser( UserID, Password) )
                {
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
