using System.Collections.Generic;

namespace MusicLibrary.Model
{
    class PlaylistManager
    {
        public Dictionary<string, Playlist> Playlists { get; set; }
        public PlaylistManager()
        {
            Playlists = new Dictionary<string, Playlist>();

            Playlist playlist = new Playlist("Playlist1");
            Playlists.Add("Playlist1", playlist);

            playlist = new Playlist("Playlist2");
            Playlists.Add("Playlist2", playlist);

            playlist = new Playlist("Playlist3");
            Playlists.Add("Playlist3", playlist);
        }
    }
}
