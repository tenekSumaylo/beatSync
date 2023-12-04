using beatSync.Models;
using Microsoft.UI.Xaml.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beatSync.Services
{
    public class PassingService
    {
        ObservableCollection<PublisherBeat> persons;
        string userID;
        PublisherBeat userInfo;

        public PublisherBeat UserInfo
        {
            get => this.userInfo;
            set
            {
                this.userInfo = value;
            }
        }

        public ObservableCollection<PublisherBeat> Persons
        {
            get => this.persons;
            set
            {
                this.persons = value;
            }
        }

        public string UserID
        {
            get => this.userID;
            set
            {
                this.userID = value;
            }
        }

        public void GetUser()
        {
            foreach ( var person in Persons)
            {
                if ( person.UserID == UserID)
                {
                    UserInfo = person;
                }
            }
        }
    }
}
