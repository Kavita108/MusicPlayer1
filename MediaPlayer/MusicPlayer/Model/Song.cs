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

        public bool IsPaused { get; set; }

        public Song(string name, SongCategory category)
            {
                Name = name;
                Category = category;
                AudioFile = $"Audio\\{category}\\{name}.wav";
                ImageFile = $"/Assets/Images/{category}/{name}.png";
            }
        }
    
}

