using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Used as Publisher/Artist
namespace beatSync.Models
{
    public class PublisherBeat : Person
    {
        private ObservableCollection<Album> albumID;
        private string description;
        int userType;
        public PublisherBeat() {}

        public int UserType
        {
            get => this.userType;
            set
            {
                this.userType = value;
                OnPropertyChanged(nameof(UserType));
            }
        }

        public ObservableCollection<Album> AlbumID
        {
            get => this.albumID;
            set
            {
                this.albumID = value;
                OnPropertyChanged(nameof(AlbumID));
            }
        }
        
        public string Description
        {
            get => this.description;
            set
            {
                this.description = value; 
                OnPropertyChanged(nameof(Description));
            }
        }
    }
}
