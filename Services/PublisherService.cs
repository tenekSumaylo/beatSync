using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using beatSync.Models;
using Microsoft.Maui.Layouts;
using Microsoft.UI.Xaml;

namespace beatSync.Services
{
    public class PublisherService
    {
        private ObservableCollection<PublisherBeat> publisherPeople;
        string filePathDir = FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA";
        string filePathSaves = FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA/Publishers.txt";
        public PublisherService() { 
            PublisherPeople = new ObservableCollection<PublisherBeat>();
            CheckExisting();
            GetData();
        }


        public ObservableCollection<PublisherBeat> PublisherPeople
        {
            get => publisherPeople;
            set
            {
                publisherPeople = value;
            }
        }


        public void WriteData( PublisherBeat pub, int userType )
        {
            if ( pub != null )
            {
                if ( userType == 1 )
                {
                   filePathSaves = FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA/Publishers.txt";
                }
                else
                {
                    filePathSaves = FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA/Artist.txt";
                }
                GetData();
                publisherPeople.Add( pub );
                var saveToFile = string.Empty;
                saveToFile = JsonSerializer.Serialize(PublisherPeople);
                File.WriteAllText( filePathSaves, saveToFile );
            }
        }

        public void GetData()
        {
            var k = new FileInfo(filePathSaves);
            if ( k.Length == 0 )
            {
                return;
            }
            string json = File.ReadAllText(filePathSaves);
            PublisherPeople = JsonSerializer.Deserialize<ObservableCollection<PublisherBeat>>(json);
        }

        public void CheckExisting()
        {
            if ( !Directory.Exists( filePathDir ) )
            {
                Directory.CreateDirectory( filePathDir );
                File.Create( FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA/Publishers.txt" );
                File.Create(FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA/Artist.txt");
            }
        }

        public bool CheckUser(string ID, string pass, int userCheck)
        {
            if ( userCheck == 2 )
            {
                filePathSaves = FileSystem.Current.AppDataDirectory +  @"/PUBLISHERSERA/Artist.txt";
            }
            var k = new FileInfo(filePathSaves);
            GetData();
            if (k.Length == 0)
                return false;
            foreach ( var personP in PublisherPeople)
            {
                if ( personP.Email == ID && personP.Password == pass )
                {
                    return true;
                }
                else if ( personP.UserID == ID && personP.Password == pass )
                {
                    return true;
                }
            }
            return false;
        }

        public PublisherBeat ReturnUser( string ID )
        {
            foreach ( var personP in PublisherPeople)
            {
                if ( ID == personP.UserID || personP.Email == ID)
                {
                    return personP;
                }
            }
            return null;
        }
        
        public string GenerateID( int userType )
        {
            if (userType == 1)
            {
                filePathSaves = FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA/Publishers.txt";
            }
            else if ( userType == 2 ){
                filePathSaves = FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA/Artist.txt";
             }
            var generateID = new FileInfo( filePathSaves );
            int count = 0;
            if ( generateID.Length != 0 )
            {
                GetData();
                count = PublisherPeople.Count;
            }

            if (userType == 0)
                return "NONE SELECTED";
            else if (userType == 1)
                return $"publisher-{count+1}";
            return $"artist-{count+1}";
        }
        
        public void UpdateInfo( PublisherBeat updated )
        {
            if ( updated.UserType == 2 )
            {
                filePathSaves = FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA/Artist.txt";
            }
            else
            {
                filePathSaves = FileSystem.Current.AppDataDirectory + @"/PUBLISHERSERA/Publishers.txt";
            }

            GetData();
            PublisherPeople.RemoveAt( updated.PersonIndex );
            PublisherPeople.Insert( updated.PersonIndex, updated );
            var saveToFile = string.Empty;
            saveToFile = JsonSerializer.Serialize(PublisherPeople);
            File.WriteAllText(filePathSaves, saveToFile);
        } 
    }
}
