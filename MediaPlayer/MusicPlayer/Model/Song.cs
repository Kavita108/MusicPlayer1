using Windows.Storage;

namespace MusicLibrary.Model
{
    public enum SongCategory
    {
        Adele,
        Justin,
        Sia,
        Taylor
    }

    public class Song
    {
        public string Name { get; set; }
        public SongCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        public bool SelectedForPlaylist { get; set; }
        public bool IsPlaying { get; set; }

        public int _rating { get; set; }

        public int rating
        {
            get { return _rating; }
            set
            {
                _rating = value;

                ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                localSettings.Values[Name + "rating"] = _rating;
            }
        }

        public bool IsPaused { get; set; }

        public Song(string name, SongCategory category)
        {
            Name = name;
            Category = category;
            AudioFile = $"Audio\\{category}\\{name}.wav";
            ImageFile = $"/Assets/Images/{category}/{name}.png";

            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            rating = (int)(localSettings.Values[Name + "rating"] ?? -1);
        }
    }
}

