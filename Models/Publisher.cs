using HomeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Used as Publisher/Artist
namespace beatSync.Models
{
    public class PublisherBeat : CustomerUser
    {
        private List<string> albumID;
        private string description;
        public PublisherBeat() {}


        public List<string> AlbumID
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
