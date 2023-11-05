using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beatSync.Models
{
    public class CustomerUser : Person
    {
        private int userType;
        private Song songPlayed;
        private double songHour;
        private double songMinute;
        private double songSecond;

        public CustomerUser() { }
        public CustomerUser( int userType, Song lastSongPlayed, double lastHour, double lastMinute, double lastSecond, Person person ) : base( person ) {
            UserType = userType;
            songPlayed = lastSongPlayed;
            SongHour = lastHour;
            SongMinute = lastMinute; 
            SongSecond = lastSecond;
        }

        public int UserType
        {
            get { return userType; } 
            set
            {
                if ( value > 0 ) {
                    this.userType = value;
                }
            }
        }

        public Song SongPlayed
        {
            get { return this.songPlayed; }
            set
            {
                if ( value != null )
                {
                    this.songPlayed = value;
                }
            }
        }

        public double SongHour
        {
            get { return this.songHour; }
            set
            {
                if ( value > -1 )
                {
                    this.songHour = value;
                }
            }
        }

        public double SongMinute
        {
            get { return this.songMinute; }
            set
            {
                if ( value > -1 )
                {
                    this.songMinute = value;
                }
            }
        }

        public double SongSecond
        {
            get { return this.songSecond; }
            set
            {
                if ( value > -1 )
                {
                    this.songSecond = value;
                }
            }
        }
    }
}
