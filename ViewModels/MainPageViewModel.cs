using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace beatSync.ViewModels
{
    public class MainPageViewModel
    {
        public ICommand OnNavigateCreate => new Command(NavigateCreateAccount);
        public ICommand OnNavigateLogin => new Command(NavigateLogin);
        public async void NavigateCreateAccount() { await Shell.Current.GoToAsync(nameof(CreateAccount));}
        public async void NavigateLogin() { await Shell.Current.GoToAsync(nameof(Login)); }
    }
}
