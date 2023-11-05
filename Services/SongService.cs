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
                Directory.CreateDirectory(FilePathDir + $"/{ID}");
                Directory.CreateDirectory(SongPictureDir + $"/{ID}");
                File.Create(FilePathDir + $"/{ID}/SongsList.txt");
            }
        }

        public void WriteData(Song adder, string ID)
        {

            if (adder != null)
            {
                GetData( ID );
                SongAdd.Add(adder);
                var saveToFile = string.Empty;
                saveToFile = JsonSerializer.Serialize(SongAdd);
                File.WriteAllText(FilePathDir + $"/{ID}/SongsList.txt", saveToFile);
            }
        }

        public ObservableCollection<Song> GetData( string ID )
        {
            var k = new FileInfo(FilePathDir + $"/{ID}/SongsList.txt");
            if (k.Length == 0)
            {
                return new ObservableCollection<Song>();
            }
            string json = File.ReadAllText(FilePathDir + $"/{ID}/SongsList.txt");
            SongAdd = JsonSerializer.Deserialize<ObservableCollection<Song>>(json);
            return SongAdd;
        }

        public bool ListCheckOfSongs( string ID )
        {
            var k = new FileInfo(FilePathDir + $"/{ID}/SongsList.txt");
            if (k.Length == 0)
                return false;
            return true;
        }

        public void CopyPicture( string sourcePath, string fileName, string ID )
        {
            File.Copy(sourcePath, SongPictureDir + $"/{ID}/{fileName}");
        }
    }

}
