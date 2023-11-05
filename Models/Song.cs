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
        private string artist;
        private string datePublished;
        private string songStreams;
        private float songDuration;

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

        public string DatePublished
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

        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
                OnPropertyChanged(nameof(Artist));
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
            Artist = string.Empty;
            Genre = string.Empty;
            DatePublished = string.Empty;
            DisplayPhoto = string.Empty;
            SongID = string.Empty;
            SongDuration = 0;
        }


    }
}
