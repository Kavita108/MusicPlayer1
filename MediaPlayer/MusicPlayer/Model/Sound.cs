using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace mediaplayer.Model
{
    public enum SoundCategory
    {
       Adele,
       Justin,
       Sia,
       Taylor
    }
    public class Sound
    {
        public string Name { get; set; }
        public SoundCategory Category { get; set; }
        public string AudioFile { get; set; }

        public string ImageFile { get; set; }
        public bool _playList { get; set; }
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

        public bool playList
        {
            get { return _playList; }
            set
            {
                _playList = value;

                ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                localSettings.Values[Name + "playlist"] = _playList;
            }
        }

        public Sound ( string name, SoundCategory category)

        {
            Name = name;
            Category = category;
            AudioFile = $"Assets/Audio/{category}/{name}.wav";
            ImageFile = $"Assets/Images/{category}/{name}.png";
  
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            playList = (bool)(localSettings.Values[Name + "playlist"] ?? false);
            rating = (int)(localSettings.Values[Name + "rating"] ?? -1);
        }
    }
}
