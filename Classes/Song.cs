using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beatSync.Classes
{
    internal class Song
    {
        private string songName;
        private string description;
        private string genre;
        private bool isPlayed;
        private double minute;
        private double second;
        private double hour;
        private string displayPhoto;
        private string artist;
        public bool IsPlayed
        {
            get { return isPlayed; }
            set { isPlayed = value; }
        }
        // void stop
        // void search
        // 

        public string SongName
        {
            get
            {
                return songName;
            }
            set
            {
                songName = value;
            }
        }

        private string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
    }
}
