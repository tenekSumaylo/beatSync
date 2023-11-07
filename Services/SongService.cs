using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using beatSync.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace beatSync.Services
{
    class SongService
    {
        private ObservableCollection<Song> songAdd;
        string FilePathDir = FileSystem.Current.AppDataDirectory + @"/SONGLIST";
        string SongFile = FileSystem.Current.AppDataDirectory + @"/SONGLIST/Songs.txt";
        string SongPictureDir = FileSystem.Current.AppDataDirectory + @"/SONGPICTURES";

        public SongService() {
            songAdd = new ObservableCollection<Song>();
        }
        public ObservableCollection<Song> SongAdd
        {
            get => songAdd;
            set
            {
                songAdd = value;
            }
        }

        public void CheckExisting( string ID )
        {
            if (!Directory.Exists(FilePathDir + $"{ID}" ))
            {
                Directory.CreateDirectory( FilePathDir );
                Directory.CreateDirectory( SongPictureDir );
                File.Create( SongFile );
            }
        }

        public void WriteData(Song newSong, string ID)
        {

            if ( newSong != null )
            {
                songAdd = GetData();
                SongAdd.Add( newSong );
                var saveToFile = string.Empty;
                saveToFile = JsonSerializer.Serialize( SongAdd );
                File.WriteAllText( SongFile, saveToFile );
            }
        }

        public ObservableCollection<Song> GetData()
        {
            var k = new FileInfo( SongFile );
            if (k.Length == 0)
            {
                return new ObservableCollection<Song>();
            }
            string json = File.ReadAllText( SongFile );
            SongAdd = JsonSerializer.Deserialize<ObservableCollection<Song>>(json);
            return SongAdd;
        }

        public bool ListCheckOfSongs( string ID )
        {
            var k = new FileInfo( SongFile );
            if (k.Length == 0)
                return false;
            return true;
        }

        public void CopyPicture( string sourcePath, string fileName, string ID )
        {
            File.Copy( sourcePath, SongPictureDir );
        }

        public ObservableCollection<Song> GetSpecificSongArtist( string ID )
        {
            ObservableCollection<Song> allSongs = GetData();
            ObservableCollection<Song> songsOfArtist = new ObservableCollection<Song> ();

            foreach ( Song artistSong in  allSongs )
            {
                if ( artistSong.SongID.IndexOf( ID ) != -1 )
                {
                    songsOfArtist.Add( artistSong );
                }
            }
            return songsOfArtist;
        }


    }

}
