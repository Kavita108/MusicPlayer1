using System.Collections.Generic;
using Windows.Storage;

namespace MusicLibrary.Model
{
    class Playlist
    {
        public string Name { get; set; }
        public Playlist(string name)
        {
            Name = name;            
        }
    }
}
