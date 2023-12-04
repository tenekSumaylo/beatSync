﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using beatSync.Models;
using beatSync.Services;
using CommunityToolkit.Maui.Views;
namespace beatSync.ViewModels
{
    [QueryProperty(nameof(DataStore), "DataStore")]
    public class PublisherLandingPageViewModel : BaseViewModel 
    {
        public ICommand OnAddSong => new Command( AddNewSong );
        private PublisherBeat personP;
        private ObservableCollection<Song> songList;
        private string userID;
        private SongService songServicer;
        private PublisherService publisherService;
        private string messageOutput;
        private PassingService dataStore;
        public PublisherLandingPageViewModel()
        {
            personP = new PublisherBeat();
            //songServicer = new SongService(); 
            publisherService = new PublisherService();
        }

        public string MessageOutput
        {
            get => messageOutput;
            set
            {
                messageOutput = value;
                OnPropertyChanged(nameof(MessageOutput ));
            }
        }

        public PassingService DataStore
        {
            get => this.dataStore;
            set
            {
                this.dataStore = value;
                OnPropertyChanged(nameof(DataStore));
                MessageOutput = this.dataStore.UserID;
            }
        }

        public string UserID
        {
            get => userID;
            set
            {
                MessageOutput = DataStore.UserInfo.UserID;
                userID = value;
                OnPropertyChanged(nameof(UserID));
                //SongList = songServicer.GetSpecificSongArtist(UserID);
                PersonP = publisherService.ReturnUser(userID);
           //     if ( !songServicer.ListCheckOfSongs( UserID ))
          //      {
           //         MessageOutput = "No songs added...";
           //     }
         //       else
          //      {
          //          MessageOutput = "";
                }
         //   }
        }

        public PublisherBeat PersonP
        {
            get => personP;
            set
            {
                personP = value;
                OnPropertyChanged(nameof(PersonP));
            }
        }

        public ObservableCollection<Song> SongList
        {
            get => songList;
            set
            {
                songList = value;
                OnPropertyChanged(nameof(SongList));
            }
        }

        public async void AddNewSong()
        {
            await Shell.Current.GoToAsync(nameof(AddSong), true, new Dictionary<string, object>
            {
                { "DataStore", DataStore }
            });
        }
    }
}
