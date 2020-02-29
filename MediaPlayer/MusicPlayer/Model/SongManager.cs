using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MusicLibrary.Model
{
    public class SongManager
    {
        private static List<Song> getSongs()
        {
            var songs = new List<Song>();
            songs.Add(new Song("Hello", SongCategory.Adele));
            songs.Add(new Song("Someone", SongCategory.Adele));

            songs.Add(new Song("What", SongCategory.Justin));
            songs.Add(new Song("yummy", SongCategory.Justin));

            songs.Add(new Song("Chandelier", SongCategory.Sia));
            songs.Add(new Song("Cheap", SongCategory.Sia));

            songs.Add(new Song("Look", SongCategory.Taylor));
            songs.Add(new Song("Shake", SongCategory.Taylor));

            return songs;
        }

        public static void GetAllSongs(ObservableCollection<Song> songs)
        {

            var allSongs = getSongs();
            songs.Clear();
            allSongs.ForEach(s => songs.Add(s));
        }

        public static void GetSongsByCategory(ObservableCollection<Song> songs, SongCategory category)
        {
            var allSongs = getSongs();
            var filteredSongs = allSongs.Where(s => s.Category == category).ToList();
            songs.Clear();
            filteredSongs.ForEach(s => songs.Add(s));
        }

        public static void GetSongsByPlaylist(ObservableCollection<Song> songs)
        {
            var allSongs = getSongs();
            var filteredSongs = allSongs.Where(s => s.SelectedForPlaylist == true).ToList();
            songs.Clear();
            filteredSongs.ForEach(s => songs.Add(s));
        }
    }
}
