using System.Collections.Generic;

namespace MusicLibrary.Model
{
    class Playlist
    {
        public string Name { get; set; }
        //public string Icon { get; set; }
        public List<Song> Songs { get; set; }
        public Playlist(string name)
        {
            Name = name;
            //Icon = $"/Assets/Images/{icon}.png";
            Songs = new List<Song>();
        }
    }
}
