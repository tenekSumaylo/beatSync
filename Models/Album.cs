using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beatSync.Models { 
    public class Album : BaseModel
    {
        private List<Song> songs = new List<Song>();
        private string albumTitle;
        private string albumArtist;

        public List<Song> Songs { get { return songs; } 
            set
            {
                this.songs = value;
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
