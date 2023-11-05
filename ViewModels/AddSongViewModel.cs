using beatSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beatSync.ViewModels
{
    [QueryProperty(nameof(UserID), nameof(UserID))]
    public class AddSongViewModel : BaseViewModel
    {
        private string userID;
        private Song toBeAdded;

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
    }
}
