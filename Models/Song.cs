using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beatSync.Models
{
    public class Song : BaseModel
    {
        private string songID;
        private string songName;
        private string genre;
        private string displayPhoto;
        private string artistID;
        private DateTime datePublished;
        private int songStreams;
        private float songDuration;
        private string language;
        private string artist;

        public string Artist
        {
            get => this.artist;
            set
            {
                this.artist = value;
                OnPropertyChanged(nameof(Artist));
            }
        }

        public string Language
        {
            get => this.language;
            set
            {
                this.language = value;
                OnPropertyChanged(nameof(Language));
            }
        }
        public int SongStreams
        {
            get => this.songStreams;
            set
            {
                this.songStreams = value;
                OnPropertyChanged(nameof(SongStreams));
            }
        }

        public string SongID
        {
            get => this.songID;
            set
            {
                this.songID = value;
                OnPropertyChanged(nameof(SongID));
            }
        }

        public float SongDuration
        {
            get => this.songDuration;
            set
            {
                this.songDuration = value;
                OnPropertyChanged(nameof(SongDuration));
            }
        }

        public DateTime DatePublished
        {
            get => datePublished;
            set
            {
                datePublished = value;
                OnPropertyChanged(nameof(DatePublished));
            }
        }
        public string DisplayPhoto
        {
            get => displayPhoto;
            set
            {
                displayPhoto = value;
                OnPropertyChanged(nameof(DisplayPhoto));
            }
        }
        public string Genre
        {
            get => genre;
            set
            {
                genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        public string ArtistID  
        {
            get => this.artistID;
            set
            {
                artistID = value;
                OnPropertyChanged(nameof(ArtistID));
            }
        }

        public string SongName
        {
            get
            {
                return songName;
            }
            set
            {
                songName = value;
                OnPropertyChanged(nameof(SongName));
            }
        }

        public void ClearAllFields()
        {
            SongName = string.Empty;
            ArtistID = string.Empty;
            Genre = string.Empty;
            DatePublished = DateTime.Now;
            DisplayPhoto = string.Empty;
            SongID = string.Empty;
            SongDuration = 0;
            Language = string.Empty;
            SongStreams = 0;
        }
    }
}
