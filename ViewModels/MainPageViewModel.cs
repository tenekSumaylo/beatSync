using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using beatSync.Models;
using beatSync.ViewModels;

namespace beatSync.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IPopupService popupService;
        public ICommand OnNavigateCreate => new Command(NavigateCreateAccount);
        public ICommand OnNavigateLogin => new Command(NavigateLogin);

        public MainPageViewModel() { 
            popupService = new PopupService();
        }
        public async void NavigateCreateAccount()
        {
            await this.popupService.ShowPopupAsync<CreateAccountViewModel>();
        }
        public async void NavigateLogin() { await Shell.Current.GoToAsync(nameof(Login)); }
    }
}
