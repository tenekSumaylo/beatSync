using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beatSync.Models { 
    public class Album : BaseModel
    {
        private ObservableCollection<Song> songs = new ObservableCollection<Song>();
        private string albumTitle;
        private string albumArtist;
        private DateTime releaseDate;
        private int albumStream;
        private string albumCover;
        private string albumDescription;


        public string AlbumDescription
        {
            get => this.albumDescription;
            set
            {
                this.albumDescription = value;
                OnPropertyChanged(nameof(AlbumDescription));
            }
        }
        
        public string AlbumCover
        {
            get => this.albumCover;
            set
            {
                this.albumCover = value;
                OnPropertyChanged(nameof(AlbumCover));
            }
        }

        public string AlbumTitle
        {
            get => this.albumTitle;
            set
            {
                this.albumTitle = value;
                OnPropertyChanged(nameof(AlbumTitle));
            }
        }

        public string AlbumArtist
        {
            get => this.albumArtist;
            set
            {
                this.albumArtist = value;
                OnPropertyChanged(nameof(AlbumArtist));
            }
        }

        public DateTime ReleaseDate
        {
            get => this.releaseDate;
            set
            {
                this.releaseDate = value;
                OnPropertyChanged( nameof( ReleaseDate ));
            }
        }

        public int AlbumStream
        {
            get => this.albumStream;
            set
            {
                this.albumStream = value;
                OnPropertyChanged(nameof(AlbumStream));
            }
        }

        public ObservableCollection<Song> Songs { get { return songs; } 
            set
            {
                this.songs = value;
                OnPropertyChanged(nameof(Songs));
            }
        }

        public bool songAdd( Song song )
        {
            if ( song != null )
            {
                songs.Add( song );
                return true;
            }
            return false;
        }
    }
}
